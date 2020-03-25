using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class Contratos
    {
        [Key]
        public int ContratoId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal CantidadTotal { get; set; }

        [ForeignKey("ContratoId")]
        public virtual List<VentasDetalle> VentaDetalle { get; set; }

        public Contratos()
        {
            ContratoId = 0;
            UsuarioId = 0;
            ClienteId = 0;
            FechaCreacion = DateTime.Now;
            FechaVencimiento = DateTime.Now;
            VentaDetalle = new List<VentasDetalle>();
        }

        public Contratos(int contratoId, int usuarioId, int clienteId, DateTime fechaCreacion, DateTime fechaVencimiento, decimal cantidadTotal)
        {
            ContratoId = contratoId;
            UsuarioId = usuarioId;
            ClienteId = clienteId;
            FechaCreacion = fechaCreacion;
            FechaVencimiento = fechaVencimiento;
            CantidadTotal = cantidadTotal;
        }
    }
}
