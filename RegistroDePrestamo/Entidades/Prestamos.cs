using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
   public class Prestamos
    {
        [Key]
        public int Prestamoid { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        //Datos del cliente
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public string FormaPago { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string LugarTrabajo { get; set; }
        public string Ocupacion { get; set; }
        public int SueldoMensual { get; set; }
        //asta aqui
        public float MontoPrestamo { get; set; }
        public float Interes { get; set; }
        public int NumeroCuota { get; set; }
        public float MontoCuota { get; set; }
        public float TotalIntereses { get; set; }
        public float MontoTotal { get; set; }
        public string Contrasena { get; set; }
        public string NombreDeUsuario { get; set; }
        public int Mora { get; set; }

        [ForeignKey("Prestamoid")]

        public virtual List<Cuota> Detalle { get; set; } = new List<Cuota>();
    }
}
