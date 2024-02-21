
using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
	public interface IStafService
	{
		Task<StafDto> GetAsync(int id);
		Task<IEnumerable<StafDto>> GetAsync(IEnumerable<int> ids);
		Task<IEnumerable<StafDto>> GetAllAsync();
		Task<IEnumerable<StafRoleDto>> GetRolesAsync(int id);
		Task<IEnumerable<MovieDto>> GetMoviesAsync(int id);
	}
}
