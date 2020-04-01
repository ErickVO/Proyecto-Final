using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Final.Contenedores
{
    public class ListaPagos
    {
        public int PagoId { get; set; }
        public int VentaId { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }

        public ListaPagos()
        {
            PagoId = 0;
            VentaId = 0;
            Monto = 0.0m;
            Saldo = 0.0m;
        }

        public ListaPagos(int pagoId, int ventaId, decimal monto)
        {
            PagoId = pagoId;
            VentaId = ventaId;
            Monto = monto;
            Saldo = 0.0m;
        }

        public ListaPagos(int pagoId, int ventaId, decimal monto, decimal saldo)
        {
            PagoId = pagoId;
            VentaId = ventaId;
            Monto = monto;
            Saldo = saldo;
        }
    }
}
