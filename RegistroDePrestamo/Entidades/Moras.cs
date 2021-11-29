using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }

        [ForeignKey("MoraId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();
    }
}
