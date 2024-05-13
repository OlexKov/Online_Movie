using Azure.Identity;

namespace BusinessLogic.DTOs
{
	public class FeedbackDto : BaseDto
	{
		public string Text { get; set; }
		public double Rating { get; set; }
		public string UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public int MovieId { get; set; }
		public bool Approved { get; set; }
		public DateTime Date { get; set; }
	}
}
