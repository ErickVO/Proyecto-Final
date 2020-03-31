﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proyecto_Final.UI.Registros;
using Proyecto_Final.UI.Consultas;
using Proyecto_Final.BLL;

namespace Proyecto_Final.UI.Menu
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        public MenuPrincipal(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
        }

        private void RegistrarCacaoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RCacaos rCacaos = new RCacaos(UsuarioId,UsuarioNombre);
            rCacaos.Show();
        }

        private void RegistrarClienteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RClientes rClientes = new RClientes(UsuarioId);
            rClientes.Show();
        }

        private void RegistrarContratoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RContratos rContratos = new RContratos(UsuarioId);
            rContratos.Show();
        }

        private void RegistrarEntradaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            REntradas rEntradas = new REntradas(UsuarioId);
            rEntradas.Show();
        }

        private void RegistrarPagoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //RPagos rPagos = new RPagos(UsuarioId);
            //rPagos.Show();
        }

        private void RegistrarSuplidorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RSuplidores rSuplidores = new RSuplidores(UsuarioId);
            rSuplidores.Show();
        }

        private void RegistrarUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RUsuarios rUsuarios = new RUsuarios(UsuarioId);
            rUsuarios.Show();
        }

        private void RegistrarVentaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RVentas rVentas = new RVentas(UsuarioId);
            rVentas.Show();
        }

        private void ConsultarCacaosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CCacaos cCacaos = new CCacaos();
            cCacaos.Show();
        }

        private void ConsultarClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CClientes cClientes = new CClientes();
            cClientes.Show();
        }

        private void ConsultarContratosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CContratos cContratos = new CContratos();
            cContratos.Show();
        }

        private void ConsultarEntradasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CEntradas cEntradas = new CEntradas();
            cEntradas.Show();
        }

        private void ConsultarPagosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CPagos cPagos = new CPagos();
            cPagos.Show();
        }

        private void ConsultarSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CSuplidores cSuplidores = new CSuplidores();
            cSuplidores.Show();
        }

        private void ConsultarUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CUsuarios cUsuarios = new CUsuarios();
            cUsuarios.Show();
        }

        private void ConsultarVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CVentas cVentas = new CVentas();
            cVentas.Show();
        }
    }
}
