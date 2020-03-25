using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class ContenedorVentas
    {
        public Ventas ventas { get; set; }
        public VentasDetalle ventasDetalle { get; set; }

        public ContenedorVentas()
        {
            ventas = new Ventas();
            ventasDetalle = new VentasDetalle();
        }
    }
}
