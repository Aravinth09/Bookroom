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
    public class RoomtypeController : ControllerBase
    {
        private readonly BookroomContext _context;

        public RoomtypeController(BookroomContext context)
        {
            _context = context;
        }

        // GET: api/Roomtype
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roomtype>>> GetRoomtypes()
        {
            return await _context.Roomtypes.ToListAsync();
        }

        // GET: api/Roomtype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Roomtype>> GetRoomtype(int id)
        {
            var roomtype = await _context.Roomtypes.FindAsync(id);

            if (roomtype == null)
            {
                return NotFound();
            }

            return roomtype;
        }

        // PUT: api/Roomtype/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomtype(int id, Roomtype roomtype)
        {
            if (id != roomtype.RoomtypeId)
            {
                return BadRequest();
            }

            _context.Entry(roomtype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomtypeExists(id))
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

        // POST: api/Roomtype
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Roomtype>> PostRoomtype(Roomtype roomtype)
        {
            _context.Roomtypes.Add(roomtype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomtype", new { id = roomtype.RoomtypeId }, roomtype);
        }

        // DELETE: api/Roomtype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomtype(int id)
        {
            var roomtype = await _context.Roomtypes.FindAsync(id);
            if (roomtype == null)
            {
                return NotFound();
            }

            _context.Roomtypes.Remove(roomtype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomtypeExists(int id)
        {
            return _context.Roomtypes.Any(e => e.RoomtypeId == id);
        }
    }
}
