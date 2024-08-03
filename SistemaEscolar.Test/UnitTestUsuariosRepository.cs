using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Execptions;
using SistemaEscolar.Data.Repositories.Mocks;
using Xunit;

namespace SistemaEscolar.Test
{
    public class UnitTestUsuariosRepository
    {
        private UsuariosContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UsuariosContext>()
                .UseInMemoryDatabase(databaseName: "UsuariosTestDb")
                .Options;

            var context = new UsuariosContext(options);
            context.Database.EnsureDeleted(); // Eliminar la base de datos existente
            context.Database.EnsureCreated(); // Crear una nueva base de datos en memoria
            return context;
        }

        [Fact]
        public void ActualizarUsuarios_NullParameter_ThrowsUsuarioIsNullExecption()
        {
            using var context = GetInMemoryDbContext();
            var repository = new MockUsuarioRepository(context);

            Usuarios usuario = null;
            Assert.Throws<UsuarioIsNullExecption>(() => repository.Actualizar(usuario));
        }

        [Fact]
        public void Actualizar_Usuario_Alredy_Exist()
        {
            using var context = GetInMemoryDbContext();
            var repository = new MockUsuarioRepository(context);

            Usuarios usuario = new Usuarios
            {
                IdUsuario = 1,
                Name = "Juan"
            };

            Assert.Throws<UsuarioDuplicateExepction>(() => repository.Agregar(usuario));
        }

        [Fact]
        public void Usuario_Too_Long()
        {
            using var context = GetInMemoryDbContext();
            var repository = new MockUsuarioRepository(context);

            Usuarios usuario = new Usuarios
            {
                IdUsuario = 809,
                Name = "Juan12345678912345678912345678912"
            };

            Assert.Throws<UsuarioNameTooLong>(() => repository.Agregar(usuario));
        }

        [Fact]
        public void Remover_NullParameter_ThrowsUsuarioIsNullExecption()
        {
            using var context = GetInMemoryDbContext();
            var repository = new MockUsuarioRepository(context);

            Usuarios usuario = null;
            Assert.Throws<UsuarioIsNullExecption>(() => repository.Remover(usuario));
        }

        [Fact]
        public void Remover_NonExistentUser_ThrowsUsurioToRemoveExecption()
        {
            using var context = GetInMemoryDbContext();
            var repository = new MockUsuarioRepository(context);

            Usuarios usuario = new Usuarios
            {
                IdUsuario = 999,
                Name = "NonExistentUser"
            };

            Assert.Throws<UsurioToRemoveExecption>(() => repository.Remover(usuario));
        }
    }
}
