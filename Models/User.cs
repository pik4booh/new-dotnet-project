using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class User
	{
		[Key]
		public int idUser { get; set; }
		public string pseudo  { get; set; }
		public string email { get; set; }
		public string pwd { get; set; }
		public string bio { get; set; }
		public string pdpPath { get; set; }

		public virtual ICollection<Picture> pictures { get; set; }
		public virtual ICollection<Like> likes { get; set; }
		public virtual ICollection<Comments> comments { get; set; }
	}
}
