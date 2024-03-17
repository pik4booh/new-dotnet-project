using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace WebApplication1.Models.DTO
{
	public class UserSignInDTO
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
