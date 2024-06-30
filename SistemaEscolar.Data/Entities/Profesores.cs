using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Data.Entities
{
    public class Profesores
    {
        [Key]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Departamento { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }



    }
}
