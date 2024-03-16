namespace WebApplication1.Models.DTO
{
	public class UserRegisterDto
	{
		public string pseudo { get; set; }
		public string email { get; set; }
		public string pwd { get; set; }
		public string bio { get; set; }
		public string pdpPath { get; set; }
		public User toUser()
		{
			User user = new User
			{
				pseudo = pseudo,
				email = email,
				pwd = pwd,
				bio = bio,
				pdpPath = "default.jpg"
			};
			return user;
		}
	}
}
