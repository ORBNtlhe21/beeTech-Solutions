using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using beeTechSolutions_API_.Data;
using beeTechSolutions_API_.Models;

namespace beeTechSolutions_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamingChairsController : ControllerBase
    {
        private readonly DBContext _context;

        public GamingChairsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/GamingChairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gaming_Chair>>> GetGamingChairs()
        {
            return await _context.Gaming_Chairs.ToListAsync();
        }

        //GET: api/GamingChairs/5
                [HttpGet("{id}")]
        public async Task<ActionResult<Gaming_Chair>> GetGamingChair(int id)
        {
            var gamingChair = await _context.Gaming_Chairs.FindAsync(id);

            if (gamingChair == null)
            {
                return NotFound("Gaming Chair Not Found");
            }

            return gamingChair;
        }

        // PUT: api/GamingChairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamingChair(int id, Gaming_Chair gamingChair)
        {
            if (id != gamingChair.gamingChair_id)
            {
                return BadRequest();
            }

            _context.Entry(gamingChair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamingChairExists(id))
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

        // POST: api/GamingChairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gaming_Chair>> PostGamingChair(Gaming_Chair gamingChair)
        {
            _context.Gaming_Chairs.Add(gamingChair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamingChair", new { id = gamingChair.gamingChair_id }, gamingChair);
        }

        // DELETE: api/GamingChairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamingChair(int id)
        {
            var gamingChair = await _context.Gaming_Chairs.FindAsync(id);
            if (gamingChair == null)
            {
                return NotFound();
            }

            _context.Gaming_Chairs.Remove(gamingChair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamingChairExists(int id)
        {
            return _context.Gaming_Chairs.Any(e => e.gamingChair_id == id);
        }
    }
}
