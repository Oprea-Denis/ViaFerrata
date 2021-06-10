using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViaFerrata.Data;
using ViaFerrata.Models;

namespace ViaFerrata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DificultateController : ControllerBase
    {
        private readonly ViaFerrataContext _context;

        public DificultateController(ViaFerrataContext context)
        {
            _context = context;
        }

        // GET: api/Dificultate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dificultate>>> GetDificultate()
        {
            return await _context.Dificultate.ToListAsync();
        }

        // GET: api/Dificultate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dificultate>> GetDificultate(Guid id)
        {
            var dificultate = await _context.Dificultate.FindAsync(id);

            if (dificultate == null)
            {
                return NotFound();
            }

            return dificultate;
        }

        // PUT: api/Dificultate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDificultate(Guid id, Dificultate dificultate)
        {
            if (id != dificultate.ID)
            {
                return BadRequest();
            }

            _context.Entry(dificultate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DificultateExists(id))
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

        // POST: api/Dificultate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dificultate>> PostDificultate(Dificultate dificultate)
        {
            _context.Dificultate.Add(dificultate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDificultate", new { id = dificultate.ID }, dificultate);
        }

        // DELETE: api/Dificultate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDificultate(Guid id)
        {
            var dificultate = await _context.Dificultate.FindAsync(id);
            if (dificultate == null)
            {
                return NotFound();
            }

            _context.Dificultate.Remove(dificultate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DificultateExists(Guid id)
        {
            return _context.Dificultate.Any(e => e.ID == id);
        }
    }
}
