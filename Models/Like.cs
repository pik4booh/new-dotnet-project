using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
	public class Like
	{
		[Key]
		public int idLike { get; set; }
		public int idUser { get; set; }
		public int idPicture { get; set; }

		[JsonIgnore]
		public virtual Picture picture { get; set; }
		[JsonIgnore]
		public virtual User user { get; set; }
	}
}
