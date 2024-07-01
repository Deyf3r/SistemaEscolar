using SistemaEscolar.Data.Context;
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
    public class MockMateriaRepository : IMateriasRepository
    {
        private readonly AgregarMateriasContext context;

        public MockMateriaRepository(AgregarMateriasContext context)
        {
            this.context = context;

            this.CargarDatos();
        }

        public int MateriasId { get; private set; }
        public string MateriasName { get; private set; }
        public string Descripcion { get; private set; }

        public void Actualizar(Materias materias)
        {
            if (EsMateriaNull(materias))
                throw new MateriasNullExceptions("It dosen't have to be null");

            Materias materiasToupdate = this.context.Materias.Find(materias.MateriasId);

            if (materiasToupdate is null)
                throw new MateriasNullExceptions("It dosen't have to be null");

            materiasToupdate.MateriasId = materias.MateriasId;
            materiasToupdate.MateriasName = materias.MateriasName;
            materiasToupdate.Descripcion = materias.Descripcion;

            this.context.Materias.Update(materiasToupdate);
            this.context.SaveChanges();

        }

        public void Agregar(Materias materias)
        {
            if (EsMateriaNull(materias))
                throw new MateriasNullExceptions("It dosen't have to be null");

            if (ExisteMateria(materias.MateriasId))
                throw new MateriaDuplicadoExeption($"this materia {materias.MateriasId}");

            Materias materiastoadd = new Materias()
            {
                MateriasId = materias.MateriasId,
                MateriasName = materias.MateriasName,
                Descripcion = materias.Descripcion,
            };

            this.context.Materias.Add(materiastoadd);
            this.context.SaveChanges();
        }

        public Materias ObtenerPorId(int materId)
        {
            return this.context.Materias.Find(materId);
        }

        public void Remover(Materias materias)
        {
            if (EsMateriaNull(materias))

                throw new MateriasNullExceptions("It dosen't have to be null");


            Materias materiasToremove = this.context.Materias.Find(materias.MateriasId);

            if (materiasToremove is null)
            {
                throw new MateriaNotExitsExeption("It dosen't exits");
            }

            this.context.Materias.Remove(materiasToremove);
            this.context.SaveChanges();
        }

        public List<Materias> TraerTodos()
        {
            return this.context.Materias.ToList();
        }

        private void CargarDatos()
        {

            List<Materias> materias1 = new List<Materias>()
            {
                new Materias ()
                {
                MateriasId = 1,
                MateriasName = "",
                Descripcion = ""
                },
                new Materias ()
                {
                MateriasId = 2,
                MateriasName = "",
                Descripcion = ""
                },
                new Materias ()
                {
                MateriasId = 3,
                MateriasName = "",
                Descripcion = ""
                },
                new Materias ()
                {
                MateriasId = 4,
                MateriasName = "",
                Descripcion = ""
                },

             };

            this.context.Materias.AddRange(materias1);
            this.context.SaveChanges();


        }

        private bool EsMateriaNull(Materias materias)
        {
            bool results = false;

            if (materias is null)

                results = true;

            return results;
        }

        private bool ExisteMateria(int materiasId)
        {
            return this.context.Materias.Any(cd => cd.MateriasId == materiasId);
        }
    }
}
