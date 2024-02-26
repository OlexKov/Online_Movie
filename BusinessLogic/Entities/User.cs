using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Data.Entities
{
	public class User : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime Birthdate { get; set; }
		public DateTime? PremiumDate { get; set; }
		public Premium Premium { get; set; }
		public int PremiumId { get; set; }
		public ICollection<UserMovie> UserMovies { get; set; } = new HashSet<UserMovie>();
		public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
	}
}
