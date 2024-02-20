using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
	public class User : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime Birthdate { get; set; }
		public DateTime PremiumDate { get; set; }
		public Premium Premium { get; set; }
		public int PremiumId { get; set; }
		public IEnumerable<UserMovie> UserMovies { get; set; } = new HashSet<UserMovie>();
		public IEnumerable<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
	}
}
