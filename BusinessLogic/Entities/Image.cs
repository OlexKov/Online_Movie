namespace BusinessLogic.Data.Entities
{
	public class Image : NameBaseEntity
	{
		public  Movie Movie { get; set; }
		public int MovieId { get; set; }
	}
}
