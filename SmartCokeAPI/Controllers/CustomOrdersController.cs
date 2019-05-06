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
    public class CustomOrdersController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public CustomOrdersController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/CustomOrders
        [HttpGet]
        public IEnumerable<CustomOrders> GetCustomOrders()
        {
            return _context.CustomOrders;
        }

        // GET: api/CustomOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customOrders = await _context.CustomOrders.FindAsync(id);

            if (customOrders == null)
            {
                return NotFound();
            }

            return Ok(customOrders);
        }


        [HttpGet("findbyorderid")]
        public IEnumerable<CustomOrders> GetCustomOrdersForOrder(string orderId)
        {
            return _context.CustomOrders.Where(i=>i.OrderId == orderId);
        }

        // PUT: api/CustomOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomOrders([FromRoute] int id, [FromBody] CustomOrders customOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(customOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomOrdersExists(id))
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

        // POST: api/CustomOrders
        [HttpPost]
        public async Task<IActionResult> PostCustomOrders([FromBody] CustomOrders customOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomOrders.Add(customOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomOrders", new { id = customOrders.Id }, customOrders);
        }

        // POST: api/CustomOrders
        [HttpPost("fororder")]
        public async Task<IActionResult> PostCustomOrders([FromBody] List<CustomOrders> customOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (var customOrder in customOrders)
            {
               // _context.CustomOrders.AddRange(customOrders);
               customOrder.DateLogged = DateTime.Now;
                _context.CustomOrders.Add(customOrder);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomOrders", customOrders);
        }

        // DELETE: api/CustomOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customOrders = await _context.CustomOrders.FindAsync(id);
            if (customOrders == null)
            {
                return NotFound();
            }

            _context.CustomOrders.Remove(customOrders);
            await _context.SaveChangesAsync();

            return Ok(customOrders);
        }

        private bool CustomOrdersExists(int id)
        {
            return _context.CustomOrders.Any(e => e.Id == id);
        }
    }
}