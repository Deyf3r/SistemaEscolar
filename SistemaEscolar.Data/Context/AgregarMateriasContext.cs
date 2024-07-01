using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Context
{
    public class AgregarMateriasContext : DbContext

    {
        public AgregarMateriasContext(DbContextOptions<AgregarMateriasContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AgregasMaterias");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Materias> Materias { get; set; }
    }
}
