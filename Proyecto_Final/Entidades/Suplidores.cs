using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioId { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioId = 0;
        }

        public Suplidores(int suplidorId, DateTime fecha, string nombres, string direccion, string email, string telefono, string celular, string cedula, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
        {
            SuplidorId = suplidorId;
            Fecha = fecha;
            Nombres = nombres;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            Celular = celular;
            Cedula = cedula;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioId = usuarioId;
        }
    }
}
