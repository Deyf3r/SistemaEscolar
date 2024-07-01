using SistemaEscolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Interfaces
{
    public interface IMateriasRepository
    {
        void Agregar(Materias materias);

        void Actualizar(Materias materias);

        void Remover(Materias materias);

        List<Materias> TraerTodos();

        Materias ObtenerPorId(int materId);


    }
}
