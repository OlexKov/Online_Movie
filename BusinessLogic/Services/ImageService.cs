using BusinessLogic.Data.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;


namespace BusinessLogic.Services
{
	internal class ImageService : IImageService
	{
		private readonly IRepository<Image> images;
		private readonly string sysPath;

		public ImageService(IWebHostEnvironment env, IConfiguration config,IRepository<Image> images)
        {
			this.images = images;
			sysPath = Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty);
		}

		public void DeleteImageByName(string name)
		{
			string filePath = Path.Combine(sysPath, name);
			File.Delete(filePath);
		}

		public async Task DeleteImegeByIdAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var image = await images.GetByIDAsync(id) ?? throw new HttpException("Image not found.", HttpStatusCode.NotFound);
			await images.DeleteAsync(id);
			await images.SaveAsync();
			DeleteImageByName(image.Name);
		}

		public async Task DeleteImegeRangeAsync(IEnumerable<int> ids)
		{
			var imageNames = await images.GetListBySpec(new ImageSpecs.GetByIds(ids));
			foreach (var item in ids)
				await images.DeleteAsync(item);
			await images.SaveAsync();
			foreach (var image in imageNames)
				DeleteImageByName(image.Name);
		}
		

		public async Task<string> SaveImageAsync(IFormFile image)
		{
			string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);
			string filePath = Path.Combine(sysPath, fileName);
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
