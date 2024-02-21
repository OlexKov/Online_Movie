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
	}
}
