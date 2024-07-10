using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Context
{
    public class AgregarEstudiantesContext : DbContext
    {

        public AgregarEstudiantesContext(DbContextOptions<AgregarEstudiantesContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("Estudiantes");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public DbSet<Estudiantes> Estudiantes { get; set; }


    }

}
