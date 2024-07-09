using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Exceptions
{
    public class AgregarEstudiantesNullException : Exception
    {
        public AgregarEstudiantesNullException(string message) : base(message)
        {
            // X  Logica para guardar el log del error y enviar la notificacion
        }
    }
}

