using BusinessLogic.DTOs;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;


namespace BusinessLogic.Interfaces
{
	public interface IMovieService
	{
		Task<FindResultModel<MovieDto>> TakeAsync(int skip, int count);
		Task<IEnumerable<MovieDto>> GetAllAsync();
		Task<IEnumerable<MovieDto>> GetTopByRatingAsync(int count);
		Task<MovieDto> GetByIdAsync(int id);
		Task<IEnumerable<StafDto>> GetStafAsync(int id);
		Task<FindResultModel<FeedbackDto>> GetFeedbacksAsync(int id, bool approved, int pageIndex, int pageSize);
		Task<double> GetRatingAsync(int id);
		Task UpdateAsync(MovieModel movie);
		Task CreateAsync(MovieModel movie);
		Task DeleteAsync(int id);
		Task<IEnumerable<MovieDto>> FindAsync(MovieFindFilterModel movieFilter);
		Task<IEnumerable<ImageDto>> GetScreensAsync(int id);
		Task<IEnumerable<GenreDto>> GetGenresAsync(int id);
		Task<FindResultModel<MovieDto>> GetMovieFilteredPaginationAsync(FilteredPaginationModel model);
	}
}
