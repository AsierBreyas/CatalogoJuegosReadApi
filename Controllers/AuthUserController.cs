using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; //[AllowAnonymous]
using CatalogoJuegosApi.Auth;
using System.Threading.Tasks;
using System;
using CatalogoJuegosApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CatalogoJuegosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthRequest model)
        {
            var response = _authService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Models.Usuario>> PostUsuario(Usuario usuario){
            var _context = new CatalogoJuegosContext();
            Console.WriteLine("POST  ", usuario.correo);
            bool exists = UsuarioExists(usuario.correo);
            Console.WriteLine("EXISTS " + exists);
            if (!exists)
            {
                Console.WriteLine("Not found");
                _context.Usuarios.Add(usuario);
            }
            else
            {
                Console.WriteLine("Found");
                // _context.OpcionesUsuarioItem.Remove(opciones);
                // _context.OpcionesUsuarioItem.Add(opciones);
                _context.Entry(usuario).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return usuario;
        }
        // DELETE: api/User/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var _context = new CatalogoJuegosContext();
            Usuario user = _context.Usuarios.Where(e => e.UserId == id).First();
            Console.WriteLine("DELETE ", id.ToString());
            if (!UsuarioExists(user.correo))
            {
                Console.WriteLine("User not found");
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool UsuarioExists(string correo)
        {
            var _context = new CatalogoJuegosContext();
            return _context.Usuarios.Any(e => e.correo == correo);
        }
    }
}
