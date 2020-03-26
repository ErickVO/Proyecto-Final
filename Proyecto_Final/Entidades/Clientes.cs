﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        [ForeignKey("ClienteId")]
        public virtual List<PagosDetalle> PagoDetalle { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;

            PagoDetalle = new List<PagosDetalle>();
        }

        public Clientes(int clienteId, int usuarioId, DateTime fecha, string nombres, string cedula, string telefono, string direccion, string email)
        {
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            Fecha = fecha;
            Nombres = nombres;
            Cedula = cedula;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
        }
    }
}
