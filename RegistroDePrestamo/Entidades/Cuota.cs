using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
    public class Cuota
    {
        [Key]

        public int IdCuota { get; set; }
        public Prestamos oPrestamo { get; set; }
        public int NumeroCuota { get; set; }
        public string FechaPagoCuota { get; set; }
        public float MontoCuota { get; set; }
        public string EstadoCuota { get; set; }
        public int ProximoPago { get; set; }
    }
}
