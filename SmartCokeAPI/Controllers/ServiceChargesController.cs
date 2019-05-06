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
    public class ServiceChargesController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public ServiceChargesController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCharges
        [HttpGet]
        public IEnumerable<ServiceCharge> GetServiceCharge()
        {
            return _context.ServiceCharge;
        }

        // GET: api/ServiceCharges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceCharge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceCharge = await _context.ServiceCharge.FindAsync(id);

            if (serviceCharge == null)
            {
                return NotFound();
            }

            return Ok(serviceCharge);
        }

        // PUT: api/ServiceCharges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceCharge([FromRoute] int id, [FromBody] ServiceCharge serviceCharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceCharge.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceCharge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceChargeExists(id))
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

        // POST: api/ServiceCharges
        [HttpPost]
        public async Task<IActionResult> PostServiceCharge([FromBody] ServiceCharge serviceCharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ServiceCharge.Add(serviceCharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceCharge", new { id = serviceCharge.Id }, serviceCharge);
        }

        // DELETE: api/ServiceCharges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCharge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceCharge = await _context.ServiceCharge.FindAsync(id);
            if (serviceCharge == null)
            {
                return NotFound();
            }

            _context.ServiceCharge.Remove(serviceCharge);
            await _context.SaveChangesAsync();

            return Ok(serviceCharge);
        }

        private bool ServiceChargeExists(int id)
        {
            return _context.ServiceCharge.Any(e => e.Id == id);
        }
    }
}