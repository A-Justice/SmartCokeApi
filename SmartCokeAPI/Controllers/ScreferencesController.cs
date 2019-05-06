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
    public class ScreferencesController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public ScreferencesController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/Screferences
        [HttpGet]
        public IEnumerable<Screference> GetScreference()
        {
            return _context.Screference;
        }

        // GET: api/Screferences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreference([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var screference = await _context.Screference.FindAsync(id);

            if (screference == null)
            {
                return NotFound();
            }

            return Ok(screference);
        }

        // PUT: api/Screferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScreference([FromRoute] int id, [FromBody] Screference screference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != screference.Id)
            {
                return BadRequest();
            }

            _context.Entry(screference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScreferenceExists(id))
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

        // POST: api/Screferences
        [HttpPost]
        public async Task<IActionResult> PostScreference([FromBody] Screference screference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Screference.Add(screference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScreference", new { id = screference.Id }, screference);
        }

        // DELETE: api/Screferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreference([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var screference = await _context.Screference.FindAsync(id);
            if (screference == null)
            {
                return NotFound();
            }

            _context.Screference.Remove(screference);
            await _context.SaveChangesAsync();

            return Ok(screference);
        }

        private bool ScreferenceExists(int id)
        {
            return _context.Screference.Any(e => e.Id == id);
        }
    }
}