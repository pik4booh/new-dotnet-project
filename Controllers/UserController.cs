using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly apiContext _context;

		public UserController(apiContext context)
		{
			_context = context;
		}

		[HttpPost("signin")]
		public IActionResult SignIn([FromBody] User user)
		{
			User users = _context.Users.FirstOrDefault(u => u.email == user.email && u.pwd == user.pwd);
			if (users == null)
			{
				return Unauthorized("Invalid credentials");
			}
			return Ok(users);
		}

		[HttpPost("signup")]
		public IActionResult SignUp(string email, string password, string bio, string pseudo)
		{
			try
			{
				var user = _context.Users.FirstOrDefault(u => u.email == email);
				if (user != null)
				{
					return BadRequest("User already exists");
				}
				user = new User
				{
					email = email,
					pseudo = pseudo,
					bio = bio,
					pdpPath = "none",
					pwd = password
				};
				_context.Users.Add(user);
				_context.SaveChanges();
				return Ok(user);

			}
			catch(Exception e)
			{
				return BadRequest(e.Message);
			}

			
		}	

	}


}
