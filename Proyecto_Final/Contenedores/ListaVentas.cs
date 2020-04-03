using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Final.Contenedores
{
    public class ListaVentas
    {
        public int ContratoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Total { get; set; }

        public ListaVentas()
        {
            ContratoId = 0;
            Cantidad = 0;
            Total = 0;
        }

        public ListaVentas(int contratoId, decimal cantidad, decimal importe)
        {
            ContratoId = contratoId;
            Cantidad = cantidad;
            Importe = importe;
            Total = 0;
        }

        public ListaVentas(int contratoId, decimal cantidad, decimal importe, decimal total)
        {
            ContratoId = contratoId;
            Cantidad = cantidad;
            Importe = importe;
            Total = total;
        }
    }
}
