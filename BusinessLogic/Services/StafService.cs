using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;


namespace BusinessLogic.Services
{
	internal class StafService : IStafService
	{
		private readonly IRepository<Staf> stafs;
		private readonly IRepository<StafMovieRole> stafMovies;
		private readonly IRepository<StafStafRole> roles;
		private readonly IRepository<StafMovieRole> movieRoles;
		private readonly IMapper mapper;
		private readonly IImageService imageService;
		private readonly IValidator<StafModel> validator;

		private async Task deleteStafDependencies(int id)
		{
			var stafRoles = await roles.GetListBySpec(new StafStafRolesSpecs.GetByStafId(id));

			foreach (var item in stafRoles)
				roles.Delete(item);
		}
		private async Task<Staf> setData(StafModel stafModel, bool update)
		{
			validator.ValidateAndThrow(stafModel);
			var staf = mapper.Map<Staf>(stafModel);
			if (update)
				await deleteStafDependencies(stafModel.Id);
			
			foreach (var item in stafModel.Roles)
				staf.StafStafRoles.Add(new StafStafRole() { StafId = staf.Id, StafRoleId = item });
			if (stafModel.ImageFile != null)
			{
			    if (update && staf.ImageName != null && staf.ImageName != "nophoto.jpg")
					imageService.DeleteImageByName(staf.ImageName);
				staf.ImageName = await imageService.SaveImageAsync(stafModel.ImageFile);
			}
			return staf;
		}

		public StafService(IRepository<Staf> stafs, IRepository<StafMovieRole> stafMovies,
			               IRepository<StafStafRole> roles, IRepository<StafMovieRole> movieRoles, IMapper mapper,
						   IImageService imageService,IValidator<StafModel> validator)
        {
			this.stafs = stafs;
			this.stafMovies = stafMovies;
			this.roles = roles;
			this.movieRoles = movieRoles;
			this.mapper = mapper;
			this.imageService = imageService;
			this.validator = validator;
			
		}

		public async Task<StafDto> GetAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var staf = await stafs.GetItemBySpec(new StafSpecs.GetById(id))
									   ?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound);
			return  mapper.Map<StafDto>(staf);
		}

		public async Task<IEnumerable<StafDto>> GetAsync(IEnumerable<int> ids)
		{
			return mapper.Map<IEnumerable<StafDto>>(await stafs.GetListBySpec(new StafSpecs.GetByIds(ids)));
		}

		public async Task<IEnumerable<StafDto>> GetAllAsync()
		{
			return mapper.Map<IEnumerable<StafDto>>( await stafs.GetListBySpec(new StafSpecs.GetAll()));
		}

		public async Task<IEnumerable<MovieDto>> GetMoviesAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<MovieDto>>((await stafMovies.GetListBySpec(new StafMovieRoleSpecs.GetMovieByStafIdInc(id))).Select(x=>x.Movie));
		}

		public async Task<IEnumerable<StafRoleDto>> GetRolesAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<StafRoleDto>>((await roles.GetListBySpec(new StafStafRolesSpecs.GetByStafIdInc(id))).Select(x=>x.StafRole));
		}

		public async Task UpdateAsync(StafModel staf)
		{
			if (staf == null) throw new HttpException(Errors.InvalidRequestData, HttpStatusCode.BadRequest);
			stafs.Update(await setData(staf, true));
			await stafs.SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var staf = await stafs.GetItemBySpec(new StafSpecs.GetByIdIncCol(id))
									   ?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound);
			stafs.Delete(staf);
			await stafs.SaveAsync();
			if(staf.ImageName!=null && staf.ImageName != "nophoto.jpg")
		    	imageService.DeleteImageByName(staf.ImageName);
		}

		public async Task CreateAsync(StafModel staf)
		{
			await stafs.InsertAsync(await setData(staf, false));
			await stafs.SaveAsync();
		}

		public async Task<FindResultModel<StafDto>> GetStafWithPaginationAsync(int pageSize, int pageIndex)
		{
			var stafList = new PaginatedList<StafDto>(await GetAllAsync(), pageIndex, pageSize);
			return new FindResultModel<StafDto>() { Elements = stafList, TotalCount = stafList.TotalCount };
		}

		public async Task<IEnumerable<StafRoleDto>> GetMovieRolesAsync(int stafId, int movieId)
		{
			if (stafId < 0 || movieId < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<StafRoleDto>>((await movieRoles.GetListBySpec(new StafMovieRoleSpecs.GetMovieRoles(stafId, movieId))).Select(x => x.StafRole));
		}
	}
}
