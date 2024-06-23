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
    public class DesktopsController : ControllerBase
    {
        private readonly DBContext _context;

        public DesktopsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Desktops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desktop>>> GetDesktops()
        {
            return await _context.Desktops.ToListAsync();
        }

        // GET: api/Desktops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desktop>> GetDesktop(int id)
        {
            var desktop = await _context.Desktops.FindAsync(id);

            if (desktop == null)
            {
                return NotFound("Desktop Not Found");
            }

            return desktop;
        }

        // PUT: api/Desktops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesktop(int id, Desktop desktop)
        {
            if (id != desktop.desktop_id)
            {
                return BadRequest();
            }

            _context.Entry(desktop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesktopExists(id))
                {
                    return NotFound("Desktop Not Found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Desktops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Desktop>> PostDesktop(Desktop desktop)
        {
            _context.Desktops.Add(desktop);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesktop", new { id = desktop.desktop_id }, desktop);
        }

        // DELETE: api/Desktops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesktop(int id)
        {
            var desktop = await _context.Desktops.FindAsync(id);
            if (desktop == null)
            {
                return NotFound();
            }

            _context.Desktops.Remove(desktop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesktopExists(int id)
        {
            return _context.Desktops.Any(e => e.desktop_id == id);
        }
    }
}
