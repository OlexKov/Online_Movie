using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Core;
using System.Data;
using System.Net;



namespace BusinessLogic.Services
{
	internal class AccountsService : IAccountsService
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;
		private readonly IMapper mapper;
		private readonly IValidator<RegisterModel> registerValidator;
		private readonly IValidator<ResetPasswordModel> resetModelValidator;
		private readonly IEmailService emailService;
		private readonly IJwtService jwtService;

		public AccountsService(UserManager<User> userManager,
								SignInManager<User> signInManager,
								IMapper mapper,
								IValidator<RegisterModel> registerValidator,
								IValidator<ResetPasswordModel> resetModelValidator,
								IEmailService emailService,IJwtService jwtService)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.mapper = mapper;
			this.registerValidator = registerValidator;
			this.resetModelValidator = resetModelValidator;
			this.emailService = emailService;
			this.jwtService = jwtService;
		}

		public async Task Register(RegisterModel model)
		{
			registerValidator.ValidateAndThrow(model);

			if (await userManager.FindByEmailAsync(model.Email) != null)
				throw new HttpException(Errors.EmailExists, HttpStatusCode.BadRequest);

			var user = mapper.Map<User>(model);

			var result = await userManager.CreateAsync(user, model.Password);
			await userManager.AddToRoleAsync(user, "User");
			if (!result.Succeeded)
				throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task<LoginJwtResponse> Login(LoginModel model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);

			if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
				throw new HttpException(Errors.InvalidRegData, HttpStatusCode.BadRequest);

			await signInManager.SignInAsync(user, true);
			return new() { Token = jwtService.CreateToken(jwtService.GetClaims(user)) };
		}
		

		public async Task Logout() => await signInManager.SignOutAsync();

		
		public async Task<ResetPasswordResponse> ResetPasswordRequest(string email)
		{
			ResetPasswordResponse rModel = new(); 
			var user = await userManager.FindByEmailAsync(email);
			if (user != null)
			{
				rModel.Token = await userManager.GeneratePasswordResetTokenAsync(user);
				rModel.UserId = user.Id;
				await emailService.SendAsync(email,"Reset password",  $"\"Для сброса пароля пройдите по ссылке: <a href='#'>Reset password</a>\"",true);
			}
			return rModel;
		}

		public async Task ResetPassword(ResetPasswordModel model)
		{
			resetModelValidator.ValidateAndThrow(model);
			var user = await userManager.FindByIdAsync(model.UserId) 
				?? throw new HttpException(Errors.NotFoundById,HttpStatusCode.NotFound);
			var result = await userManager.ResetPasswordAsync(user,model.Token,model.Password);
			if (!result.Succeeded)
				throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task Delete(User user)
		{
			if(user == null) throw new HttpException(Errors.NullReference, HttpStatusCode.BadRequest);
			var result = await userManager.DeleteAsync(user);
			if(!result.Succeeded) throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task Delete(string email)
		{
			var user = await userManager.FindByEmailAsync(email) 
				?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.BadRequest);
			await Delete(user);
		}
	}
}
