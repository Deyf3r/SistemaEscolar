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

       
        public DbSet<Materias> Materias { get; set; }
    }
}
