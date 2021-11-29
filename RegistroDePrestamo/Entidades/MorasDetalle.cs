using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.Entidades
{
    public class MorasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int Prestamoid { get; set; }
        public int Total { get; set; }
        public MorasDetalle(int moraId, int prestamoid, int total)
        {
            Id = 0;
            MoraId = moraId;
            Prestamoid = prestamoid;
            Total = total;
        }
    }
}
