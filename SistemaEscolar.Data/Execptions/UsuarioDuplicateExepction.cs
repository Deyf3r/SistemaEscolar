using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Execptions
{
    public class UsuarioDuplicateExepction : Exception
    {
        public UsuarioDuplicateExepction(string Message) : base(Message) { }
    }
}
