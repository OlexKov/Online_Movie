using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace BusinessLogic.Services
{
	internal class ImageService : IImageService
	{
		private readonly IWebHostEnvironment env;
		private readonly IConfiguration config;
		private readonly IRepository<Image> images;

		public ImageService(IWebHostEnvironment env, IConfiguration config,IRepository<Image> images)
        {
			this.env = env;
			this.config = config;
			this.images = images;
		}

		

		public void DeleteImageByName(string name)
		{
			string filePath = Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, name);
			File.Delete(filePath);
		}

		public Task DeleteImegeByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task DeleteImegeRangeAsync(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}
		

		public async Task<string> SaveImageAsync(IFormFile image)
		{
			string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);
			string filePath = Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, fileName);
			using Stream fileStream = new FileStream(filePath, FileMode.Create);
			await image.CopyToAsync(fileStream);
			return fileName;
		}

		public async Task<string> AddImageAsync(IFormFile image)
		{
			var name = await SaveImageAsync(image);
			await images.InsertAsync(new Image() {Name = name });
			return name;
		}
	}
}
