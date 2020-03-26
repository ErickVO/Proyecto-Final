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
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public decimal Cantidad { get; set; }

        public Cacaos()
        {
            CacaoId = 0;
            EntradaId = 0;
            Fecha = DateTime.Now;
            Tipo = string.Empty;
            Cantidad = 0.0m;
        }

        public Cacaos(int cacaoId, int entradaId, DateTime fecha, string tipo, decimal cantidad)
        {
            CacaoId = cacaoId;
            EntradaId = entradaId;
            Fecha = fecha;
            Tipo = tipo;
            Cantidad = cantidad;
        }
    }
}
