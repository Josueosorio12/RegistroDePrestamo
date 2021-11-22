using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
    public class Clientes
    {
        [Key]
        public int CodigoCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaCliente { get; set; } = DateTime.Now;
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Ciudad { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string Direccion { get; set; }
        public string LugarTrabajo { get; set; }
        public string Email { get; set; }
        public int SueldoMensual { get; set; }


        //Datos de Referencias
        public string NombreReferencia { get; set; }
        public string ApellidoReferencia { get; set; }
        public string TelefonoReferencia { get; set; }
        public string Parentesco { get; set; }


    }
}
