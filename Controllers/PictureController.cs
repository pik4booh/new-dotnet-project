using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PictureController : ControllerBase
	{
		private readonly apiContext _context;
		public PictureController(apiContext context)
		{
			_context = context;
		}

		[HttpGet("categories")]
		public IActionResult getCategories()
		{
			try
			{
				List<Category> categories = _context.Category.ToList();
				categories.ForEach(c => c.categoryPictures = null);
				return Ok(categories);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
		[HttpPost("upload")]
		public IActionResult uploadPicture([FromBody] PictureDTO picture)
		{
			try
			{
				_context.Picture.Add(picture.toPicture());
				_context.SaveChanges();
				return Ok(picture);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		
	}
}
