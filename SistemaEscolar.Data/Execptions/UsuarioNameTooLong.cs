using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Execptions
{
    public class UsuarioNameTooLong: Exception
    {
        public UsuarioNameTooLong(string message) : base(message) { }

    }
}
