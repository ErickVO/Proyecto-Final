using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }

        public Pagos()
        {
            PagoId = 0;
            UsuarioId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;

            PagoDetalle = new List<PagosDetalle>();
        }
    }
}
