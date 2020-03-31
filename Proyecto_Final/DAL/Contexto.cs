using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cacaos> Cacaos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Contratos> Contratos { get; set; }
        public DbSet<Entradas> Entradas { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Cacao.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { UsuarioId = 1, Fecha = DateTime.Now, Nombres = "Administrador", NombreUsuario="Admin", Clave = "Admin", Email = "Admin@outlook.com", FechaCreacion = DateTime.Now, FechaModificacion = DateTime.Now, UsuarioIdCreacion = 1});
        }
    }
}
