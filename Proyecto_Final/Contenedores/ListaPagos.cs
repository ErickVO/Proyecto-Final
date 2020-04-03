using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Final.Contenedores
{
    public class ListaPagos
    {
        public int VentaId { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }

        public ListaPagos()
        {
            VentaId = 0;
            Monto = 0.0m;
            Saldo = 0.0m;
        }

        public ListaPagos(int ventaId, decimal monto)
        {
            VentaId = ventaId;
            Monto = monto;
            Saldo = 0.0m;
        }

        public ListaPagos(int ventaId, decimal monto, decimal saldo)
        {
            VentaId = ventaId;
            Monto = monto;
            Saldo = saldo;
        }
    }
}
