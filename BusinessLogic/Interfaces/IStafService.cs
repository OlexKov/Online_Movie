
using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
	public interface IStafService
	{
		Task<StafDto> Get(int id);
		Task<IEnumerable<StafDto>> Get(IEnumerable<int> ids);
		Task<IEnumerable<StafDto>> GetAll();
		Task<IEnumerable<StafRoleDto>> GetRoles(int id);
		Task<IEnumerable<MovieDto>> GetMovies(int id);
	}
}
