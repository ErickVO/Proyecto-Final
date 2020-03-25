using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> VentaDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            VentaDetalle = new List<VentasDetalle>();
        }

        public Ventas(int ventaId, int usuarioId, DateTime fecha, List<VentasDetalle> ventaDetalle)
        {
            VentaId = ventaId;
            UsuarioId = usuarioId;
            Fecha = fecha;
            VentaDetalle = ventaDetalle;
        }
    }
}
