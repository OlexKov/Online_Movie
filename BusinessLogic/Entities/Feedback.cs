namespace BusinessLogic.Data.Entities
{
	public class Feedback :BaseEntity
	{
		public string Text { get; set; }
		public double Rating { get; set; }
		public User User { get; set; }
		public string UserId { get; set; }
		public Movie Movie { get; set; }
		public int MovieId { get; set; }
	}
}
