using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Entidades
{
    public class Cacaos
    {
        [Key]
        public int CacaoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Cacaos()
        {
            CacaoId = 0;
            Fecha = DateTime.Now;
            Tipo = string.Empty;
            Cantidad = 0.0m;
            Costo = 0.0m;
            Precio = 0.0m;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }

        public Cacaos(int cacaoId, DateTime fecha, string tipo, decimal cantidad, decimal costo, decimal precio, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
        {
            CacaoId = cacaoId;
            Fecha = fecha;
            Tipo = tipo ;
            Cantidad = cantidad;
            Costo = costo;
            Precio = precio;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
        }
    }
}
