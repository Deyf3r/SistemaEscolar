using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Exceptions
{
    public class ProfesoresNullException : Exception
    {
        public ProfesoresNullException(string message) : base(message)
        {
            // x logica para guardar el log del error y enviar notificacion.
        }
    }
}
