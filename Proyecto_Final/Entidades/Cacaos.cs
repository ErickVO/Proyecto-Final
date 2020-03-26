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
        public string Tipo { get; set; }
        public decimal Cantidad { get; set; }

        public Cacaos()
        {
            CacaoId = 0;
            EntradaId = 0;
            Tipo = string.Empty;
            Cantidad = 0;
        }

        public Cacaos(int cacaoId, int entradaId, string tipo, decimal cantidad)
        {
            CacaoId = cacaoId;
            EntradaId = entradaId;
            Tipo = tipo;
            Cantidad = cantidad;
        }
    }
}
