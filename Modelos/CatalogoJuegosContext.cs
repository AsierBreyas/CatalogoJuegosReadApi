using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoJuegosApi.Models
{
    public class CatalogoJuegosContext : DbContext
    {
        public CatalogoJuegosContext(DbContextOptions<CatalogoJuegosContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogoJuegos> CatalogoJuegos { get; set; }
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Biblioteca> Bibliotecas {get; set;}
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Biblioteca>().HasKey(be => new {
                be.JuegoId,
                be.UserId
            });
        }
        
    }
}