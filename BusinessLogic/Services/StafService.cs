using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Resources;
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
		

		private async Task<Staf> setData(StafModel staf, bool update)
		{
			validator.ValidateAndThrow(staf);
			var stafEdit = mapper.Map<Staf>(staf);
			if (update)
			{
				stafEdit.StafMovies.Clear();
				stafEdit.StafStafRoles.Clear();
			}
			foreach (var item in staf.Movies)
				stafEdit.StafMovies.Add(new StafMovie() { StafId = stafEdit.Id, MovieId = item });
			foreach (var item in staf.Roles)
				stafEdit.StafStafRoles.Add(new StafStafRole() { StafId = stafEdit.Id, StafRoleId = item });
			if (staf.ImageFile != null)
			{
				stafEdit.ImageName = await imageService.SaveImageAsync(staf.ImageFile);
				if (update && staf.ImageName != "nophoto.jpeg")
					imageService.DeleteImageByName(staf.ImageName);
			}
			return stafEdit;
		}

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
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var staf = await stafs.FirstOrDefaultAsync(selector: x => x,
																	   predicate: x => x.Id == id,
																	   include: staf => staf
																		   .Include(x => x.Country));
			return staf == null ? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound) : mapper.Map<StafDto>(staf);
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
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
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
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<StafRoleDto>>(await roles.GetAsync(selector:x =>x.StafRole,
				                                                              predicate: x => x.StafId == id));
		}

		public async Task UpdateAsync(StafModel staf)
		{
			if (staf == null) throw new HttpException(Errors.NotFoundById, HttpStatusCode.InternalServerError);
			stafs.Update(await setData(staf, true));
			await stafs.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var staf = await stafs.GetByIDAsync(id) ?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound);
			await stafs.DeleteAsync(id);
			await stafs.SaveAsync();
			imageService.DeleteImageByName(staf.ImageName);
		}

		public async Task CreateAsync(StafModel staf)
		{
			await stafs.InsertAsync(await setData(staf, false));
			await stafs.SaveAsync();
		}
	}
}
