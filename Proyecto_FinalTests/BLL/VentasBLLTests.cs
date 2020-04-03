using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;

            Ventas v = new Ventas();
            
            v.VentaId = 1;
            v.Fecha = DateTime.Now;
            v.ClienteId = 1;
            v.Total = 100;
            v.Balance = 100;
            v.FechaCreacion = DateTime.Now;
            v.FechaModificacion = DateTime.Now;
            v.UsuarioId = 1;
            v.VentaDetalle.Add(new VentasDetalle(v.VentaId, 1, 500, 3000));

            paso = VentasBLL.Guardar(v);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;

            Ventas v = new Ventas();

            v.VentaId = 0;
            v.Fecha = DateTime.Now;
            v.ClienteId = 1;
            v.Total = 1000;
            v.Balance = 100;
            v.FechaCreacion = DateTime.Now;
            v.FechaModificacion = DateTime.Now;
            v.UsuarioId = 1;
            v.VentaDetalle.Add(new VentasDetalle(v.VentaId, 1, 500, 3000));

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
        public void ExisteVentaTest()
        {
            bool paso;

            paso = VentasBLL.ExisteVenta();

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EntradaValidaTest()
        {
            bool paso = false;

            Ventas ventas = VentasBLL.Buscar(1);

            paso = VentasBLL.EntradaValida(ventas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void RestarBalanceTest()
        {
            bool paso = false;

            decimal balance;

            Ventas v = VentasBLL.Buscar(1);

            balance = v.Balance;

            VentasBLL.RestarBalance(v.VentaId, 300);

            if (balance < v.Balance)
                paso = true;

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void RestablecerBalanceTest(int id)
        {
            bool paso = false;

            decimal balance;

            Ventas v = VentasBLL.Buscar(1);

            balance = v.Balance;

            VentasBLL.RestablecerBalance(v.VentaId);

            if (balance > v.Balance)
                paso = true;

            Assert.IsTrue(paso);
        }
    }
}