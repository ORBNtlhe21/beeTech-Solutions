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
    public class GamingConsolesController : ControllerBase
    {
        private readonly DBContext _context;

        public GamingConsolesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/GamingConsoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gaming_Console>>> GetGamingConsoles()
        {
            return await _context.Gaming_Consoles.ToListAsync();
        }

        // GET: api/GamingConsoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gaming_Console>> GetGamingConsole(int id)
        {
            var gamingConsole = await _context.Gaming_Consoles.FindAsync(id);

            if (gamingConsole == null)
            {
                return NotFound();
            }

            return gamingConsole;
        }

        // PUT: api/GamingConsoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamingConsole(int id, Gaming_Console gamingConsole)
        {
            if (id != gamingConsole.gamingConsole_id)
            {
                return BadRequest();
            }

            _context.Entry(gamingConsole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamingConsoleExists(id))
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

        // POST: api/GamingConsoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gaming_Console>> PostGamingConsole(Gaming_Console gamingConsole)
        {
            _context.Gaming_Consoles.Add(gamingConsole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamingConsole", new { id = gamingConsole.gamingConsole_id }, gamingConsole);
        }

        // DELETE: api/GamingConsoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamingConsole(int id)
        {
            var gamingConsole = await _context.Gaming_Consoles.FindAsync(id);
            if (gamingConsole == null)
            {
                return NotFound();
            }

            _context.Gaming_Consoles.Remove(gamingConsole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamingConsoleExists(int id)
        {
            return _context.Gaming_Consoles.Any(e => e.gamingConsole_id == id);
        }
    }
}
