using System;
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
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }

        public Clientes(int clienteId, DateTime fecha, string nombres, string cedula, string telefono, string celular, string direccion, string email, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
        {
            ClienteId = clienteId;
            Fecha = fecha;
            Nombres = nombres;
            Cedula = cedula;
            Telefono = telefono;
            Celular = celular;
            Direccion = direccion;
            Email = email;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
        }
    }
}
