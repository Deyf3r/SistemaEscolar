using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaEscolar.Data.Context
{
    public class ProfesoresContext : DbContext
    {
        public ProfesoresContext(DbContextOptions<ProfesoresContext> options) : base()
        {

        }

        public ProfesoresContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SistemaEscolar");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Profesores> Profesores { get; set; }
    }
}
