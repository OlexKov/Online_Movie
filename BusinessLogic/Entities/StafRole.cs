namespace BusinessLogic.Data.Entities
{
	public class StafRole : NameBaseEntity
	{
		public ICollection<StafMovieRole> StafMovieRoles { get; set; } = new HashSet<StafMovieRole>();
		public ICollection<StafStafRole> StafStafRoles { get; set; } = new HashSet<StafStafRole>();
	}
}
