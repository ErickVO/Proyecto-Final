using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    /*[TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;

            Ventas v = new Ventas();
            
            v.VentaId = 0;
            v.UsuarioId = 1;
            v.Fecha = DateTime.Now;
            v.VentaDetalle.Add(new VentasDetalle(v.VentaId, 1, 500));

            paso = VentasBLL.Guardar(v);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;

            Ventas v = new Ventas();

            v.VentaId = 0;
            v.UsuarioId = 1;
            v.Fecha = DateTime.Now;
            v.VentaDetalle.Add(new VentasDetalle(v.VentaId, 1, 100));

            paso = VentasBLL.Modificar(v);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ventas v = VentasBLL.Buscar(1);

            Assert.AreEqual(v, v);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = VentasBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Ventas>();
            listado = VentasBLL.GetList(s => true);
            Assert.AreEqual(listado, listado);
        }

        [TestMethod()]
        public void BuscarCantidadTotalTest()
        {
            bool paso = false;
            decimal cantidad = 0;
            Contratos contratos = ContratosBLL.Buscar(1);

            cantidad = VentasBLL.BuscarCantidadTotal(contratos.ContratoId);

            if (contratos.CantidadTotal == cantidad)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EntradaValidaTest()
        {
            bool paso = false;

            Ventas ventas = VentasBLL.Buscar(1);

            paso = VentasBLL.EntradaValida(ventas);

            Assert.AreEqual(paso, true);
        }
    }*/
}