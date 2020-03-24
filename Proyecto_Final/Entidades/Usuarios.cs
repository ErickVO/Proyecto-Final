﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
            Email = string.Empty;
        }

        public Usuarios(int usuarioId, string nombres, string nombreUsuario, string clave, string email)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Email = email;
        }
    }
}