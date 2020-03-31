using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Entidades
{
    public class Entradas
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public int CacaoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Entradas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            CacaoId = 0;
            Cantidad = 0;
            Costo = 0;
            Total = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }

        public Entradas(int entradaId, DateTime fecha,int suplidorId, int cacaoId, decimal cantidad, decimal costo, decimal total, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
        {
            EntradaId = entradaId;
            Fecha = fecha;
            SuplidorId = suplidorId;
            CacaoId = cacaoId;
            Cantidad = cantidad;
            Costo = costo;
            Total = total;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
        }
    }
}
