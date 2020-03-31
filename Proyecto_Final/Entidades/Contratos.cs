using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class Contratos
    {
        [Key]
        public int ContratoId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int CacaoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public decimal CantidadPendiente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("ContratoId")]
        public virtual List<VentasDetalle> VentaDetalle { get; set; }

        public Contratos()
        {
            ContratoId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            FechaVencimiento = DateTime.Now;
            CacaoId = 0;
            Cantidad = 0.0m;
            Precio = 0.0m;
            Total = 0.0m;
            CantidadPendiente = 0.0m;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;

            VentaDetalle = new List<VentasDetalle>();
        }

        public Contratos(int contratoId, DateTime fecha, int clienteId, DateTime fechaVencimiento, int cacaoId, decimal cantidad, decimal precio, decimal total, decimal cantidadPendiente, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId, List<VentasDetalle> ventaDetalle)
        {
            ContratoId = contratoId;
            Fecha = fecha;
            ClienteId = clienteId;
            FechaVencimiento = fechaVencimiento;
            CacaoId = cacaoId;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
            CantidadPendiente = cantidadPendiente;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
            VentaDetalle = ventaDetalle;
        }
    }
}
