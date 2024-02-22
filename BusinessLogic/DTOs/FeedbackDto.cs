using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
	public class FeedbackDto : BaseDto
	{
		public string Text { get; set; }
		public double Rating { get; set; }
		public string UserId { get; set; }
		public int MovieId { get; set; }
	}
}
