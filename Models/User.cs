
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

		//Navigation Property
		[JsonIgnore]
		public virtual ICollection<Picture> pictures { get; set; }
		[JsonIgnore]
		public virtual ICollection<Like> likes { get; set; }
		public virtual ICollection<Comments> comments { get; set; }
	}
}
