using Crud_Back.Data;
using Crud_Back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly CrudDbContext _context;
        public ProductController(CrudDbContext crudDb)
        {
            _context = crudDb;
        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetAllProduct()
        {
            var prod = await _context.Products.ToListAsync();
            return Ok(prod);

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();
            // product.Id = Guid.NewGuid();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] string id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(x => x.Id== id);
            return Ok(prod);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] string id, Product updateProd)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            product.Id = updateProd.Id;
            product.Name = updateProd.Name;
            product.Price = updateProd.Price;
            await _context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] string id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound(); 
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

    }
}
