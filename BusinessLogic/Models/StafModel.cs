using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Models
{
	public class StafModel
	{
		public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Description { get; set; }
		public string? ImageName { get; set; }
		public IFormFile? ImageFile { get; set; }
		public int? CountryId { get; set; }
		public DateTime? Birthdate { get; set; }
		public bool? IsOscar { get; set; }
		public List<int> Movies { get; set; } = [];
		public List<int> Roles { get; set; } = [];
	}
}
