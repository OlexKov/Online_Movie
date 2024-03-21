using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Http;


namespace BusinessLogic.Interfaces
{
	public interface IImageService
	{
		Task<string> SaveImageAsync(IFormFile image);
		Task<string> AddImageAsync(IFormFile image);
		void DeleteImageByName(string name);
		Task DeleteImegeByIdAsync(int id);
		Task DeleteImegeRangeAsync(IEnumerable<int> ids);
		Task<IEnumerable<ImageDto>> GetByIds(IEnumerable<int> ids);
		Task<IEnumerable<ImageDto>> GetByMovieId(int movieId);
	}
}
