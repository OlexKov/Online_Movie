namespace BusinessLogic.Data.Entities
{
	public class StafRole : NameBaseEntity
	{
		public ICollection<StafStafRole> StafStafRoles { get; set; } = new HashSet<StafStafRole>();
	}
}
