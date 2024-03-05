using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookroom.Models;

namespace Bookroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly BookroomContext _context;

        public RentController(BookroomContext context)
        {
            _context = context;
        }

        // GET: api/Rent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetRents()
        {
            return await _context.Rents.ToListAsync();
        }

        // GET: api/Rent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRent(string id)
        {
            var rent = await _context.Rents.FindAsync(id);

            if (rent == null)
            {
                return NotFound();
            }

            return rent;
        }

        // PUT: api/Rent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(string id, Rent rent)
        {
            if (id != rent.PriceId)
            {
                return BadRequest();
            }

            _context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent>> PostRent(Rent rent)
        {
            _context.Rents.Add(rent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RentExists(rent.PriceId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRent", new { id = rent.PriceId }, rent);
        }

        // DELETE: api/Rent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(string id)
        {
            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentExists(string id)
        {
            return _context.Rents.Any(e => e.PriceId == id);
        }
    }
}
