using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoJuegosApi.Models;

    public class CatalgoJuegosContext : DbContext
    {
        public CatalgoJuegosContext (DbContextOptions<CatalgoJuegosContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogoJuegosApi.Models.Biblioteca> Biblioteca { get; set; }
    }
