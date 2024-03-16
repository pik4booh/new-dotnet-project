namespace WebApplication1.Models.DTO
{
	public class UserDTO
	{
		public string email { get; set; }
		public string pwd { get; set; }

		public User toUser()
		{
			User user = new User
			{
				email = email,
				pwd = pwd
			};
			return user;
		}
	}

}
