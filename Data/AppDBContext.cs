using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Parcial_1__Programacion.Models;

namespace Parcial_1__Programacion.Data
{
        public class AppDBcontext : DbContext
        {
            public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
            {
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=nico;Initial Catalog=PrimerParcial-Prog;Integrated Security=True;Trust Server Certificate=True");
            }
            public DbSet<Paciente> Pacientes { get; set; }
            public DbSet<Obrasocial> Obrasociales { get; set; }

    }
}
