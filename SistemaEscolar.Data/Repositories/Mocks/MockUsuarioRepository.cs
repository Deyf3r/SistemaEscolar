using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Execptions;
using SistemaEscolar.Data.Repositories.Db;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEscolar.Data.Repositories.Mocks
{
    public class MockUsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext context;

        public MockUsuarioRepository(UsuariosContext context)
        {
            this.context = context;
            this.CargarDatos();
        }

        public void Actualizar(Usuarios usuarios)
        {
            if (UsuarioIsNull(usuarios))
            {
                throw new UsuarioIsNullExecption("El usuario no puede ser null");
            }
            Usuarios UsuarioToUpdate = this.context.Usuarios.Find(usuarios.IdUsuario);

            if (UsuarioToUpdate is null)
                throw new UsurioToRemoveExecption("El usuario a actualizar no puede ser null");

            UsuarioToUpdate.IdUsuario = usuarios.IdUsuario;
            UsuarioToUpdate.Name = usuarios.Name;
            UsuarioToUpdate.Email = usuarios.Email;
            UsuarioToUpdate.Password = usuarios.Password;
            UsuarioToUpdate.Phone = usuarios.Phone;

            this.context.Usuarios.Update(UsuarioToUpdate);
            this.context.SaveChanges();
        }

        public void Agregar(Usuarios usuarios)
        {
            if (usuarios is null)
                throw new UsuarioIsNullExecption("El usuario no puede ser null");

            if (ExisteUsuario(usuarios.IdUsuario))
                throw new UsuarioDuplicateExepction("El usuario ya existe");

            if (usuarios.Name.Length > 30)
                throw new UsuarioNameTooLong("El nombre no puede tener más de 30 caracteres");

            Usuarios UsuarioToAdd = new Usuarios()
            {
                IdUsuario = usuarios.IdUsuario,
                Name = usuarios.Name,
                Email = usuarios.Email,
                Password = usuarios.Password,
                Phone = usuarios.Phone
            };

            this.context.Usuarios.Add(UsuarioToAdd);
            this.context.SaveChanges();
        }

        public Usuarios ObtenerPorId(int IdUsuario)
        {
            return this.context.Usuarios.Find(IdUsuario);
        }

        public void Remover(Usuarios usuarios)
        {
            if (usuarios is null)
                throw new UsuarioIsNullExecption("El usuario no puede ser null");

            Usuarios UsuarioToRemove = this.context.Usuarios.Find(usuarios.IdUsuario);

            if (UsuarioToRemove is null)
                throw new UsurioToRemoveExecption("El usuario a remover no puede ser nulo");

            this.context.Usuarios.Remove(UsuarioToRemove);
            this.context.SaveChanges();
        }

        public List<Usuarios> TraerTodos()
        {
            return this.context.Usuarios.ToList();
        }

        private bool ExisteUsuario(int UsuarioId)
        {
            return this.context.Usuarios.Any(cd => cd.IdUsuario == UsuarioId);
        }

        private void CargarDatos()
        {
            if (!this.context.Usuarios.Any(u => u.IdUsuario == 1))
            {
                Usuarios usuario = new Usuarios()
                {
                    IdUsuario = 1,
                    Name = "Pedro",
                    Password = "Contraseña",
                    Email = "Email",
                    Phone = 8081231234
                };

                this.context.Usuarios.Add(usuario);
                this.context.SaveChanges();
            }
        }

        private bool UsuarioIsNull(Usuarios usuarios)
        {
            return usuarios is null;
        }
    }
}
