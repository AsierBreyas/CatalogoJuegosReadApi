using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoJuegosApi.Models{
    public class CatalogoJuegos{
        
        public int id{get;set;}
        public string title{get;set;}
        public string thumbnail{get;set;}
        public string short_description{get;set;}
        public string game_url{get;set;}
        public string genre{get;set;}
        public string plataform{get;set;}
        public string publisher{get;set;}
        public string developer{get;set;}
        public DateTime release_date{get;set;}
        public string freetogame_profile_url{get;set;}

    }
}