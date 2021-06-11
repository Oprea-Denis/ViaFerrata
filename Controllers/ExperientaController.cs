﻿using System;
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
    public class ExperientaController : ControllerBase
    {
        private readonly ViaFerrataContext _context;

        public ExperientaController(ViaFerrataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experienta>>> GetExperienta()
        {
            return await _context.Experienta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Experienta>> GetExperienta(Guid id)
        {
            var experienta = await _context.Experienta.FindAsync(id);

            if (experienta == null)
            {
                return NotFound();
            }

            return experienta;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienta(Guid id, Experienta experienta)
        {
            if (id != experienta.ID)
            {
                return BadRequest();
            }

            _context.Entry(experienta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperientaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Experienta>> PostExperienta(Experienta experienta)
        {
            _context.Experienta.Add(experienta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperienta", new { id = experienta.ID }, experienta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienta(Guid id)
        {
            var experienta = await _context.Experienta.FindAsync(id);
            if (experienta == null)
            {
                return NotFound();
            }

            _context.Experienta.Remove(experienta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperientaExists(Guid id)
        {
            return _context.Experienta.Any(e => e.ID == id);
        }
    }
}
