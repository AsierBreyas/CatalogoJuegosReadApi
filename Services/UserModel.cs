using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        // [Key]
        // public int UserId{get;set;}
        // public string nombre{get;set;}
        // [DataType(DataType.EmailAddress)]
        // public string correo{get;set;}
        // [JsonIgnore,DataType(DataType.Password)]
        // public string contraseña{get;set;}

    }
}