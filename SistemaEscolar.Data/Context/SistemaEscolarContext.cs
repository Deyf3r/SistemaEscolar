using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Context
{
    public class SistemaEscolarContext : DbContext
    {
        public SistemaEscolarContext(DbContextOptions<SistemaEscolarContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DBEscolar");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Cursos> Curso { get; set; }

    }
}
