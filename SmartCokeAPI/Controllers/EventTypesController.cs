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
    public class EventTypesController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public EventTypesController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/EventTypes
        [HttpGet]
        public IEnumerable<EventType> GetEventType()
        {
            return _context.EventType;
        }

        // GET: api/EventTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventType = await _context.EventType.FindAsync(id);

            if (eventType == null)
            {
                return NotFound();
            }

            return Ok(eventType);
        }

        // PUT: api/EventTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventType([FromRoute] int id, [FromBody] EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventTypes
        [HttpPost]
        public async Task<IActionResult> PostEventType([FromBody] EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventType.Add(eventType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventType", new { id = eventType.Id }, eventType);
        }

        // DELETE: api/EventTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventType = await _context.EventType.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            _context.EventType.Remove(eventType);
            await _context.SaveChangesAsync();

            return Ok(eventType);
        }

        private bool EventTypeExists(int id)
        {
            return _context.EventType.Any(e => e.Id == id);
        }
    }
}