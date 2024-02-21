using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Validators;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace BusinessLogic.Services
{
	internal class StafService : IStafService
	{
		private readonly IRepository<Staf> stafs;
		private readonly IRepository<StafMovie> stafMovies;
		private readonly IRepository<StafStafRole> roles;
		private readonly IMapper mapper;
		private readonly IImageService imageService;
		private readonly IValidator<StafModel> validator;

		public StafService(IRepository<Staf> stafs, IRepository<StafMovie> stafMovies,
			               IRepository<StafStafRole> roles, IMapper mapper,
						   IImageService imageService,IValidator<StafModel> validator)
        {
			this.stafs = stafs;
			this.stafMovies = stafMovies;
			this.roles = roles;
			this.mapper = mapper;
			this.imageService = imageService;
			this.validator = validator;
		}

		public async Task<StafDto> GetAsync(int id)
		{
			if (id < 0) throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);
			var staf = await stafs.FirstOrDefaultAsync(selector: x => x,
																	   predicate: x => x.Id == id,
																	   include: staf => staf
																		   .Include(x => x.Country));
			return staf == null ? throw new HttpException("Staf not found.", HttpStatusCode.NotFound) : mapper.Map<StafDto>(staf);
		}

		public async Task<IEnumerable<StafDto>> GetAsync(IEnumerable<int> ids)
		{
			return mapper.Map<IEnumerable<StafDto>>(await stafs.GetAsync(selector: x => x,
																		 predicate: x => ids.Any(z=>z == x.Id),
																		 include: staf => staf
																		          .Include(x => x.Country)));
		}

		public async Task<IEnumerable<StafDto>> GetAllAsync()
		{
			return mapper.Map<IEnumerable<StafDto>>( await stafs.GetAsync(selector:x=>x,
				                                                          include:staf=>staf
																		          .Include(x=>x.Country)));
		}

		public async Task<IEnumerable<MovieDto>> GetMoviesAsync(int id)
		{
			return mapper.Map<IEnumerable<MovieDto>>(await stafMovies.GetAsync(selector:x=> x.Movie,
				                                                                predicate:x=>x.StafId == id, 
																				include: stafMovie=> stafMovie
																						 .Include(x=>x.Movie)
																						 .ThenInclude(x=>x.Country)
																						 .Include(x => x.Movie)
																						 .ThenInclude(x=>x.Quality)
																						 .Include(x => x.Movie)
																						 .ThenInclude(x=>x.Premium)));
		}

		public async Task<IEnumerable<StafRoleDto>> GetRolesAsync(int id)
		{
			if (id < 0) throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<StafRoleDto>>(await roles.GetAsync(selector:x =>x.StafRole,
				                                                              predicate: x => x.StafId == id));
		}

		public async Task UpdateAsync(StafModel staf)
		{
			validator.ValidateAndThrow(staf);
			var stafEdit = mapper.Map<Staf>(staf);
			if (staf.ImageFile != null)
			{
				stafEdit.ImageName = await imageService.SaveImageAsync(staf.ImageFile);
			  if(staf.ImageName!= "nophoto.jpeg")	imageService.DeleteImageByName(staf.ImageName);
			}
			stafEdit.StafMovies = new HashSet<StafMovie>();
			stafEdit.StafStafRoles = new HashSet<StafStafRole>();
			foreach (var item in staf.Movies)
				stafEdit.StafMovies.Add(new StafMovie() { StafId = stafEdit.Id,MovieId = item});
			foreach (var item in staf.Roles)
				stafEdit.StafStafRoles.Add(new StafStafRole() { StafId = stafEdit.Id, StafRoleId = item });

			stafs.Update(stafEdit);
			await stafs.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			if (id < 0) throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);
			var staf = await stafs.GetByIDAsync(id);
			if (staf == null) throw new HttpException("Staf not found.", HttpStatusCode.NotFound);
			await stafs.DeleteAsync(id);
			await stafs.SaveAsync();
			imageService.DeleteImageByName(staf.ImageName);
		}

		public async Task CreateAsync(StafModel staf)
		{
			validator.ValidateAndThrow(staf);
			var stafEdit = mapper.Map<Staf>(staf);
			if (staf.ImageFile != null)
			{
				stafEdit.ImageName = await imageService.SaveImageAsync(staf.ImageFile);
			}
			foreach (var item in staf.Movies)
				stafEdit.StafMovies.Add(new StafMovie() { StafId = stafEdit.Id, MovieId = item });
			foreach (var item in staf.Roles)
				stafEdit.StafStafRoles.Add(new StafStafRole() { StafId = stafEdit.Id, StafRoleId = item });
			await stafs.InsertAsync(stafEdit);
			await stafs.SaveAsync();
		}
	}
}
