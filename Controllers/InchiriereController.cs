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
    public class InchiriereController : ControllerBase
    {
        private readonly ViaFerrataContext _context;

        public InchiriereController(ViaFerrataContext context)
        {
            _context = context;
        }

        // GET: api/Inchiriere
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inchiriere>>> GetInchiriere()
        {
            return await _context.Inchiriere.ToListAsync();
        }

        // GET: api/Inchiriere/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inchiriere>> GetInchiriere(Guid id)
        {
            var inchiriere = await _context.Inchiriere.FindAsync(id);

            if (inchiriere == null)
            {
                return NotFound();
            }

            return inchiriere;
        }

        // PUT: api/Inchiriere/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInchiriere(Guid id, Inchiriere inchiriere)
        {
            if (id != inchiriere.ID)
            {
                return BadRequest();
            }

            _context.Entry(inchiriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InchiriereExists(id))
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

        // POST: api/Inchiriere
        [HttpPost]
        public async Task<ActionResult<Inchiriere>> PostInchiriere(Inchiriere inchiriere)
        {
            _context.Inchiriere.Add(inchiriere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInchiriere", new { id = inchiriere.ID }, inchiriere);
        }

        // DELETE: api/Inchiriere/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInchiriere(Guid id)
        {
            var inchiriere = await _context.Inchiriere.FindAsync(id);
            if (inchiriere == null)
            {
                return NotFound();
            }

            _context.Inchiriere.Remove(inchiriere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InchiriereExists(Guid id)
        {
            return _context.Inchiriere.Any(e => e.ID == id);
        }
    }
}
