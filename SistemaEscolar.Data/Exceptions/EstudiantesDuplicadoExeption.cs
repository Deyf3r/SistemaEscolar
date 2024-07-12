using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Exceptions
{
    public class EstudiantesDuplicadoExeption : Exception
    {
        public EstudiantesDuplicadoExeption(string massage) : base(massage)
        {

        }
    }
}
