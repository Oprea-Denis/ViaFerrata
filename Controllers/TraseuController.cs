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
    public class TraseuController : ControllerBase
    {
        private readonly ViaFerrataContext _context;

        public TraseuController(ViaFerrataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Traseu>> GetTraseu(Guid id)
        {
            var traseu = await _context.Traseu.FindAsync(id);

            if (traseu == null)
            {
                return NotFound();
            }

            return traseu;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraseu(Guid id, Traseu traseu)
        {
            if (id != traseu.ID)
            {
                return BadRequest();
            }

            _context.Entry(traseu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraseuExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraseu(Guid id)
        {
            var traseu = await _context.Traseu.FindAsync(id);
            if (traseu == null)
            {
                return NotFound();
            }

            _context.Traseu.Remove(traseu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraseuExists(Guid id)
        {
            return _context.Traseu.Any(e => e.ID == id);
        }
    }
}
