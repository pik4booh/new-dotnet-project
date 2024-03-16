using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Like
	{
		[Key]
		public int idLike { get; set; }
		public int idUser { get; set; }
		public int idPicture { get; set; }

		public virtual Picture picture { get; set; }
		public virtual User user { get; set; }
	}
}
