using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class ContratosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;

            Contratos c = new Contratos();
            c.ContratoId = 1;
            c.UsuarioId = 1;
            c.ClienteId = 1;
            c.FechaCreacion = DateTime.Now;
            c.FechaVencimiento = Convert.ToDateTime("04/28/2020");
            c.CantidadTotal = 500;

            paso = ContratosBLL.Guardar(c);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;

            Contratos c = new Contratos();
            c.ContratoId = 1;
            c.UsuarioId = 1;
            c.ClienteId = 1;
            c.FechaCreacion = DateTime.Now;
            c.FechaVencimiento = Convert.ToDateTime("27/04/2020");
            c.CantidadTotal = 400;

            paso = ContratosBLL.Modificar(c);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Contratos contratos = ContratosBLL.Buscar(1);

            Assert.AreEqual(contratos, contratos);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = ContratosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Contratos>();
            listado = ContratosBLL.GetList(s => true);
            Assert.AreEqual(listado, listado);
        }

        [TestMethod()]
        public void verificarPagoTest()
        {
            bool paso = false;
            Clientes clientes = ClientesBLL.Buscar(1);

            paso = ContratosBLL.verificarPago(clientes.ClienteId, 500);

            Assert.AreEqual(paso, true);
        }
    }
}