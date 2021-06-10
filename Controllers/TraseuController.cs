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

        //private static List<Traseu> trasee = new List<Traseu>()
        //{
        //    new Traseu() { ID = Guid.NewGuid(), NumeSiLocatie = "Astragalus, Cheile Sugaului-Munticelu, judetul Neamt", Dificultate = "A/B, C, C/D", Durata = "traseu principal, 1h30min - 2h30min", Taxa = "Gratuit" },
        //    new Traseu() { ID = Guid.NewGuid(), NumeSiLocatie = "Wild Ferenc, Lacul Rosu, judetul Harghita", Dificultate = "C/D", Durata = "50min", Taxa = "Gratuit"},
        //    new Traseu() { ID = Guid.NewGuid(), NumeSiLocatie = "White Wolf, Pestera Muierilor, Cheile Galbenului, Baia de Fier, judetul Gorj", Dificultate = "B, C, D", Durata = "traseu principal, 1h30min", Taxa = "Gratuit"},
        //    new Traseu() { ID = Guid.NewGuid(), NumeSiLocatie = "Cheile Rasnoavei, judetul Brasov", Dificultate = "C/D", Durata = "2h", Taxa = "15RON"},
        //    new Traseu() { ID = Guid.NewGuid(), NumeSiLocatie = "Sky Fly, Grota lui Hili, Cheile Turzii, judetul Cluj", Dificultate = "C", Durata = "40min", Taxa = "15RON"}
        //};

        // GET: api/Traseu
        //[HttpGet]
        //public Traseu[] Get()
        //{
        //    return trasee.ToArray();
        //}

        // GET: api/Traseu/5
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


        // PUT: api/Traseu/5

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

        // POST: api/Traseu
        //[HttpPost]
        //public void Post([FromBody] Traseu traseu)
        //{
        //    if (traseu.ID == Guid.Empty)
        //        traseu.ID = Guid.NewGuid();

        //    trasee.Add(traseu);
        //}

       // DELETE: api/Traseu/5
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

        //[HttpDelete]
        //public void Delete(Guid id)
        //{
        //    trasee.RemoveAll(traseu => traseu.ID == id);
        //}
    }
}
