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

        //Registros

        private void RegistrarCacaoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RCacaos rCacaos = new RCacaos(UsuarioId,UsuarioNombre);
            rCacaos.Show();
        }

        private void RegistrarClienteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RClientes rClientes = new RClientes(UsuarioId, UsuarioNombre);
            rClientes.Show();
        }

        private void RegistrarContratoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesBLL.ExisteCliente() && EntradasBLL.ExisteEntrada())
            {
                RContratos rContratos = new RContratos(UsuarioId, UsuarioNombre);
                rContratos.Show();
            }
            else
                MessageBox.Show("Necesita un cliente y una entrada");
        }

        private void RegistrarEntradaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(SuplidoresBLL.ExisteSuplidor() && CacaosBLL.ExisteCacao())
            {
                REntradas rEntradas = new REntradas(UsuarioId, UsuarioNombre);
                rEntradas.Show();
            }
            else
                MessageBox.Show("Necesita un suplidor y un cacao");
        }

        private void RegistrarPagoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (VentasBLL.ExisteVenta())
            {
                RPagos rPagos = new RPagos(UsuarioId, UsuarioNombre);
                rPagos.Show();
            }
            else
                MessageBox.Show("Necesita una venta");
        }

        private void RegistrarSuplidorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RSuplidores rSuplidores = new RSuplidores(UsuarioId, UsuarioNombre);
            rSuplidores.Show();
        }

        private void RegistrarUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RUsuarios rUsuarios = new RUsuarios(UsuarioId, UsuarioNombre);
            rUsuarios.Show();
        }

        private void RegistrarVentaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ContratosBLL.ExisteContrato())
            {
                RVentas rVentas = new RVentas(UsuarioId, UsuarioNombre);
                rVentas.Show();
            }
            else
                MessageBox.Show("Necesita un contrato");
        }

        //Consultas

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
