using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class ResetPasswordModel
	{
		public string UserId { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }

		public string Token { get; set; }
	}
}
