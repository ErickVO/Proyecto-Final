using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.Fecha = DateTime.Now;
            usuarios.Nombres = "El macho";
            usuarios.NombreUsuario = "Macho";
            usuarios.Clave = "Muy macho";
            usuarios.Email = "muy_macho@outlook.com";
            usuarios.FechaCreacion = DateTime.Now;
            usuarios.FechaModificacion = DateTime.Now;
            usuarios.UsuarioIdCreacion = 1;

            bool paso = UsuariosBLL.Guardar(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 2;
            usuarios.Nombres = "EL MACHO";
            usuarios.NombreUsuario = "Macho";
            usuarios.Clave = "Muy macho";
            usuarios.Email = "muy_macho@outlook.com";
            usuarios.FechaModificacion = DateTime.Now;
            usuarios.UsuarioIdCreacion = 1;

            bool paso = UsuariosBLL.Modificar(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Usuarios usuarios = UsuariosBLL.Buscar(2);

            Assert.IsTrue(usuarios != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = UsuariosBLL.Eliminar(2);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Usuarios> listado = UsuariosBLL.GetList(u => true);

            Assert.IsTrue(listado != null);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = UsuariosBLL.Existe("Macho", "Muy macho");

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ObtenerIdTest()
        {
            int id = UsuariosBLL.ObtenerId("Macho", "Muy macho");

            Assert.IsTrue(id == 2);
        }
    }
}