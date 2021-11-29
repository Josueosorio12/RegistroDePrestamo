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
        public int PrestamoId { get; set; }
        public decimal Total { get; set; }
        public MorasDetalle(int moraId, int prestamoId, decimal total)
        {
            Id = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Total = total;
        }
    }
}
