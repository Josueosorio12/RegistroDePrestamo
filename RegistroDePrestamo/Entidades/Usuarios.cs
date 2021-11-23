using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
   public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public String Alias { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public String Clave { get; set; }
        public String RolID { get; set; }
        public String Activo { get; set; }
    }
}
