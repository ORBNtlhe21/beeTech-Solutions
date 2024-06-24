﻿using System;
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

        // GET: api/GamingConsoles1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamingConsole>>> GetgamingConsoles()
        {
            return await _context.GamingConsoles.ToListAsync();
        }

        // GET: api/GamingConsoles1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamingConsole>> GetGamingConsole(int id)
        {
            var gamingConsole = await _context.GamingConsoles.FindAsync(id);

            if (gamingConsole == null)
            {
                return NotFound();
            }

            return gamingConsole;
        }

        // PUT: api/GamingConsoles1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamingConsole(int id, GamingConsole gamingConsole)
        {
            if (id != gamingConsole.GamingConsoleId)
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
        public async Task<ActionResult<GamingConsole>> PostGamingConsole(GamingConsole gamingConsole)
        {
            _context.GamingConsoles.Add(gamingConsole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamingConsole", new { id = gamingConsole.GamingConsoleId }, gamingConsole);
        }

        // DELETE: api/GamingConsoles1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamingConsole(int id)
        {
            var gamingConsole = await _context.GamingConsoles.FindAsync(id);
            if (gamingConsole == null)
            {
                return NotFound();
            }

            _context.GamingConsoles.Remove(gamingConsole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamingConsoleExists(int id)
        {
            return _context.GamingConsoles.Any(e => e.GamingConsoleId == id);
        }
    }
}
