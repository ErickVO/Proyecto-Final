using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class PagosDetalle
    {
        [Key]
        public int PagoDetalleId { get; set; }
        public int PagoId { get; set; }
        public int VentaId { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }

        public PagosDetalle()
        {
            PagoDetalleId = 0;
            PagoId = 0;
            VentaId = 0;
            Monto = 0.0m;
            Saldo = 0.0m;
        }

        public PagosDetalle(int ventaId, decimal monto, decimal saldo)
        {
            PagoDetalleId = 0;
            PagoId = 0;
            VentaId = ventaId;
            Monto = monto;
            Saldo = saldo;
        }
    }
}
