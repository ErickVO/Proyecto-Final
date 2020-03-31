using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    /*[TestClass()]
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
            Cacaos cacaos = new Cacaos();

            cacaos.CacaoId = 1;
            cacaos.UsuarioId = 1;
            cacaos.EntradaId = 1;
            cacaos.Fecha = DateTime.Now;
            cacaos.Tipo = "Sanchéz";
            cacaos.Cantidad = 400.0m;

            bool paso = CacaosBLL.Modificar(cacaos);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Cacaos cacaos = CacaosBLL.Buscar(1);

            Assert.IsTrue(cacaos != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = CacaosBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Cacaos> listado = new List<Cacaos>();

            Assert.IsTrue(listado != null);
        }

        [TestMethod()]
        public void comprarCacaoTest()
        {
            bool paso = CacaosBLL.comprarCacao(200);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void EntradaValidaTest()
        {
            Cacaos cacaos = new Cacaos();

            cacaos.CacaoId = 0;
            cacaos.UsuarioId = 1;
            cacaos.EntradaId = 2;
            cacaos.Fecha = DateTime.Now;
            cacaos.Tipo = "Sanchéz";
            cacaos.Cantidad = 300.0m;

            bool paso = CacaosBLL.EntradaValida(cacaos);

            Assert.IsTrue(paso);
        }
    }*/
}