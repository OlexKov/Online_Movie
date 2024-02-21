
using BusinessLogic.DTOs;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
	public interface IStafService
	{
		Task<StafDto> GetAsync(int id);
		Task<IEnumerable<StafDto>> GetAsync(IEnumerable<int> ids);
		Task<IEnumerable<StafDto>> GetAllAsync();
		Task<IEnumerable<StafRoleDto>> GetRolesAsync(int id);
		Task<IEnumerable<MovieDto>> GetMoviesAsync(int id);
		Task UpdateAsync(StafModel staf);
		Task DeleteAsync(int id);
		Task CreateAsync(StafModel staf);
	}
}
