using Sistema_Escolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Escolar.Data.Interfaces
{
    public interface IAgregarEstudiantesRepository
    {
        void Agregar(Estudiantes estudiantes);
        void Actualizar(Estudiantes estudiantes);
        void Remover(Estudiantes estudiantes);
        List<Estudiantes> TraerTodos();

        Estudiantes ObtenerPorId(int estudiantesId);
    }
}
