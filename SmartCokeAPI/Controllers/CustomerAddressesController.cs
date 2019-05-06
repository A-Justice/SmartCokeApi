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
    public class CustomerAddressesController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public CustomerAddressesController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/CustomerAddresses
        [HttpGet]
        public IEnumerable<CustomerAddress> GetCustomerAddress()
        {
            return _context.CustomerAddress;
        }

        [HttpGet("findbycustid")]
        public IEnumerable<CustomerAddress> GetCustomerAddress(string id)
        {
            return _context.CustomerAddress.Where(a=>a.UserId == id);
        }

        // GET: api/CustomerAddresses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerAddress = await _context.CustomerAddress.FindAsync(id);

            if (customerAddress == null)
            {
                return NotFound();
            }

            return Ok(customerAddress);
        }

        // PUT: api/CustomerAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAddress([FromRoute] int id, [FromBody] CustomerAddress customerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAddressExists(id))
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

        // POST: api/CustomerAddresses
        [HttpPost]
        public async Task<IActionResult> PostCustomerAddress([FromBody] CustomerAddress customerAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CustomerAddress.Add(customerAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAddress", new { id = customerAddress.Id }, customerAddress);
        }

        // DELETE: api/CustomerAddresses/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerAddress(int id)
        {
            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }

            var customerAddress = await _context.CustomerAddress.FindAsync(id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            _context.CustomerAddress.Remove(customerAddress);
            await _context.SaveChangesAsync();

            return Ok(customerAddress);
        }

        private bool CustomerAddressExists(int id)
        {
            return _context.CustomerAddress.Any(e => e.Id == id);
        }
    }
}