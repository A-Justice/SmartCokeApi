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
    public class EventSizesController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public EventSizesController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/EventSizes
        [HttpGet]
        public IEnumerable<EventSize> GetEventSize()
        {
            return _context.EventSize;
        }

        // GET: api/EventSizes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventSize([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventSize = await _context.EventSize.FindAsync(id);

            if (eventSize == null)
            {
                return NotFound();
            }

            return Ok(eventSize);
        }

        // PUT: api/EventSizes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventSize([FromRoute] int id, [FromBody] EventSize eventSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventSize.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventSize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventSizeExists(id))
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

        // POST: api/EventSizes
        [HttpPost]
        public async Task<IActionResult> PostEventSize([FromBody] EventSize eventSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventSize.Add(eventSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventSize", new { id = eventSize.Id }, eventSize);
        }

        // DELETE: api/EventSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventSize([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventSize = await _context.EventSize.FindAsync(id);
            if (eventSize == null)
            {
                return NotFound();
            }

            _context.EventSize.Remove(eventSize);
            await _context.SaveChangesAsync();

            return Ok(eventSize);
        }

        private bool EventSizeExists(int id)
        {
            return _context.EventSize.Any(e => e.Id == id);
        }
    }
}