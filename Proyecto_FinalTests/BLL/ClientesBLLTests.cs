﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto_Final.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = 0;
            clientes.Fecha = DateTime.Now;
            clientes.Nombres = "Alfredo";
            clientes.Cedula = "234-6583756-9";
            clientes.Telefono = "809-422-2485";
            clientes.Celular = "829-573-5783";
            clientes.Direccion = "Los mellos";
            clientes.Email = "Jabon_cuchara@outlook.com";
            clientes.FechaCreacion = DateTime.Now;
            clientes.FechaModificacion = DateTime.Now;
            clientes.UsuarioId = 1;

            bool paso = ClientesBLL.Guardar(clientes);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Clientes clientes = new Clientes();

            clientes.ClienteId = 1;
            clientes.Nombres = "Alfredo Weyne";
            clientes.Cedula = "234-6583756-9";
            clientes.Telefono = "809-422-2485";
            clientes.Celular = "829-573-5783";
            clientes.Direccion = "Los mellos";
            clientes.Email = "Jabon_cuchara@outlook.com";
            clientes.FechaModificacion = DateTime.Now;
            clientes.UsuarioId = 1;

            bool paso = ClientesBLL.Modificar(clientes);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Clientes clientes = ClientesBLL.Buscar(1);

            Assert.IsTrue(clientes != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = ClientesBLL.Eliminar(1);

            Assert.IsTrue(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Clientes> listado = ClientesBLL.GetList(c => true);

            Assert.IsTrue(listado != null);
        }

        [TestMethod()]
        public void ExisteClienteTest()
        {
            bool paso = ClientesBLL.ExisteCliente();

            Assert.IsTrue(paso);
        }
    }
}