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
    public class BookingorderController : ControllerBase
    {
        private readonly BookroomContext _context;

        public BookingorderController(BookroomContext context)
        {
            _context = context;
        }

        // GET: api/Bookingorder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookingorder>>> GetBookingorder()
        {
            return await _context.Bookingorder.ToListAsync();
        }

        // GET: api/Bookingorder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookingorder>> GetBookingorder(int id)
        {
            var bookingorder = await _context.Bookingorder.FindAsync(id);

            if (bookingorder == null)
            {
                return NotFound();
            }

            return bookingorder;
        }

        // PUT: api/Bookingorder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingorder(int id, Bookingorder bookingorder)
        {
            if (id != bookingorder.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(bookingorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingorderExists(id))
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

        // POST: api/Bookingorder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookingorder>> PostBookingorder(Bookingorder bookingorder)
        {
            _context.Bookingorder.Add(bookingorder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingorderExists(bookingorder.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingorder", new { id = bookingorder.OrderId }, bookingorder);
        }

        // DELETE: api/Bookingorder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingorder(int id)
        {
            var bookingorder = await _context.Bookingorder.FindAsync(id);
            if (bookingorder == null)
            {
                return NotFound();
            }

            _context.Bookingorder.Remove(bookingorder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingorderExists(int id)
        {
            return _context.Bookingorder.Any(e => e.OrderId == id);
        }
    }
}
