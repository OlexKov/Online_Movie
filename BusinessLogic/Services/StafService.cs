using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BusinessLogic.Services
{
	internal class StafService : IStafService
	{
		private readonly IRepository<Staf> stafs;
		private readonly IRepository<StafMovie> stafMovies;
		private readonly IRepository<StafStafRole> roles;
		private readonly IMapper mapper;

		public StafService(IRepository<Staf> stafs, IRepository<StafMovie> stafMovies, IRepository<StafStafRole> roles, IMapper mapper)
        {
			this.stafs = stafs;
			this.stafMovies = stafMovies;
			this.roles = roles;
			this.mapper = mapper;
		}

		public async Task<StafDto> GetAsync(int id)
		{
			return mapper.Map<StafDto>(await stafs.FirstOrDefaultAsync(selector:x=>x,
				                                                       predicate: x=>x.Id == id,
				                                                       include:staf=>staf
																	       .Include(x=>x.Country)));
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
			return mapper.Map<IEnumerable<StafRoleDto>>(await roles.GetAsync(selector:x =>x.StafRole,
				                                                              predicate: x => x.StafId == id));
		}
	}
}
