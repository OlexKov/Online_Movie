namespace BusinessLogic.Data.Entities
{
	public class UserMovie : BaseEntity
	{
		public User User { get; set; }
		public string UserId { get; set; }
		public Movie Movie { get; set; }
		public int MovieId { get; set; }
	}
}
