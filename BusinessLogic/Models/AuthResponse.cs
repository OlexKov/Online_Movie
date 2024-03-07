using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ModelDto
{
	public class AuthResponse
	{
		public string AccessToken { get; set; } = null!;
		public string RefreshToken { get; set; } = null!;
	}
}
