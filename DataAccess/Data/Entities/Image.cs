using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Data.Entities
{
    public class Image : NameBaseEntity
	{
		public  Movie Movie { get; set; }
		public int MovieId { get; set; }
	}
}
