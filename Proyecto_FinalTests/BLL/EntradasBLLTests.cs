using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class EntradasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Entradas e = new Entradas();
            e.EntradaId = 0;
            e.SuplidorId = 1;
            e.UsuarioId = 1;
            e.Cantidad = 500;
            e.Fecha = DateTime.Now;
            paso = EntradasBLL.Guardar(e);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Entradas e = new Entradas();
            e.EntradaId = 2;
            e.SuplidorId = 1;
            e.UsuarioId = 1;
            e.Cantidad = 500;
            e.Fecha = DateTime.Now;
            paso = EntradasBLL.Modificar(e);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Entradas e = new Entradas();
            e = EntradasBLL.Buscar(2);

            Assert.AreEqual(e, e);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = EntradasBLL.Eliminar(2);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Entradas>();
            listado = EntradasBLL.GetList(e => true);
            Assert.AreEqual(listado, listado);
        }
    }
}