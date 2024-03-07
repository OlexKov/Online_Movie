using BusinessLogic.DTOs;
using BusinessLogic.ModelDto;


namespace BusinessLogic.Interfaces
{
	public interface IMovieService
	{
		Task<IEnumerable<MovieDto>> GetAllAsync();
		//Task<IEnumerable<MovieDto>> GetTopAsync(int count);
		Task<MovieDto> GetByIdAsync(int id);
		Task<IEnumerable<StafDto>> GetStafAsync(int id);
		Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(int id);
		Task<double> GetRatingAsync(int id);
		Task UpdateAsync(MovieModel movie);
		Task CreateAsync(MovieModel movie);
		Task DeleteAsync(int id);
	}
}
