using Microsoft.EntityFrameworkCore;
using Moq;
using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Exceptions;
using SistemaEscolar.Data.Repositories.Mocks;

namespace SistemaEscolar.Test
{
    public class UnitTestCursoRepository
    {
        private SistemaEscolarContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<SistemaEscolarContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Ensure a new database instance for each test
                .Options;
            return new SistemaEscolarContext(options);
        }

        [Fact]
        public void Agregar_CursoNuevo_CursoAgregado()
        {
            using (var context = GetInMemoryContext())
            {
                var repository = new MockCursoRepository(context);
                var curso = new Cursos { Nombre = "Historia", CodigoCurso = "001E", Descripcion = "Curso sobre la historia mundial", ProfesorAsig = 5 };

                repository.Agregar(curso);

                var cursoInDb = context.Curso.AsNoTracking().FirstOrDefault(c => c.CodigoCurso == "001E");
                Assert.NotNull(cursoInDb);
                Assert.Equal("Historia", cursoInDb.Nombre);
            }
        }
        //pruba
        [Fact]
        public void Actualizar_CursoExistente_CursoActualizado()
        {
            using (var context = GetInMemoryContext())
            {
                var repository = new MockCursoRepository(context);
                var curso = new Cursos { Nombre = "Ciencias Sociales", CodigoCurso = "001A", Descripcion = "Curso sobre la historia del país", ProfesorAsig = 1 };
                context.Curso.Add(curso);
                context.SaveChanges();

                context.Entry(curso).State = EntityState.Detached; // Detach the tracked entity

                var cursoParaActualizar = context.Curso.AsNoTracking().FirstOrDefault(c => c.CodigoCurso == "001A");
                cursoParaActualizar.Descripcion = "Curso actualizado";
                repository.Actualizar(cursoParaActualizar);

                var cursoInDb = context.Curso.AsNoTracking().FirstOrDefault(c => c.CodigoCurso == "001A");
                Assert.Equal("Curso actualizado", cursoInDb.Descripcion);
            }
        }

        [Fact]
        public void ObtenerPorId_CursoExistente_DevuelveCurso()
        {
            using (var context = GetInMemoryContext())
            {
                var repository = new MockCursoRepository(context);
                var curso = new Cursos { Nombre = "Ciencias Sociales", CodigoCurso = "001A", Descripcion = "Curso sobre la historia del país", ProfesorAsig = 1 };
                context.Curso.Add(curso);
                context.SaveChanges();

                var cursoParaObtener = context.Curso.AsNoTracking().FirstOrDefault(c => c.CodigoCurso == "001A");
                var result = repository.ObtenerPorId(cursoParaObtener.CursoId);

                Assert.Equal(cursoParaObtener.CursoId, result.CursoId);
                Assert.Equal(cursoParaObtener.Nombre, result.Nombre);
                Assert.Equal(cursoParaObtener.CodigoCurso, result.CodigoCurso);
                Assert.Equal(cursoParaObtener.Descripcion, result.Descripcion);
                Assert.Equal(cursoParaObtener.ProfesorAsig, result.ProfesorAsig);
            }
        }

        [Fact]
        public void Remover_CursoExistente_CursoRemovido()
        {
            using (var context = GetInMemoryContext())
            {
                var repository = new MockCursoRepository(context);
                var curso = new Cursos { Nombre = "Historia", CodigoCurso = "001E", Descripcion = "Curso sobre la historia mundial", ProfesorAsig = 5 };
                context.Curso.Add(curso);
                context.SaveChanges();

                repository.Remover(curso);

                var cursoInDb = context.Curso.AsNoTracking().FirstOrDefault(c => c.CodigoCurso == "001E");
                Assert.Null(cursoInDb);
            }
        }

        [Fact]
        public void TraerTodos_DevuelveListaDeCursos()
        {
            using (var context = GetInMemoryContext())
            {
                var repository = new MockCursoRepository(context);
                var cursos = new List<Cursos>
                {
                    new Cursos { Nombre = "Ciencias Sociales", CodigoCurso = "001A", Descripcion = "Curso sobre la historia del país", ProfesorAsig = 1 },
                    new Cursos { Nombre = "Ciencias Naturales", CodigoCurso = "001B", Descripcion = "Curso sobre biología, química y física", ProfesorAsig = 2 }
                };
                context.Curso.AddRange(cursos);
                context.SaveChanges();

                var result = repository.TraerTodos();

                // Usamos Assert para asegurarnos de que la lista de resultados tiene la cantidad esperada de elementos
                Assert.Equal(6, result.Count);
                // Verificamos los nombres de los cursos para asegurarnos de que los elementos son los esperados
                Assert.Contains(result, c => c.Nombre == "Ciencias Sociales");
                Assert.Contains(result, c => c.Nombre == "Ciencias Naturales");
            }
        }

    }
}



