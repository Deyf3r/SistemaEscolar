using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Data.Entities
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Int128 Phone { get; set; }

    }
}
