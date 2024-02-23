

namespace BusinessLogic.Data.Entities
{
	public  class StafStafRole : BaseEntity
	{
		public Staf Staf { get; set; }
		public int StafId { get; set; }
		public StafRole StafRole { get; set; }
		public int StafRoleId { get; set; }
	}
}
