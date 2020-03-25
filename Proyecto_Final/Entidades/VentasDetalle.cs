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
        public decimal CantidadCacao { get; set; }

        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ContratoId = 0;
            CantidadCacao = 0;
        }

        public VentasDetalle(int ventaId, int contratoId, decimal cantidadCacao)
        {
            VentaDetalleId = 0;
            VentaId = ventaId;
            ContratoId = contratoId;
            CantidadCacao = cantidadCacao;
        }
    }
}
