using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
   public class PrestamoDetalle
    {
        [Key]

        public int Id { get; set; }
        public int Prestamoid { get; set; }
      //  public Cuota TipoCuota { get; set; }
        public int NumeroCuota { get; set; }
        public float MontoCuota { get; set; }
        public float TotalIntereses { get; set; }
        public float MontoTotal { get; set; }


        public Prestamos Prestamos { get; set; }

        public PrestamoDetalle()
        {
            Id = 0;
            Prestamoid = 0;
            NumeroCuota = 0;
            MontoCuota = 0;
            TotalIntereses = 0;
            MontoTotal = 0;

        }

        public PrestamoDetalle(int prestamoid, int numerocuota, float montototal, float totalinteres, float montocuota)
        {
            Id = 0;
            Prestamoid = prestamoid;
            NumeroCuota = numerocuota;
            MontoTotal = montototal;
            TotalIntereses = totalinteres;
            MontoCuota = montocuota;



        }
    }
}

