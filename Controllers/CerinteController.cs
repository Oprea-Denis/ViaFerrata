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
    public class CerinteController : ControllerBase
    {
        private readonly ViaFerrataContext _context;

        public CerinteController(ViaFerrataContext context)
        {
            _context = context;
        }

        // GET: api/Cerinte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cerinte>>> GetCerinte()
        {
            return await _context.Cerinte.ToListAsync();
        }

        // GET: api/Cerinte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cerinte>> GetCerinte(Guid id)
        {
            var cerinte = await _context.Cerinte.FindAsync(id);

            if (cerinte == null)
            {
                return NotFound();
            }

            return cerinte;
        }

        // PUT: api/Cerinte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCerinte(Guid id, Cerinte cerinte)
        {
            if (id != cerinte.ID)
            {
                return BadRequest();
            }

            _context.Entry(cerinte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CerinteExists(id))
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

        // POST: api/Cerinte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cerinte>> PostCerinte(Cerinte cerinte)
        {
            _context.Cerinte.Add(cerinte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCerinte", new { id = cerinte.ID }, cerinte);
        }

        // DELETE: api/Cerinte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCerinte(Guid id)
        {
            var cerinte = await _context.Cerinte.FindAsync(id);
            if (cerinte == null)
            {
                return NotFound();
            }

            _context.Cerinte.Remove(cerinte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CerinteExists(Guid id)
        {
            return _context.Cerinte.Any(e => e.ID == id);
        }
    }
}
