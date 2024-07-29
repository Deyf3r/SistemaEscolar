
using Moq;
using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Exceptions;
using Sistema_Escolar.Data.Repositories.Mocks;
using SistemaEscolar.Data.Exceptions;
namespace SistemaEscolar.Test
{
    public class UnitEstudianteTest
    {
        [Fact]
        public void Actualizar_EstudianteIsNull()
        {
            // Arrange //

            var context = new AgregarEstudiantesContext();
            var repository = new MockAgregarEstudiantesRepository(context);

            // Act/ /
            Estudiantes estudiantes = null;
            Assert.Throws<AgregarEstudiantesNullException>(() => repository.Actualizar(estudiantes));
        }
        [Fact]
        public void Actualizar_Estudiante_Exist()
        {
            // Arrange //

            var context = new AgregarEstudiantesContext();
            var repository = new MockAgregarEstudiantesRepository(context);

            // Act/ /
            Estudiantes estudiantes = new Estudiantes()
            {
                EstudiantesId = 8
            };


            //var result = repository.Actualizar(estudiantes);
            //Assert.True(result);

            Assert.Throws<AgregarEstudiantesNotExists>(() => repository.Actualizar(estudiantes));
        }

        [Fact]
        public void Ingresar_Estudiante_Duplicado()
        {
            // Arrange //

            var context = new AgregarEstudiantesContext();
            var repository = new MockAgregarEstudiantesRepository(context);

            // Act/ /
            Estudiantes estudiantes = new Estudiantes()
            {
                EstudiantesId = 1
            };

            
            Assert.Throws<EstudiantesDuplicadoExeption>(() => repository.Agregar(estudiantes));
        }
        [Fact]
        public void Ingresar_Estudiante_Not_Exist()
        {
            // Arrange //

            var context = new AgregarEstudiantesContext();
            var repository = new MockAgregarEstudiantesRepository(context);

            // Act/ /
            Estudiantes estudiantes = new Estudiantes()
            {
                EstudiantesId = 8
            };

            Assert.Throws<AgregarEstudiantesNotExists>(() => repository.Actualizar(estudiantes));
        }

        [Fact]
        public void ObtenerPorId_ReturnEstudiante_WhenEstudianteExist()
        {
            // Arrange //

            var context = new AgregarEstudiantesContext();
            var repository = new MockAgregarEstudiantesRepository(context);

            // Act/ /


            int EstudiantesId = 1;
            var estudiante = repository.ObtenerPorId(EstudiantesId);
            Assert.NotNull(estudiante);
            var datos = Assert.IsType<Estudiantes>(estudiante);

            
        }
    }
}