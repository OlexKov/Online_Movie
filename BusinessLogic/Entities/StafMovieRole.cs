namespace BusinessLogic.Data.Entities
{
	public class StafMovieRole : BaseEntity
	{
		public int StafId { get; set; }
		public Staf Staf { get; set; }
		public int MovieId { get; set; } 
		public Movie Movie { get; set; }
		public StafRole StafRole { get; set; }
		public int StafRoleId { get; set; }

	}
}
