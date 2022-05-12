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
    public class BibliotecaController : ControllerBase
    {
        private readonly CatalogoJuegosContext _context;

        public BibliotecaController(CatalogoJuegosContext context)
        {
            _context = context;
        }

        // GET: api/Biblioteca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biblioteca>>> GetBiblioteca()
        {
            return await _context.Biblioteca.ToListAsync();
        }

        // GET: api/Biblioteca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biblioteca>> GetBiblioteca(int id)
        {
            var biblioteca = await _context.Biblioteca.FindAsync(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return biblioteca;
        }

        // PUT: api/Biblioteca/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiblioteca(int id, Biblioteca biblioteca)
        {
            if (id != biblioteca.BibliotecaId)
            {
                return BadRequest();
            }

            _context.Entry(biblioteca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibliotecaExists(id))
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

        // POST: api/Biblioteca
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Biblioteca>> PostBiblioteca(Biblioteca biblioteca)
        {
            _context.Biblioteca.Add(biblioteca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiblioteca", new { id = biblioteca.BibliotecaId }, biblioteca);
        }

        // DELETE: api/Biblioteca/5
        [HttpDelete("{userId}/{juegoId}")]
        public async Task<IActionResult> DeleteBiblioteca(int userId, int juegoId)
        {
            var biblioteca = _context.Biblioteca.Where(b => b.UserId == userId && b.JuegoId == juegoId).FirstOrDefault();
            if (biblioteca == null)
            {
                return NotFound();
            }

            _context.Biblioteca.Remove(biblioteca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibliotecaExists(int id)
        {
            return _context.Biblioteca.Any(e => e.BibliotecaId == id);
        }
    }
}
