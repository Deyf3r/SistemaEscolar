using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Context
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("EscuelaDB");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Usuarios> Usuarios { get; set; }

    }
}
