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
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
        }

        public Suplidores(int suplidorId, int usuarioId, string nombres, string direccion, string email, string telefono, string cedula)
        {
            SuplidorId = suplidorId;
            UsuarioId = usuarioId;
            Nombres = nombres;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            Cedula = cedula;
        }
    }
}
