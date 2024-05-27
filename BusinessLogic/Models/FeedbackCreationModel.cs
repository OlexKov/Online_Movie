using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class FeedbackCreationModel
	{
		public string Text { get; set; }
		public double Rating { get; set; }
		public string UserId { get; set; }
		public int MovieId { get; set; }
		public bool Approved { get; set; }
		public DateTime Date { get; set; }
	}
}
