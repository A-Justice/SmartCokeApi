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
    public class PackSizesController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public PackSizesController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/Models.PackSizes
        [HttpGet]
        public IEnumerable<Models.PackSizes> GetPackSizes()
        {
            return _context.PackSizes;
        }

        // GET: api/Models.PackSizes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackSizes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var packSizes = await _context.PackSizes.FindAsync(id);

            if (packSizes == null)
            {
                return NotFound();
            }

            return Ok(packSizes);
        }

        // PUT: api/Models.PackSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackSizes([FromRoute] int id, [FromBody] Models.PackSizes packSizes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != packSizes.Id)
            {
                return BadRequest();
            }

            _context.Entry(packSizes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackSizesExists(id))
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

        // POST: api/Models.PackSizes
        [HttpPost]
        public async Task<IActionResult> PostPackSizes([FromBody] Models.PackSizes packSizes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PackSizes.Add(packSizes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackSizes", new { id = packSizes.Id }, packSizes);
        }

        // DELETE: api/Models.PackSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackSizes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var packSizes = await _context.PackSizes.FindAsync(id);
            if (packSizes == null)
            {
                return NotFound();
            }

            _context.PackSizes.Remove(packSizes);
            await _context.SaveChangesAsync();

            return Ok(packSizes);
        }

        private bool PackSizesExists(int id)
        {
            return _context.PackSizes.Any(e => e.Id == id);
        }
    }
}