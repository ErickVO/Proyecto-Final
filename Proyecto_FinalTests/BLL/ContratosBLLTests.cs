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
            c.Fecha = DateTime.Now;
            c.ClienteId = 1;
            c.FechaVencimiento = Convert.ToDateTime("28/04/2020");
            c.CacaoId = 1;
            c.Cantidad = 500;
            c.Precio = 300;
            c.FechaCreacion = DateTime.Now;
            c.FechaModificacion = DateTime.Now;
            c.UsuarioId = 1;

            paso = ContratosBLL.Guardar(c);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;

            Contratos c = new Contratos();
            c.ContratoId = 1;
            c.Fecha = DateTime.Now;
            c.ClienteId = 1;
            c.FechaVencimiento = Convert.ToDateTime("27/04/2020");
            c.CacaoId = 1;
            c.Cantidad = 500;
            c.Precio = 300;
            c.FechaCreacion = DateTime.Now;
            c.FechaModificacion = DateTime.Now;
            c.UsuarioId = 1;

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
        public void ExisteContratoTest()
        {
            bool paso;

            paso = ContratosBLL.ExisteContrato();

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void RestarCantidadTest()
        {
            bool paso = false;

            decimal cantidad;

            Contratos c = ContratosBLL.Buscar(1);

            cantidad = c.CantidadPendiente;

            ContratosBLL.RestarCantidad(c.ContratoId, cantidad);

            if (cantidad > c.CantidadPendiente)
                paso = true;

            Assert.IsTrue(paso);
        }
    }
}