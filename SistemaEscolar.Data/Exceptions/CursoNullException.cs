using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Exceptions
{
    public class CursoNullException : Exception
    {
        public CursoNullException(string message) : base(message)
        {
            // logica para guardar el log del error y enviar la notificacion.

        }

    }
}
