using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCokeAPI.Models;

namespace SmartCokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomProductsController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public CustomProductsController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/CustomProducts
        [HttpGet]
        public IEnumerable<CustomProducts> GetCustomProducts()
        {
            return _context.CustomProducts;
        }

        // GET: api/CustomProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customProducts = await _context.CustomProducts.FindAsync(id);

            if (customProducts == null)
            {
                return NotFound();
            }

            return Ok(customProducts);
        }

        // PUT: api/CustomProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomProducts([FromRoute] int id, [FromBody] CustomProducts customProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customProducts.Id)
            {
                return BadRequest();
            }

            _context.Entry(customProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomProducts
        [HttpPost]
        public async Task<IActionResult> PostCustomProducts([FromBody] CustomProducts customProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomProducts.Add(customProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomProducts", new { id = customProducts.Id }, customProducts);
        }

        // DELETE: api/CustomProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customProducts = await _context.CustomProducts.FindAsync(id);
            if (customProducts == null)
            {
                return NotFound();
            }

            _context.CustomProducts.Remove(customProducts);
            await _context.SaveChangesAsync();

            return Ok(customProducts);
        }

        private bool CustomProductsExists(int id)
        {
            return _context.CustomProducts.Any(e => e.Id == id);
        }
    }
}