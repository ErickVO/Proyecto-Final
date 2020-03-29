using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class CacaosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Cacaos cacaos = new Cacaos();

            cacaos.CacaoId = 0;
            cacaos.UsuarioId = 1;
            cacaos.EntradaId = 1;
            cacaos.Fecha = DateTime.Now;
            cacaos.Tipo = "Sanchéz";
            cacaos.Cantidad = 300.0m;

            bool paso = CacaosBLL.Guardar(cacaos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void comprarCacaoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EntradaValidaTest()
        {
            Assert.Fail();
        }
    }
}