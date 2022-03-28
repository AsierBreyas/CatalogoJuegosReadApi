using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogoJuegosApi.Models{
    public class Usuario{
        [Key]
        public int UserId{get;set;}
        public string nombre{get;set;}
        [DataType(DataType.EmailAddress)]
        public string correo{get;set;}
        [DataType(DataType.Password)]
        public string contraseña{get;set;}

    }
}