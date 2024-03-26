using BusinessLogic.DTOs;


namespace BusinessLogic.Interfaces
{
	public interface IDataService
	{
		Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
		Task<IEnumerable<StafRoleDto>> GetAllRolesAsync();
		Task<IEnumerable<GenreDto>> GetAllGenresAsync();
		Task<IEnumerable<QualityDto>> GetAllQualitiesAsync();
		Task<IEnumerable<PremiumDto>> GetAllPremiumsAsync();

	}
}
