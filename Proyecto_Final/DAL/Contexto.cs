using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
