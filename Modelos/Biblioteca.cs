using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CatalogoJuegosApi.Models{
    public class Biblioteca{
        
        public int BibliotecaId {get; set;}
        // [Key, Column(Order = 1)]
        public int JuegoId{get;set;}
        // [Key, Column(Order = 0)]
        public int UserId{get;set;}

        [ForeignKey("JuegoId")]
        public CatalogoJuegos CatalogoJuegos {get; set;}
        [ForeignKey("UserId")]
        public Usuario Usuario {get; set;}

    }
}