using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products
               
               // .Where(p => p.UnitPrice > 200)
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.SupplierId,
                    p.CategoryId,
                    p.QuantityPerUnit,
                    p.UnitPrice,
                    p.UnitsInStock,
                    p.UnitsOnOrder,
                    p.ReorderLevel,
                    p.Discontinued,
                    CategoryName = p.Category != null
                        ? p.Category.CategoryName
                        : null,
                    SupplierName = p.Supplier != null
                        ? p.Supplier.CompanyName
                        : null,



                })
                .ToListAsync();

            return Ok(products);
        }
    }
}
