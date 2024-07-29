using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Execptions
{
    public class UsurioToRemoveExecption : Exception
    {
        public UsurioToRemoveExecption(string Message) : base(Message)
        {

        }


    }
}
