using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ModelDto
{
	public class ResetPasswordResponse
	{
		public string Token { get; set; }
		public string UserId { get; set; }
	}
}
