
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellingOrdersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public SellingOrdersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellingOrder>>> GetSellingOrders()
        {
            var sellingOrders = await _context.SellingOrders
                .Include(x => x.IdEmployeeNavigation)
                .Include(x => x.IdProductsNavigation)
                .ToListAsync();

            return Ok(sellingOrders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SellingOrder>> GetSellingOrder(int id)
        {
            var sellingOrder = await _context.SellingOrders
                .Include(x => x.IdEmployeeNavigation)
                .Include(x => x.IdProductsNavigation)
                .FirstOrDefaultAsync(x => x.IdSellingOrder == id);

            if (sellingOrder == null)
            {
                return NotFound();
            }

            return Ok(sellingOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellingOrder(int id, SellingOrderUpdateDto sellingOrder)
        { 
            if (id != sellingOrder.IdSellingOrder) 
            { 
                return BadRequest(); 
            } 
            var existingOrder = await _context.SellingOrders.FirstOrDefaultAsync(x => x.IdSellingOrder == id); 
            if (existingOrder == null) 
            { 
                return NotFound();
            } 
            existingOrder.IdEmployee = sellingOrder.IdEmployee;
            existingOrder.IdProduct = sellingOrder.IdProduct;
            existingOrder.Quantity = sellingOrder.Quantity;
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}

