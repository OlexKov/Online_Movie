namespace BusinessLogic.Data.Entities
{
	public class Country : NameBaseEntity
	{
		public ICollection<Staf> Stafs { get; set; } = new HashSet<Staf>();
		public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
	}
}
