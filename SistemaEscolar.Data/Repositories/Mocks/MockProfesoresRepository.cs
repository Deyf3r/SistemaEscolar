﻿using SistemaEscolar.Data.Context;
using SistemaEscolar.Data.Entities;
using SistemaEscolar.Data.Exceptions;
using SistemaEscolar.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Repositories.Mocks
{
    public class MockProfesoresRepository : IProfesoresRepository
    {
        private readonly ProfesoresContext context;

        public MockProfesoresRepository(ProfesoresContext context)
        {
            this.context = context;
            this.CargarDatos();
        }

        public void Actualizar(Profesores profesores)
        {
            if (EsProfesorNull(profesores))

                throw new ProfesoresNullException("El objeto profesor no puede ser nulo");

            Profesores profesoresToUpdate = this.context.Profesores.Find(profesores.ProfesorId);

            if (profesoresToUpdate is null)
                throw new ProfesorNoExistException("El profesor no se encuentra registrado");

            profesoresToUpdate.ProfesorId = profesores.ProfesorId;
            profesoresToUpdate.Nombre = profesores.Nombre;
            profesoresToUpdate.Apellido = profesores.Apellido;
            profesoresToUpdate.Telefono = profesores.Telefono;
            profesoresToUpdate.Departamento = profesores.Departamento;
            profesoresToUpdate.Correo = profesores.Correo;
            profesoresToUpdate.Direccion = profesores.Direccion;

            this.context.Profesores.Update(profesoresToUpdate);
            this.context.SaveChanges();
        }

        public void Agregar(Profesores profesores)
        {
            if (EsProfesorNull(profesores))
            {
                throw new ProfesoresNullException("El objeto profesor no puede ser nulo");
            }

            if (ExisteProfesor(profesores.ProfesorId))
            {
                throw new ProfesorDuplicadoException($"Este profesor {profesores.ProfesorId} ya se encuentra registrado");
            }

            Profesores profesoresToAdd = new Profesores()
            {
                ProfesorId = profesores.ProfesorId,
                Nombre = profesores.Nombre,
                Apellido = profesores.Apellido,
                Telefono = profesores.Telefono,
                Departamento = profesores.Departamento,
                Correo = profesores.Correo,
                Direccion = profesores.Direccion,

            };
            this.context.Profesores.Add(profesoresToAdd);
            this.context.SaveChanges();
        }

        public Profesores ObtenerPorId(int profesorId)
        {
            return this.context.Profesores.Find(profesorId);
        }

        public void Remover(Profesores profesores)
        {
            if (EsProfesorNull(profesores))
            {
                throw new ProfesoresNullException("El objeto profesor no puede ser nulo");
            }
            Profesores profesoresToRemove = this.context.Profesores.Find(profesores.ProfesorId);

            if (profesoresToRemove is null)
            {
                throw new ProfesorNoExistException("El profesor no se encuentra registrado");
            }
            this.context.Profesores.Remove(profesoresToRemove);
            this.context.SaveChanges();
        }

        public List<Profesores> TraerTodos()
        {
            return this.context.Profesores.ToList();
        }

        private void CargarDatos()
        {
           
            List<Profesores> profesores = new List<Profesores>()
            {
                new Profesores()
                {
                    ProfesorId = 1,
                    Nombre = "Leandro",
                    Apellido = "Zapata",
                    Correo = "leandro@gmail.com",
                    Departamento = "Fisica",
                    Telefono = 809845854,
                    Direccion = "Santo Domingo",
                },
                new Profesores()
                {
                    ProfesorId = 2,
                    Nombre = "Marcos",
                    Apellido = "Leonidas",
                    Correo = "marcos@gmail.com",
                    Departamento = "Biologia",
                    Telefono = 1515615,
                    Direccion = "Santo Domingo",
                },
                  new Profesores()
                {
                    ProfesorId = 3,
                    Nombre = "Yisel",
                    Apellido = "D oleo",
                    Correo = "doleo@gmail.com",
                    Departamento = "Matematicas",
                    Telefono = 1313151531,
                    Direccion = "San Cristobal",
                },
                    new Profesores()
                {
                    ProfesorId = 4,
                    Nombre = "Pedro",
                    Apellido = "Vizcaino",
                    Correo = "viz@gmail.com",
                    Departamento = "Educacion Fisica",
                    Telefono = 121351531,
                    Direccion = "Santo Domingo",
                },
                    new Profesores()
                {
                    ProfesorId = 5,
                    Nombre = "Maria",
                    Apellido = "Gonzalez",
                    Correo = "maria.gonzalez@gmail.com",
                    Departamento = "Matemáticas",
                    Telefono = 123456789,
                    Direccion = "Santiago",
                },

                new Profesores()
                {
                    ProfesorId = 6,
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Correo = "juan.perez@gmail.com",
                    Departamento = "Historia",
                    Telefono = 987654321,
                    Direccion = "La Vega",
                },

                new Profesores()
                {
                    ProfesorId = 7,
                    Nombre = "Ana",
                    Apellido = "Lopez",
                    Correo = "ana.lopez@gmail.com",
                    Departamento = "Lengua y Literatura",
                    Telefono = 456789123,
                    Direccion = "Puerto Plata",
                },

                new Profesores()
                {
                    ProfesorId = 8,
                    Nombre = "Carlos",
                    Apellido = "Martinez",
                    Correo = "carlos.martinez@gmail.com",
                    Departamento = "Ciencias",
                    Telefono = 654321987,
                    Direccion = "Bavaro",
                },

                new Profesores()
                {
                    ProfesorId = 9,
                    Nombre = "Lucia",
                    Apellido = "Ramirez",
                    Correo = "lucia.ramirez@gmail.com",
                    Departamento = "Educación Artística",
                    Telefono = 321987654,
                    Direccion = "Punta Cana",
                },
            };
            this.context.Profesores.AddRange(profesores);
            this.context.SaveChanges();

        }

        private bool EsProfesorNull(Profesores profesores)
        {
            bool result = false;
            if (profesores == null)
                result = true;
            return result;
        }

        private bool ExisteProfesor(int profesorId)
        {
            return this.context.Profesores.Any(cd => cd.ProfesorId == profesorId);
        }
    }
}
