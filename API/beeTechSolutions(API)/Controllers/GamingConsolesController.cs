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

        // GET: api/GamingConsoles1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gaming_Console>>> GetgamingConsoles()
        {
            return await _context.Gaming_Console.ToListAsync();
        }

        // GET: api/GamingConsoles1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gaming_Console>> GetGamingConsole(int id)
        {
            var gamingConsole = await _context.Gaming_Console.FindAsync(id);

            if (gamingConsole == null)
            {
                return NotFound();
            }

            return gamingConsole;
        }

        // PUT: api/GamingConsoles1/5
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

        // POST: api/GamingConsoles1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gaming_Console>> PostGamingConsole(Gaming_Console gamingConsole)
        {
            _context.Gaming_Console.Add(gamingConsole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamingConsole", new { id = gamingConsole.gamingConsole_id }, gamingConsole);
        }

        // DELETE: api/GamingConsoles1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamingConsole(int id)
        {
            var gamingConsole = await _context.Gaming_Console.FindAsync(id);
            if (gamingConsole == null)
            {
                return NotFound();
            }

            _context.Gaming_Console.Remove(gamingConsole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamingConsoleExists(int id)
        {
            return _context.Gaming_Console.Any(e => e.gamingConsole_id == id);
        }
    }
}
