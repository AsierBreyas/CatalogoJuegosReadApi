using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CatalogoJuegosApi.Settings;

using CatalogoJuegosApi.Models;

namespace CatalogoJuegosApi.Auth
{
    public interface IAuthService
    {
        AuthResponse Authenticate(AuthRequest model);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
    }

    public class AuthService : IAuthService
    {
        // users list
        private List<Usuario> _users = new CatalogoJuegosContext().Usuarios.ToList();

        private readonly AppSettings _appSettings;

        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthResponse Authenticate(AuthRequest req)
        {
            var user = _users.SingleOrDefault(u => u.correo == req.EmailAddress && u.contraseña == req.Password);

            // 1.- control null
            if (user == null) return null;
            // 2.- control db

            // autenticacion válida -> generamos jwt
            var (token, validTo) = generateJwtToken(user);
            // generamos un token válido para 7 días

            // Devolvemos lo que nos interese
            return new AuthResponse
            {
                Id = user.UserId,
                Username = user.nombre,
                EmailAddress = user.correo,
                Token = token,
                ValidTo = validTo
            };

        }
        public IEnumerable<Usuario> GetAll()
        {
            return _users;
        }
        public Usuario GetById(int id)
        {
            return _users.FirstOrDefault(x => x.UserId == id);
        }
        // internos
        private (string token, DateTime validTo) generateJwtToken(Usuario user){
            var dias = 90;
            var tokenHandler = new JwtSecurityTokenHandler();
            Console.WriteLine(_appSettings.Secret);
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.correo)
                }),
                Expires = DateTime.UtcNow.AddDays(dias),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (token: tokenHandler.WriteToken(token), validTo: token.ValidTo);

        }
    }
}