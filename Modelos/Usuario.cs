using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CatalogoJuegosApi.Models{
    public class Usuario{
        [Key]
        public int UserId{get;set;}
        public string nombre{get;set;}
        [DataType(DataType.EmailAddress)]
        public string correo{get;set;}
        [DataType(DataType.Password)]
        public string contraseña{get;set;}

        public List<Biblioteca> MisJuegos {get;} = new List<Biblioteca>();

    }
}