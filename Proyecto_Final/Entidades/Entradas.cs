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
        public int UsuarioId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }

        public Entradas()
        {
            EntradaId = 0;
            UsuarioId = 0;
            SuplidorId = 0;
            Fecha = DateTime.Now;
            Cantidad = 0;
        }

        public Entradas(int entradaId, int usuarioId, int suplidorId, DateTime fecha, int cantidad)
        {
            EntradaId = entradaId;
            UsuarioId = usuarioId;
            SuplidorId = suplidorId;
            Fecha = fecha;
            Cantidad = cantidad;
        }
    }
}
