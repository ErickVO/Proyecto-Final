using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.Contenedores
{
    public class ContenedorPagos
    {
        public Pagos pagos { get; set; }
        public PagosDetalle pagosDetalle { get; set; }
        public List<ListaPagos> listaPagos { get; set; }

        public ContenedorPagos()
        {
            pagos = new Pagos();
            pagosDetalle = new PagosDetalle();
            listaPagos = new List<ListaPagos>();
        }
    }
}
