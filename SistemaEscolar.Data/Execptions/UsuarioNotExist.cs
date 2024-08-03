using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Execptions
{
    public class UsuarioNotExist: Exception
    {
        public UsuarioNotExist(string message) : base(message) { }

    }
}
