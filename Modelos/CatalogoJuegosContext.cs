using Microsoft.EntityFrameworkCore;

namespace CatalogoJuegosApi.Models
{
    public class CatalogoJuegosContext : DbContext
    {
        public CatalogoJuegosContext(DbContextOptions<CatalogoJuegosContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogoJuegos> CatalogoJuegos { get; set; }
        
    }
}