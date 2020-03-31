using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    /*[TestClass()]
    public class PagosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Pagos pagos = new Pagos();

            pagos.PagoId = 0;
            pagos.UsuarioId = 1;
            pagos.Fecha = DateTime.Now;
            pagos.Monto = 1200.0m;
            pagos.PagoDetalle.Add(new PagosDetalle(1, "Sanchéz", 10.0m, 120.0m));

            bool paso = PagosBLL.Guardar(pagos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Pagos pagos = new Pagos();

            pagos.PagoId = 1;
            pagos.UsuarioId = 1;
            pagos.Fecha = DateTime.Now;
            pagos.Monto = 2400.0m;
            pagos.PagoDetalle.Add(new PagosDetalle(1, "Sanchéz", 10.0m, 120.0m));
            pagos.PagoDetalle.Add(new PagosDetalle(1, "Orgánico", 30.0m, 40.0m));

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
            List<Pagos> listado = new List<Pagos>();

            Assert.IsTrue(listado != null);
        }
    }*/
}