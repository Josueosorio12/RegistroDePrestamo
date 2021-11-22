using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
   public class Empleados
    {
        [Key]

        public int CodigoEmpleado { get; set; }
        public DateTime FechaEmpleado { get; set; } = DateTime.Now;
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string TipoPago { get; set; }
        public string Ingreso { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }


        public virtual List<PrestamoDetalle> Detalles { get; set; } = new List<PrestamoDetalle>();
    }
}
