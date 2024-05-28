namespace BusinessLogic.Data.Entities
{
	public class Premium : NameBaseEntity
	{
		public int Rate { get; set; }

		public int Price { get; set; }
		public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
		public ICollection<User> Users { get; set; } = new HashSet<User>();
	}
}
