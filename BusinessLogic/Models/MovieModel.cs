using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
	public class MovieModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? OriginalName { get; set; }
		public DateTime DateDuration { get; set; }
		public string? Description { get; set; }
		public int QualityId { get; set; }
		public int CountryId { get; set; }
		public string? Poster { get; set; }
		public IFormFile? PosterFile { get; set; }
		public string? MovieUrl { get; set; }
		public string? TrailerUrl { get; set; }
		public int PremiumId { get; set; }
		public List<int> Stafs { get; set; } = [];
		public List<int> ScreenShots { get; set; } = [];
		public List<int> Genres { get; set; } = [];
		public List<IFormFile> Screens { get; set; } = [];
	}
}
