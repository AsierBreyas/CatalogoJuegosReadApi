using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoJuegosApi.Models;

namespace CatalogoJuegosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoJuegosController : ControllerBase
    {
        private readonly CatalogoJuegosContext _context;

        public CatalogoJuegosController(CatalogoJuegosContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoJuegos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoJuegos>>> GetCatalogoJuegos()
        {
            return await _context.CatalogoJuegos.ToListAsync();
        }

        // GET: api/CatalogoJuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoJuegos>> GetCatalogoJuegos(int id)
        {
            var catalogoJuegos = await _context.CatalogoJuegos.FindAsync(id);

            if (catalogoJuegos == null)
            {
                return NotFound();
            }

            return catalogoJuegos;
        }

        //GET: api/Catalogojuegos/title
        [HttpGet("title/{title}")]
        public async Task<ActionResult<IEnumerable<CatalogoJuegos>>> GetCatalogoJuegos(string title)
        {
            var catalogoJuegos = await _context.CatalogoJuegos.ToListAsync();
            // catalogoJuegos.Find(CatalogoJuegos.title);
            List<CatalogoJuegos> catalogoJuegosF = catalogoJuegos.Where(juego => juego.title.Contains(title)).ToList();

            if (catalogoJuegos == null)
            {
                return NotFound();
            }

            return catalogoJuegosF;
        }

        // PUT: api/CatalogoJuegos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoJuegos(int id, CatalogoJuegos catalogoJuegos)
        {
            if (id != catalogoJuegos.id)
            {
                return BadRequest();
            }

            _context.Entry(catalogoJuegos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoJuegosExists(id))
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

        // POST: api/CatalogoJuegos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogoJuegos>> PostCatalogoJuegos(CatalogoJuegos catalogoJuegos)
        {
            _context.CatalogoJuegos.Add(catalogoJuegos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogoJuegos", new { id = catalogoJuegos.id }, catalogoJuegos);
        }

        // DELETE: api/CatalogoJuegos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoJuegos(int id)
        {
            var catalogoJuegos = await _context.CatalogoJuegos.FindAsync(id);
            if (catalogoJuegos == null)
            {
                return NotFound();
            }

            _context.CatalogoJuegos.Remove(catalogoJuegos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogoJuegosExists(int id)
        {
            return _context.CatalogoJuegos.Any(e => e.id == id);
        }
    }
}
