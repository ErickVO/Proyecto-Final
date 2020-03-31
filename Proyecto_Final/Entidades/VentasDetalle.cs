using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ContratoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ContratoId = 0;
            Cantidad = 0;
            Precio = 0;
        }

        public VentasDetalle(int ventaDetalleId, int ventaId, int contratoId, decimal cantidad, decimal precio)
        {
            VentaDetalleId = ventaDetalleId;
            VentaId = ventaId;
            ContratoId = contratoId;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
