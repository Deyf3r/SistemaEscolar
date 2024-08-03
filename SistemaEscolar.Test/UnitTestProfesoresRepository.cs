using Moq;
using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Exceptions;
using SistemaEscolar.Data.Repositories.Mocks;
namespace SistemaEscolar.Test
{
    public class UnitTestProfesoresRepository
    {
        [Fact]
        public void Actualizar_ProfesorIsNull()
        {
            // Arrange //

            var context = new ProfesoresContext();
            var repository = new MockProfesoresRepository(context);

            // Act //

            Profesores profesores = null;

            // Assert //

            Assert.Throws<ProfesoresNullException>(() => repository.Actualizar(profesores));


        }
        [Fact]
        public void Actualizar_Profesor_Not_Exists()
        {
            // Arrange //

            var context = new ProfesoresContext();
            var repository = new MockProfesoresRepository(context);

            // Act //

            Profesores profesores = new Profesores()
            {
                ProfesorId = 19
            };

            //  Assert //

            Assert.Throws<ProfesorNoExistException>(() => repository.Actualizar(profesores));


        }
        [Fact]
        public void Agregar_Profesor_Duplicado()
        {
            // Arrange //

            var context = new ProfesoresContext();
            var repository = new MockProfesoresRepository(context);

            // Act //

            Profesores profesores = new Profesores()
            {
                ProfesorId = 1
            };

            //  Assert //

            Assert.Throws<ProfesorDuplicadoException>(() => repository.Agregar(profesores));

        }
        [Fact]
        public void ObtenerPorId_WhenProfesorExist()
        {
            // Arrange //

            var context = new ProfesoresContext();
            var repository = new MockProfesoresRepository(context);

            // Act //

            int profesorId = 1;
            var profesores = repository.ObtenerPorId(profesorId);

            //  Assert //

            Assert.NotNull(profesores);
            var datos = Assert.IsType<Profesores>(profesores);
            Assert.Equal(datos.ProfesorId, profesorId);

        }
        [Fact]
        public void Agregar_ProfesorIsNull()
        {
            // Arrange //

            var context = new ProfesoresContext();
            var repository = new MockProfesoresRepository(context);

            // Act //

            Profesores profesores = null;

            //  Assert //

            Assert.Throws<ProfesoresNullException>(() => repository.Agregar(profesores));

        }
    }
}