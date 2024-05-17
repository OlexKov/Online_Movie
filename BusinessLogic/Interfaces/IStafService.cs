
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
	public interface IStafService
	{
		Task<StafFindResultModel> GetStafWithPaginationAsync(int pageSize, int pageIndex);
		Task<StafDto> GetAsync(int id);
		Task<IEnumerable<StafDto>> GetAsync(IEnumerable<int> ids);
		Task<IEnumerable<StafDto>> GetAllAsync();
		Task<IEnumerable<StafRoleDto>> GetRolesAsync(int id);
		Task<IEnumerable<StafRoleDto>> GetMovieRolesAsync(int stafId, int movieId);
		Task<IEnumerable<MovieDto>> GetMoviesAsync(int id);
		Task UpdateAsync(StafModel staf);
		Task DeleteAsync(int id);
		Task CreateAsync(StafModel staf);
	}
}
