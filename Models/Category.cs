using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class Category
	{
		[Key]
		public int idCategory { get; set; }
		public string categoryName { get; set; }

		public virtual ICollection<CategoryPicture> categoryPictures { get; set; }
	}
}
