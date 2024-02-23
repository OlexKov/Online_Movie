namespace BusinessLogic.Data.Entities
{
	public class Quality : NameBaseEntity
	{
		public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
	}
}
