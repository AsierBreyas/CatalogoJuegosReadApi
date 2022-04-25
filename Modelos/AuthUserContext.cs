using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoJuegosApi.Models;

public class CatalogoJuegosContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(connString);
    public static string connString = $"Server=185.60.40.210\\SQLEXPRESS,58015;Database=ProyectoCatalogoJuegos;User Id=sa;Password=Pa88word";

    public DbSet<CatalogoJuegos> CatalogoJuegos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Biblioteca> Biblioteca { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Biblioteca>().HasIndex(be => new {
                be.JuegoId,
                be.UserId
            }).IsUnique();
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.correo).IsUnique();
        });
    }

}