using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentaDetalle { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Total = 0.0m;
            Balance = 0.0m;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;

            VentaDetalle = new List<VentasDetalle>();
            PagoDetalle = new List<PagosDetalle>();
        }

        public Ventas(int ventaId, DateTime fecha, int clienteId, decimal total, decimal balance, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId, List<VentasDetalle> ventaDetalle, List<PagosDetalle> pagoDetalle)
        {
            VentaId = ventaId;
            Fecha = fecha;
            ClienteId = clienteId;
            Total = total;
            Balance = balance;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
            VentaDetalle = ventaDetalle;
            PagoDetalle = pagoDetalle;
        }
    }
}
