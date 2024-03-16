using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

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
	}
}
