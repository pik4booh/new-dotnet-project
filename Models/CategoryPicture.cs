using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	public class CategoryPicture
	{
		[Key]
		public int idCategoryPicture { get; set; }
		public int idCategory { get; set; }
		public int idPicture { get; set; }

		public virtual Picture picture { get; set; }
		public virtual Category category { get; set; }
	}
}
