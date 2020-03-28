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
using Proyecto_Final.Entidades;
using Proyecto_Final.BLL;
using Proyecto_Final.UI.Consultas;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RClientes.xaml
    /// </summary>
    public partial class RClientes : Window
    {
        Clientes cliente = new Clientes();
        public int UsuarioId { get; set; }
        public RClientes(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            this.DataContext = cliente;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (cliente.UsuarioId == 0)
                cliente.UsuarioId = UsuarioId;

            if (cliente.ClienteId == 0)
            {
                paso = ClientesBLL.Guardar(cliente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un cliente que no existe");
                    return;
                }
                paso = ClientesBLL.Modificar(cliente);
            }

            if (paso)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes AnteriorCliente = ClientesBLL.Buscar(cliente.ClienteId);

            if (AnteriorCliente != null)
            {
                cliente = AnteriorCliente;
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesBLL.Eliminar(cliente.ClienteId))
            {
                limpiar();
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar un Cliente que no existe");
        }

        private void ConsultarClientesButton_Click(object sender, RoutedEventArgs e)
        {
            CClientes cClientes = new CClientes();
            cClientes.Show();
        }

        private void limpiar()
        {
            cliente = new Clientes();
            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = cliente;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Clientes AnteriorCliente = ClientesBLL.Buscar(cliente.ClienteId);

            return (AnteriorCliente != null);
        }
    }
}
