using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
	public class MovieDto : NameBaseDto
	{
		public string? OriginalName { get; set; }
		public DateOnly Date { get; set; }
		public TimeOnly Duration { get; set; }
		public string? Description { get; set; }
		public int QualityId { get; set; }
		public string? QualityName { get; set; }
		public int CountryId { get; set; }
		public string? CountryName { get; set; }
		public string? Poster { get; set; }
		public string? MovieUrl { get; set; }
		public string? TrailerUrl { get; set; }
		public int PremiumId { get; set; }
		public string? PremiumName { get; set; }
	}
}
