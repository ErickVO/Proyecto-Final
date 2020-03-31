using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    /*[TestClass()]
    public class SuplidoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Suplidores s = new Suplidores();
            s.SuplidorId = 0;
            s.UsuarioId = 1;
            s.Nombres = "Luis David";
            s.Telefono = " 829566 ";
            s.Cedula = " 056 ";
            s.Direccion = " Duarte ";
            s.Fecha = DateTime.Now;
            paso = SuplidoresBLL.Guardar(s);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Suplidores s = new Suplidores();
            s.SuplidorId = 2;
            s.UsuarioId = 1;
            s.Nombres = "Luis David Sanchez";
            s.Telefono = " 829566 ";
            s.Cedula = " 056 ";
            s.Direccion = " Duarte ";
            s.Fecha = DateTime.Now;
            paso = SuplidoresBLL.Guardar(s);

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
    }*/
}