using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Contenedores
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
