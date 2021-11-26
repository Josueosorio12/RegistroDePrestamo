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
        public float Interes { get; set; }
        public float Capital { get; set; }
        public float Total { get; set; }
    }
}
