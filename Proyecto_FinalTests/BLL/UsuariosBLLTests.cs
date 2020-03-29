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
            usuarios.Nombres = "El macho";
            usuarios.Fecha = DateTime.Now;
            usuarios.NombreUsuario = "Macho";
            usuarios.Clave = "Muy macho";
            usuarios.Email = "muy_macho@outlook.com";

            bool paso = UsuariosBLL.Guardar(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 2;
            usuarios.Nombres = "EL MACHO";
            usuarios.Fecha = DateTime.Now;
            usuarios.NombreUsuario = "Macho";
            usuarios.Clave = "Muy macho";
            usuarios.Email = "muy_macho@outlook.com";

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
            List<Usuarios> listado = new List<Usuarios>();

            Assert.IsTrue(listado != null);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 2;
            usuarios.Nombres = "EL MACHO";
            usuarios.Fecha = DateTime.Now;
            usuarios.NombreUsuario = "Macho";
            usuarios.Clave = "Muy macho";
            usuarios.Email = "muy_macho@outlook.com";

            bool paso = UsuariosBLL.Existe(usuarios);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ObtenerIdTest()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.UsuarioId = 0;
            usuarios.Nombres = "EL MACHO";
            usuarios.Fecha = DateTime.Now;
            usuarios.NombreUsuario = "Macho";
            usuarios.Clave = "Muy macho";
            usuarios.Email = "muy_macho@outlook.com";

            int id = UsuariosBLL.ObtenerId(usuarios);

            Assert.IsTrue(id == 2);
        }
    }
}