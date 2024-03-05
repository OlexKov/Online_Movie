﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class RegisterUserModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int PremiumId { get; set; } = 1;
		public string? PhoneNumber { get; set; }
		public DateTime Birthdate { get; set; }
	}
}
