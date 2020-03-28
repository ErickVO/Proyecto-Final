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
        public int ClienteId { get; set; }
        public string TipoCacao { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }

        public PagosDetalle()
        {
            PagoDetalleId = 0;
            PagoId = 0;
            ClienteId = 0;
            TipoCacao = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }

        public PagosDetalle(int clienteId, string tipoCacao, decimal cantidad, decimal precio)
        {
            PagoDetalleId = 0;
            PagoId = 0;
            ClienteId = clienteId;
            TipoCacao = tipoCacao;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
