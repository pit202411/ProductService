using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly NorthwindContext _context;
       
       public ClientsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.
                Select(c => new
                {
                    c.CustomerId,
                    c.CompanyName,
                    c.ContactName,
                    c.ContactTitle,
                    c.Address,
                    c.City,
                    c.Region,
                    c.PostalCode,
                    c.Country,
                    c.Phone,
                    c.Fax,
                    OrderId = c.Orders
        .Select(o => o.OrderId)
        .FirstOrDefault(),
                    OrderDate = c.Orders
        .Select(o => o.OrderDate)
        .FirstOrDefault(),

                    Freight = c.Orders
        .Select(o => o.Freight)
        .FirstOrDefault()
                }).
                    // Where(p => p.UnitPrice > 200).

                    ToListAsync();

            return Ok(customers);
        }
    }
}
