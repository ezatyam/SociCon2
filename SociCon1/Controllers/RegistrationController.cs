using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SociCon1.Data;
using SociCon1.Models;

namespace SociCon1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly DBConn _context;

        public RegistrationController(DBConn context)
        {
            _context = context;
        }

        // GET: api/Registration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBasicDetails>>> GetUserBasicDetails()
        {
            return await _context.UserBasicDetails.ToListAsync();
        }

        // GET: api/Registration/5
        [HttpGet("{UserName}/{password}")]
        public async Task<ActionResult<UserBasicDetails>> GetUserBasicDetails(string UserName, string password)
        {
            var userBasicDetails = await _context.UserBasicDetails.FirstOrDefaultAsync<UserBasicDetails>(a => a.UserName == UserName && a.Password==password);

            if (userBasicDetails == null)
            {
                return NotFound();
            }

            return userBasicDetails;
        }
        // GET: api/Registration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBasicDetails>> GetUserBasicDetails(int id)
        {
            var userBasicDetails = await _context.UserBasicDetails.FirstOrDefaultAsync<UserBasicDetails>(a => a.Id == id);

            if (userBasicDetails == null)
            {
                return NotFound();
            }

            return userBasicDetails;
        }
        // PUT: api/Registration/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBasicDetails(int id, UserBasicDetails userBasicDetails)
        {
            if (id != userBasicDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(userBasicDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBasicDetailsExists(id))
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

        // POST: api/Registration
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserBasicDetails>> PostUserBasicDetails(UserBasicDetails userBasicDetails)
        {
            _context.UserBasicDetails.Add(userBasicDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBasicDetails", new { id = userBasicDetails.Id }, userBasicDetails);
        }

        // DELETE: api/Registration/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserBasicDetails>> DeleteUserBasicDetails(int id)
        {
            var userBasicDetails = await _context.UserBasicDetails.FindAsync(id);
            if (userBasicDetails == null)
            {
                return NotFound(); 
            }

            _context.UserBasicDetails.Remove(userBasicDetails);
            await _context.SaveChangesAsync();

            return userBasicDetails;
        }

        private bool UserBasicDetailsExists(int id)
        {
            return _context.UserBasicDetails.Any(e => e.Id == id);
        }
    }
}
