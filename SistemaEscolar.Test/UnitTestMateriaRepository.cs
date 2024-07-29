using Moq;
using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Exceptions;
using SistemaEscolar.Data.Repositories.Mocks;
namespace SistemaEscolar.Test
{
    public class UnitTestMateriaRepository
    {
        [Fact]
        public void Actualizar_MateriasNull()
        {
            //Arrange//

            var context = new AgregarMateriasContext();
            var repository = new MockMateriaRepository(context);

            //Act//
            Materias materias = null;

            //Assert//
            Assert.Throws<MateriasNullExceptions>(() => repository.Actualizar(materias));
        }


        [Fact]
        public void Actualizar_Materias_Exist()
        {
            //Arrange//

            var context = new AgregarMateriasContext();
            var repository = new MockMateriaRepository(context);

            //Act//
            Materias materias = new Materias()
            {
                MateriasId = 8
            };

            //Assert//

            Assert.Throws<MateriaNotExitsExeption>(() => repository.Actualizar(materias));
        }

        [Fact]
        public void Actualizar_Materias_Not_Exist()
        {
            //Arrange//

            var context = new AgregarMateriasContext();
            var repository = new MockMateriaRepository(context);

            //Act//
            Materias materias = new Materias()
            {
                MateriasId = 8
            };

            //Assert//

            Assert.Throws<MateriaNotExitsExeption>(() => repository.Actualizar(materias));
        }

        [Fact]
        public void Ingresar_Materias_Duplicado()
        {
            //Arrange//

            var context = new AgregarMateriasContext();
            var repository = new MockMateriaRepository(context);

            //Act//
            Materias materias = new Materias()
            {
                MateriasId = 1
            };

            //Assert//

           
            Assert.Throws<MateriaDuplicadoExeption>(() => repository.Agregar(materias));
       
        }

        [Fact]
        public void ObtenerPorId_ReturnMaterias_WhenDuplicado()
        {
            //Arrange//

            var context = new AgregarMateriasContext();
            var repository = new MockMateriaRepository(context);

            //Act//
            int MateriasId = 1;
            var materias = repository.ObtenerPorId(MateriasId);

            //Assert//
            Assert.NotNull(materias);
            var datos = Assert.IsType<Materias>(materias);
            Assert.Equal(datos.MateriasId, MateriasId);
           


        }


    }
    }
