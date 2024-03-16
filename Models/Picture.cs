using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Picture
	{
		[Key]
		public int idPicture { get; set; }
		public string title { get; set; }
		public string picturePath { get; set; }
		public int idUser { get; set; }
		public string description { get; set; }
		public int views { get; set; }
		public virtual User user { get; set; }

		public virtual ICollection<CategoryPicture> categoryPictures { get; set; }

		public virtual ICollection<Like> likes { get; set; }
		public virtual ICollection<Comments> comments { get; set; }
	}
}
