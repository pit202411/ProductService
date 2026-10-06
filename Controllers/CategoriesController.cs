using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories.
                // Where(p => p.UnitPrice > 200).

                ToListAsync();

            return Ok(categories);
        }
    }
}
