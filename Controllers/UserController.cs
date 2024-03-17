using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

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
		public IActionResult SignIn([FromBody] UserSignInDTO userdto)
		{
			User users = _context.Users.FirstOrDefault(u => u.email == userdto.email && u.pwd == userdto.pwd);
			if (users == null)
			{
				return Unauthorized("Invalid credentials");
			}
		
			string id = users.idUser.ToString();
            UserDTO userDTO = new UserDTO
            {
                idUser = id,
                pseudo = users.pseudo,
                email = users.email,
                bio = users.bio,
                pdpPath = users.pdpPath
            };
            return Ok(new object [] { userDTO, "Status : Success" });
		}

		[HttpPost("signup")]
		public IActionResult SignUp([FromBody] UserRegisterDto userToRegister)
		{
			try
			{
				var user = _context.Users.FirstOrDefault(u => u.email == userToRegister.email);
				if (user != null)
				{
					return BadRequest("User already exists");
				}
				user = userToRegister.toUser();
				
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
