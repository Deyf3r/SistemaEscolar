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
    public class MockAgregarEstudiantesRepository : IAgregarEstudiantesRepository

    {
        private readonly AgregarEstudiantesContext context;

        public MockAgregarEstudiantesRepository(AgregarEstudiantesContext context)
        {
            this.context = context;
            this.CargarDatos();

        }

        public int EstudiantesId { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }



        public void Actualizar(Estudiantes estudiantes)
        {
            if (EsEstudianteNUll(estudiantes))

                throw new AgregarEstudiantesNullException("El Estudiante no puede ser nulo");

            Estudiantes estudianteToUpdate = this.context.Estudiantes.Find(estudiantes.EstudiantesId);

            if (estudianteToUpdate is null)
                throw new AgregarEstudiantesNotExists("El Estudiante no se encuentra registrado");

            estudianteToUpdate.EstudiantesId = estudiantes.EstudiantesId;
            estudianteToUpdate.Nombre = estudiantes.Nombre;
            estudianteToUpdate.Apellido = estudiantes.Apellido;

            this.context.Estudiantes.Update(estudianteToUpdate);
            this.context.SaveChanges();
        }

        public void Agregar(Estudiantes estudiantes)
        {
           if(EsEstudianteNUll(estudiantes))
                throw new AgregarEstudiantesNullException("El estudiante no debe ser nulo");

            if (ExisteEstudiante(estudiantes.EstudiantesId))
                throw new EstudiantesDuplicadoExeption($"Este estudiante {estudiantes.EstudiantesId}");



            Estudiantes estudiantestoadd = new Estudiantes()
            {
                EstudiantesId = estudiantes.EstudiantesId,
                Nombre = estudiantes.Nombre,
                Apellido = estudiantes.Apellido,
            };

            this.context.Estudiantes.Add(estudiantestoadd);
            this.context.SaveChanges();


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

            if (!this.context.Estudiantes.Any())
            {
                List<Estudiantes> estudiantes1 = new List<Estudiantes>()
        {
        new Estudiantes ()
        {
        EstudiantesId = 1,
        Nombre = "Felibell",
        Apellido = "Brazoban Lopez"
        },
        new Estudiantes ()
        {
        EstudiantesId = 2,
        Nombre = "Franklyn",
        Apellido = "Salcedo"
        },
        new Estudiantes ()
        {
        EstudiantesId = 3,
        Nombre = "Darlly",
        Apellido = "Gomez"
        },
       new Estudiantes ()
        {
        EstudiantesId = 4,
        Nombre = "Aralis",
        Apellido = "Brazoban Lopez"
        },

         };

                this.context.Estudiantes.AddRange(estudiantes1);
                this.context.SaveChanges();
            }


    

            

        


        }

        private bool EsEstudianteNUll(Estudiantes estudiante)
        {
            bool result = false;

            if (estudiante == null)
                result = true;
            return result;
        }

        private bool ExisteEstudiante(int estudianteId)
        {
            return this.context.Estudiantes.Any(cd => cd.EstudiantesId == estudianteId);
        }

        private void LimpiarDatos(List<Estudiantes> estudiantes)
        {
            this.context.Estudiantes.RemoveRange(estudiantes);
            this.context.SaveChanges();

        }

      
    }
}


