using System.ComponentModel.DataAnnotations;
using CatalogoJuegosApi.Models;

namespace CatalogoJuegosApi.Auth
{
    public class AuthRequest
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set ;}
        public string Token { get; set; }
        public System.DateTime ValidTo { get; set; }
    }
}