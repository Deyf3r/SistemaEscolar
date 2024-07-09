using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Exceptions;
using Sistema_Escolar.Data.Interfaces;
using SistemaEscolar.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Repositories.Mocks
{
    public class MockAgregarEstudiantes : IAgregarEstudiantesRepository

    {
        private readonly AgregarEstudiantesContext context;

        public MockAgregarEstudiantes(AgregarEstudiantesContext context)
        {
            this.context = context;
            this.CargarDatos();

        }
        public void Actualizar(Estudiantes estudiantes)
        {
            if (EsEstudianteNUll(estudiantes))

                throw new AgregarEstudiantesNullException("El Estudiante no puede ser nulo");

            Estudiantes estudianteToUpdate = this.context.Estudiantes.Find(estudiantes.EstudiantesId);

            if (estudianteToUpdate is null)
                throw new AgregarEstudiantesNotExists("El Estudiante no se encuentra registrado");

            estudianteToUpdate.EstudiantesId = estudianteToUpdate.EstudiantesId;
        }

        public void Agregar(Estudiantes estudiantes)
        {
            if (EsEstudianteNUll(estudiantes))

                throw new AgregarEstudiantesNullException("El Estudiante no puede ser nulo");


        }

        public Estudiantes ObtenerPorId(int estudiantesId)
        {
            return this.context.Estudiantes.Find(estudiantesId);
        }

        public void Remover(Estudiantes estudiantes)
        {
            if (EsEstudianteNUll(estudiantes))

                throw new AgregarEstudiantesNullException("El Estudiante no puede ser nulo");



            Estudiantes estudiantesToRemove = this.context.Estudiantes.Find(estudiantes.EstudiantesId);

            if (estudiantesToRemove is null)
            {
                throw new AgregarEstudiantesNotExists("El Estudiante no se encuentra registrado");
            }
            this.context.Estudiantes.Remove(estudiantes);
            this.context.SaveChanges();
        }

        public List<Estudiantes> TraerTodos()
        {
            return this.context.Estudiantes.ToList();
        }

        private void CargarDatos()
        {
            Estudiantes estudiante = new Estudiantes()
            {
                EstudiantesId = 1,
            };

            new Estudiantes()
            {
                EstudiantesId = 2,
            };

            List<Estudiantes> estudiantes = new List<Estudiantes>() { };

            this.context.Estudiantes.AddRange(estudiantes);


        }

        private bool EsEstudianteNUll(Estudiantes estudiante)
        {
            bool result = false;

            if (estudiante == null)
                result = true;
            return result;
        }

    }
}
