using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Execptions
{
    public class UsuarioNotExistExecption: Exception
    {
        public UsuarioNotExistExecption(string message) : base(message) { }

    }
}
