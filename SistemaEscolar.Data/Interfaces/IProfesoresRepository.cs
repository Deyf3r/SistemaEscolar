using SistemaEscolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Interfaces
{
    public interface IProfesoresRepository
    {
        void Agregar(Profesores profesores);
        void Actualizar(Profesores profesores);
        void Remover(Profesores profesores);
        List<Profesores> TraerTodos();
        Profesores ObtenerPorId(int profesorId);
    }
}
