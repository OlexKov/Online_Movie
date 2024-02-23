namespace BusinessLogic.Data.Entities
{
	public class Genre : NameBaseEntity
	{
		public ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();
	}
}
