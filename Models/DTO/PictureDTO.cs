namespace WebApplication1.Models.DTO
{
	public class PictureDTO
	{
		public string title { get; set; }
		public string image {  get; set; }
		public string picturePath { get; set; }
		public int idUser { get; set; }
		public string description { get; set; }
		public int views { get; set; }

		public Picture toPicture()
		{
			return new Picture
			{
				title = this.title,
				picturePath = this.picturePath,
				idUser = this.idUser,
				description = this.description,
				views = this.views
			};
		}
	}
}
