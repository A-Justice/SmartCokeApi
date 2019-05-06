using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartCokeAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartCokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly SmartCokeContext _context;

        public CustomerDetailsController(SmartCokeContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        public IEnumerable<CustomerDetails> GetCustomerDetails()
        {
            return _context.CustomerDetails;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDetails loginDetails)
        {

            var hashedPassword = GetSwcSHA1(loginDetails.Password);



            var customerDetails = _context.CustomerDetails.Where(c => c.Email == loginDetails.Email && c.Password == hashedPassword).FirstOrDefault();

            if (customerDetails == null)
            {
                return BadRequest("Invalid Crendentials");
            }

            return Ok(customerDetails);
        }


        // GET: api/CustomerDetails/5
        [HttpGet("findbyid/{id}")]
        public async Task<IActionResult> GetCustomerDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetails = await _context.CustomerDetails.FindAsync(id);

            if (customerDetails == null)
            {
                return NotFound();
            }

            return Ok(customerDetails);
        }



        // PUT: api/CustomerDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetails([FromRoute] int id, [FromBody] CustomerDetails customerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailsExists(id))
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


        // POST: api/CustomerDetails
        [HttpPost]
        public async Task<IActionResult> PostCustomerDetails([FromBody] CustomerDetails customerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.CustomerDetails.Where(i => i.Email == customerDetails.Email).Count() > 0)
            {
                return BadRequest("User Already Exists");
            }
            customerDetails.PhoneNum = GetFormattedPhoneNumber(customerDetails.PhoneNum);
            customerDetails.Password = GetSwcSHA1(customerDetails.Password);

            _context.CustomerDetails.Add(customerDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerDetails", new { id = customerDetails.Id }, customerDetails);
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerDetails = await _context.CustomerDetails.FindAsync(id);
            if (customerDetails == null)
            {
                return NotFound();
            }

            _context.CustomerDetails.Remove(customerDetails);
            await _context.SaveChangesAsync();

            return Ok(customerDetails);
        }

        private bool CustomerDetailsExists(int id)
        {
            return _context.CustomerDetails.Any(e => e.Id == id);
        }

        public string GetSwcSHA1(string value)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }

        public string GetFormattedPhoneNumber(string phone)
        {
            if (phone != null && phone.Trim().Length == 10)
                return "233"+ phone.Substring(1,9);
            return phone;
        }
    }

    public class LoginDetails
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}