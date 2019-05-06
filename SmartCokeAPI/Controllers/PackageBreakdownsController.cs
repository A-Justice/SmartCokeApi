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
    public class PackageBreakdownsController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public PackageBreakdownsController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/PackageBreakdowns
        [HttpGet]
        public IEnumerable<PackageBreakdown> GetPackageBreakdown()
        {
            return _context.PackageBreakdown;
        }

        // GET: api/PackageBreakdowns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageBreakdown([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var packageBreakdown = await _context.PackageBreakdown.FindAsync(id);

            if (packageBreakdown == null)
            {
                return NotFound();
            }

            return Ok(packageBreakdown);
        }

        // PUT: api/PackageBreakdowns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageBreakdown([FromRoute] int id, [FromBody] PackageBreakdown packageBreakdown)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != packageBreakdown.Id)
            {
                return BadRequest();
            }

            _context.Entry(packageBreakdown).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageBreakdownExists(id))
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

        // POST: api/PackageBreakdowns
        [HttpPost]
        public async Task<IActionResult> PostPackageBreakdown([FromBody] PackageBreakdown packageBreakdown)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PackageBreakdown.Add(packageBreakdown);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageBreakdown", new { id = packageBreakdown.Id }, packageBreakdown);
        }

        // DELETE: api/PackageBreakdowns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageBreakdown([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var packageBreakdown = await _context.PackageBreakdown.FindAsync(id);
            if (packageBreakdown == null)
            {
                return NotFound();
            }

            _context.PackageBreakdown.Remove(packageBreakdown);
            await _context.SaveChangesAsync();

            return Ok(packageBreakdown);
        }

        private bool PackageBreakdownExists(int id)
        {
            return _context.PackageBreakdown.Any(e => e.Id == id);
        }
    }
}