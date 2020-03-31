using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioIdCreacion { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            Email = string.Empty;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
            UsuarioIdCreacion = 0;
        }

        public Usuarios(int usuarioId, DateTime fecha, string nombres, string nombreUsuario, string clave, string email, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioIdCreacion)
        {
            UsuarioId = usuarioId;
            Fecha = fecha;
            Nombres = nombres;
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Email = email;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            UsuarioIdCreacion = usuarioIdCreacion;
        }
    }
}
