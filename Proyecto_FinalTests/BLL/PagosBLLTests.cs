using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class PagosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Pagos pagos = new Pagos();

            pagos.PagoId = 0;
            pagos.Fecha = DateTime.Now;
            pagos.ClienteId = 1;
            pagos.Total = 800.0m;
            pagos.UsuarioId = 1;
            pagos.FechaCreacion = DateTime.Now;
            pagos.FechaModificacion = DateTime.Now;
            pagos.PagoDetalle.Add(new PagosDetalle(0, 1, 800.0m, 400.0m));

            bool paso = PagosBLL.Guardar(pagos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Pagos pagos = new Pagos();

            pagos.PagoId = 1;
            pagos.ClienteId = 1;
            pagos.Total = 1000.0m;
            pagos.UsuarioId = 1;
            pagos.FechaModificacion = DateTime.Now;
            pagos.PagoDetalle.Add(new PagosDetalle(0, 1, 800.0m, 400.0m));
            pagos.PagoDetalle.Add(new PagosDetalle(0, 1, 200.0m, 200.0m));

            bool paso = PagosBLL.Modificar(pagos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Pagos pagos = PagosBLL.Buscar(1);

            Assert.IsTrue(pagos != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = PagosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Pagos> listado = PagosBLL.GetList(p => true);

            Assert.IsTrue(listado != null);
        }

        [TestMethod()]
        public void PagoDeVentaTest()
        {
            Pagos pago = PagosBLL.PagoDeVenta(1);

            Assert.IsTrue(pago != null);
        }

        [TestMethod()]
        public void ExistePagoTest()
        {
            bool paso = PagosBLL.ExistePago();

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EntradaValidaTest()
        {
            Pagos pagos = new Pagos();

            pagos.PagoId = 0;
            pagos.Fecha = DateTime.Now;
            pagos.ClienteId = 1;
            pagos.Total = 600.0m;
            pagos.UsuarioId = 1;
            pagos.FechaCreacion = DateTime.Now;
            pagos.FechaModificacion = DateTime.Now;
            pagos.PagoDetalle.Add(new PagosDetalle(0, 1, 600.0m, 600.0m));

            bool paso = PagosBLL.EntradaValida(pagos);

            Assert.IsTrue(paso);
        }
    }
}