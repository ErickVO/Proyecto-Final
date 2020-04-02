using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Suplidores s = new Suplidores();
            s.SuplidorId = 0;
            s.Fecha = DateTime.Now;
            s.Nombres = "Luis David";
            s.Direccion = " Duarte ";
            s.Email = "ag@dn.com";
            s.Telefono = " 829566 ";
            s.Celular = "33333333";
            s.Cedula = " 056 ";
            s.FechaCreacion = DateTime.Now;
            s.FechaModificacion = DateTime.Now;
            s.UsuarioId = 1;
            paso = SuplidoresBLL.Guardar(s);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;

            Suplidores s = new Suplidores();
            s.SuplidorId = 0;
            s.Fecha = DateTime.Now;
            s.Nombres = "Luis David";
            s.Direccion = " Duarte ";
            s.Email = "Klk@outlook.com";
            s.Telefono = " 829566 ";
            s.Celular = "33333333";
            s.Cedula = " 056 ";
            s.FechaCreacion = DateTime.Now;
            s.FechaModificacion = DateTime.Now;
            s.UsuarioId = 1;

            paso = SuplidoresBLL.Modificar(s);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Suplidores s = new Suplidores();
            s = SuplidoresBLL.Buscar(2);

            Assert.AreEqual(s, s);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = SuplidoresBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Suplidores>();
            listado = SuplidoresBLL.GetList(s => true);
            Assert.AreEqual(listado, listado);
        }

        [TestMethod()]
        public void ExisteSuplidorTest()
        {
            bool paso;

            paso = SuplidoresBLL.ExisteSuplidor();

            Assert.IsTrue(paso);
        }
    }
}