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
    public class ComolaintsController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public ComolaintsController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/Comolaints
        [HttpGet]
        public IEnumerable<Comolaints> GetComolaints()
        {
            return _context.Comolaints;
        }

        // GET: api/Comolaints/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComolaints([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comolaints = await _context.Comolaints.FindAsync(id);

            if (comolaints == null)
            {
                return NotFound();
            }

            return Ok(comolaints);
        }

        // PUT: api/Comolaints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComolaints([FromRoute] int id, [FromBody] Comolaints comolaints)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comolaints.Id)
            {
                return BadRequest();
            }

            _context.Entry(comolaints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComolaintsExists(id))
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

        // POST: api/Comolaints
        [HttpPost]
        public async Task<IActionResult> PostComolaints([FromBody] Comolaints comolaints)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comolaints.Add(comolaints);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComolaints", new { id = comolaints.Id }, comolaints);
        }

        // DELETE: api/Comolaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComolaints([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comolaints = await _context.Comolaints.FindAsync(id);
            if (comolaints == null)
            {
                return NotFound();
            }

            _context.Comolaints.Remove(comolaints);
            await _context.SaveChangesAsync();

            return Ok(comolaints);
        }

        private bool ComolaintsExists(int id)
        {
            return _context.Comolaints.Any(e => e.Id == id);
        }
    }
}