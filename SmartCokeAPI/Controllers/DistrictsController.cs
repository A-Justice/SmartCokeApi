﻿using System;
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
    public class DistrictsController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public DistrictsController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/Districts
        [HttpGet]
        public IEnumerable<District> GetDistrict()
        {
            return _context.District;
        }

        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistrict([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var district = await _context.District.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return Ok(district);
        }

        // PUT: api/Districts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrict([FromRoute] int id, [FromBody] District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != district.Id)
            {
                return BadRequest();
            }

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
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

        // POST: api/Districts
        [HttpPost]
        public async Task<IActionResult> PostDistrict([FromBody] District district)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.District.Add(district);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistrict", new { id = district.Id }, district);
        }

        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var district = await _context.District.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.District.Remove(district);
            await _context.SaveChangesAsync();

            return Ok(district);
        }

        private bool DistrictExists(int id)
        {
            return _context.District.Any(e => e.Id == id);
        }
    }
}