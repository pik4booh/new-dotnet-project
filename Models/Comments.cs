using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Comments
	{
		[Key]
		public int idComment { get; set; }
		public int idUser { get; set; }
		public int idPicture { get; set; }
		public string comment { get; set; }


		public virtual Picture picture { get; set; }
		public virtual User User { get; set; }
	}
}
