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
    public class DistributorsController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public DistributorsController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/Distributors
        [HttpGet]
        public IEnumerable<Distributors> GetDistributors()
        {
            return _context.Distributors;
        }

        // GET: api/Distributors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistributors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var distributors = await _context.Distributors.FindAsync(id);

            if (distributors == null)
            {
                return NotFound();
            }

            return Ok(distributors);
        }

        // PUT: api/Distributors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributors([FromRoute] int id, [FromBody] Distributors distributors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distributors.Id)
            {
                return BadRequest();
            }

            _context.Entry(distributors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributorsExists(id))
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

        // POST: api/Distributors
        [HttpPost]
        public async Task<IActionResult> PostDistributors([FromBody] Distributors distributors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Distributors.Add(distributors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistributors", new { id = distributors.Id }, distributors);
        }

        // DELETE: api/Distributors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var distributors = await _context.Distributors.FindAsync(id);
            if (distributors == null)
            {
                return NotFound();
            }

            _context.Distributors.Remove(distributors);
            await _context.SaveChangesAsync();

            return Ok(distributors);
        }

        private bool DistributorsExists(int id)
        {
            return _context.Distributors.Any(e => e.Id == id);
        }
    }
}