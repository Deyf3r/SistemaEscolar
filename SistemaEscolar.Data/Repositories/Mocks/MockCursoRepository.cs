using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Exceptions;
using Sistema_Escolar.Data.Interfaces;
using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Exceptions;
using SistemaEscolar.Data.Interfaces;

using SistemaEscolar.Data.Repositories.Db;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Repositories.Mocks
{
    public class MockCursoRepository : ICursoRepository
    {
        private readonly SistemaEscolarContext context;

        public MockCursoRepository(SistemaEscolarContext context)
        {
            this.context = context;
            CargarDatos();
        }

        public void Actualizar(Cursos curso)
        {

            if (EsCursoNull(curso))

                throw new ArgumentNullException(nameof(curso), "El curso no debe ser nulo");

            Cursos cursoToUpdate = this.context.Curso.Find(curso.CursoId);

            if (cursoToUpdate is null)
                throw new CursoNotExistsException($"El curso con ID {curso.CursoId} no existe");

            cursoToUpdate.CursoId = curso.CursoId;
            cursoToUpdate.Nombre = curso.Nombre;
            cursoToUpdate.CodigoCurso = curso.CodigoCurso;
            cursoToUpdate.Descripcion = curso.Descripcion;
            cursoToUpdate.ProfesorAsig = curso.ProfesorAsig;


            this.context.Curso.Update(cursoToUpdate);
            this.context.SaveChanges();
        }




        public void Agregar(Cursos curso)
        {
            if (EsCursoNull(curso))
                throw new CursoNullException("El Objeto asiento no debe de ser null");

            if (ExisteCurso(curso.CursoId, curso.ProfesorAsig))
            {
                throw new CursoDuplicadoException($"Este curso{curso.CursoId} para este curso: {curso.ProfesorAsig} se encuentra registrado");

            }

            Cursos CursoToAdd = new Cursos()
            {
                CursoId = curso.CursoId,
                ProfesorAsig = curso.ProfesorAsig,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion,
                CodigoCurso = curso.CodigoCurso,

            };

            this.context.Curso.Add(CursoToAdd);
            this.context.SaveChanges();
        }


        public Cursos ObtenerPorId(int CursoId)
        {
            return this.context.Curso.Find(CursoId);
        }

        public void Remover(Cursos curso)
        {
            if (EsCursoNull(curso))
                throw new CursoNullException("El Objeto asiento no debe de ser null");



            Cursos cursoToRemove = this.context.Curso.Find(curso.CursoId);

            if (cursoToRemove is null)
                throw new CursoNotExistsException("El curso no se encuenta registrado");



            context.Curso.Remove(cursoToRemove);
            context.SaveChanges();
        }

        public List<Cursos> TraerTodos()
        {
            return context.Curso.ToList();
        }

        private void CargarDatos()
        {

            if (!this.context.Curso.Any())
            {
                List<Cursos> cursos = new List<Cursos>() 
            { 
        
            new Cursos()
            {
                Nombre = "Ciencias Sociales",
                CodigoCurso = "001A",
                Descripcion = "Curso sobre la historia del país",
                ProfesorAsig = 1
            },
            new Cursos()
            {
                Nombre = "Ciencias Naturales",
                CodigoCurso = "001B",
                Descripcion = "Curso sobre biología, química y física",
                ProfesorAsig = 2
            },
            new Cursos()
            {
                Nombre = "Matemáticas",
                CodigoCurso = "001C",
                Descripcion = "Curso sobre lógica, razonamiento y números",
                ProfesorAsig = 3
            },
            new Cursos()
            {
                Nombre = "Ortografía",
                CodigoCurso = "001D",
                Descripcion = "Curso sobre el arte de las palabras y su uso",
                ProfesorAsig = 4
            }
        };

                context.Curso.AddRange(cursos);
                context.SaveChanges();
            }
        }


        private bool EsCursoNull(Cursos curso)
        {
            bool result = false;
            if (curso == null)
            {
                result = true;

            }
            return result;
        }

        private bool ExisteCurso(int cursoId, int ProfesorAsig)
        {
            return context.Curso.Any(cd => cd.CursoId == cursoId && cd.ProfesorAsig == ProfesorAsig);

        }
    }
}
