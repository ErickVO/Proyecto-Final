using System;
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
    public partial class menuPrincipal : Window
    {
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        public menuPrincipal(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioTextBlock.Text = "Usuario: " + usuarioNombre;
        }

        //Registros

        private void RegistrarCacaoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCacaos rCacaos = new rCacaos(UsuarioId,UsuarioNombre);
            rCacaos.Show();
        }

        private void RegistrarClienteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rClientes rClientes = new rClientes(UsuarioId, UsuarioNombre);
            rClientes.Show();
        }

        private void RegistrarContratoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesBLL.ExisteCliente() && CacaosBLL.cacaoDisponible())
            {
                rContratos rContratos = new rContratos(UsuarioId, UsuarioNombre);
                rContratos.Show();
            }
            else
                MessageBox.Show("Necesita un cliente y un cacao con cantidad disponible");
        }

        private void RegistrarEntradaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(SuplidoresBLL.ExisteSuplidor() && CacaosBLL.ExisteCacao())
            {
                rEntradas rEntradas = new rEntradas(UsuarioId, UsuarioNombre);
                rEntradas.Show();
            }
            else
                MessageBox.Show("Necesita un suplidor y un cacao");
        }

        private void RegistrarPagoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (VentasBLL.ExisteVenta())
            {
                rPagos rPagos = new rPagos(UsuarioId, UsuarioNombre);
                rPagos.Show();
            }
            else
                MessageBox.Show("Necesita una venta");
        }

        private void RegistrarSuplidorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rSuplidores rSuplidores = new rSuplidores(UsuarioId, UsuarioNombre);
            rSuplidores.Show();
        }

        private void RegistrarUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios(UsuarioId, UsuarioNombre);
            rUsuarios.Show();
        }

        private void RegistrarVentaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ContratosBLL.ExisteContrato())
            {
                rVentas rVentas = new rVentas(UsuarioId, UsuarioNombre);
                rVentas.Show();
            }
            else
                MessageBox.Show("Necesita un contrato");
        }

        //Consultas

        private void ConsultarCacaosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCacaos cCacaos = new cCacaos();
            cCacaos.Show();
        }

        private void ConsultarClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show();
        }

        private void ConsultarContratosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cContratos cContratos = new cContratos();
            cContratos.Show();
        }

        private void ConsultarEntradasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEntradas cEntradas = new cEntradas();
            cEntradas.Show();
        }

        private void ConsultarPagosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPagos cPagos = new cPagos();
            cPagos.Show();
        }

        private void ConsultarSuplidoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cSuplidores = new cSuplidores();
            cSuplidores.Show();
        }

        private void ConsultarUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();
        }

        private void ConsultarVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }
    }
}
