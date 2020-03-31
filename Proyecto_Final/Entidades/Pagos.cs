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
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("PagoId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }

        public Pagos()
        {
            PagoId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Total = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;

            PagoDetalle = new List<PagosDetalle>();
        }

        public Pagos(int pagoId, DateTime fecha, int clienteId, decimal total, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId, List<PagosDetalle> pagoDetalle)
        {
            PagoId = pagoId;
            Fecha = fecha;
            ClienteId = clienteId;
            Total = total;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
            PagoDetalle = pagoDetalle;
        }
    }
}
