using BusinessLogic.DTOs;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;


namespace BusinessLogic.Interfaces
{
	public interface IMovieService
	{
		Task<IEnumerable<MovieDto>> GetAllAsync();
		Task<IEnumerable<MovieDto>> GetTopByRatingAsync(int count);
		Task<MovieDto> GetByIdAsync(int id);
		Task<IEnumerable<StafDto>> GetStafAsync(int id);
		Task<PaginationResultModel<FeedbackDto>> GetFeedbacksAsync(int id, bool approved, int pageIndex, int pageSize);
		Task<double> GetRatingAsync(int id);
		Task UpdateAsync(MovieModel movie);
		Task CreateAsync(MovieModel movie);
		Task DeleteAsync(int id);
		Task<IEnumerable<MovieDto>> FindAsync(MovieFindFilterModel movieFilter);
		Task<IEnumerable<ImageDto>> GetScreensAsync(int id);
		Task<IEnumerable<GenreDto>> GetGenresAsync(int id);
		Task<PaginationResultModel<MovieDto>> GetMovieFilteredPaginationAsync(FilteredPaginationModel model);

		Task<bool> HasFeedbackAsync(int movieId,string userId);
		Task AddFeedbackAsync(FeedbackCreationModel model);
		Task DeleteFeedbackAsync(int feedbackId);
		Task ApproveFeedbackAsync(int feedbackId);
		Task<PaginationResultModel<MovieDto>> GetMoviesWithNotApprovedFeedbacksAsync(int pageIndex, int pageSize);
		Task<int> GetNotApprovedFeedbacksCount();
	}
}
