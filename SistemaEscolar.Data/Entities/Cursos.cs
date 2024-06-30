using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Entities
{
    public class Cursos
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string CodigoCurso { get; set; }
        public string Descripcion { get; set; }
        public int ProfesorAsig { get; set; }

    }
}
