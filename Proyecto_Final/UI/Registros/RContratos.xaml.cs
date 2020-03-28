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
using Proyecto_Final.BLL;
using Proyecto_Final.Entidades;
using Proyecto_Final.UI.Consultas;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RContratos.xaml
    /// </summary>
    public partial class RContratos : Window
    {
        Contratos contrato = new Contratos();
        private int UsuarioId { get; set; }
        public RContratos(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = contrato;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            ClienteIdTextBox.Text = "0";
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = contrato;
        }

        private void Limpiar()
        {
            contrato = new Contratos();
            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Contratos contratoAnterior = ContratosBLL.Buscar(contrato.ContratoId);
            return contratoAnterior != null;
        }

        private bool ExisteEnlaBaseDeDatosClientes()
        {
            Clientes AnteriorCliente = ClientesBLL.Buscar(contrato.ClienteId);

            return (AnteriorCliente != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if(!ExisteEnlaBaseDeDatosClientes())
            {
                MessageBox.Show("ClienteId No Existe");
                ClienteIdTextBox.Focus();
                return;
            }

            contrato.UsuarioId = UsuarioId;

            if (ContratoIdTextBox.Text == "0")
                paso = ContratosBLL.Guardar(contrato);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ContratosBLL.Modificar(contrato);
                }
                else
                {
                    MessageBox.Show("No se Puede Modificar un Contrato que no existe");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("El Contrato No se Pudo Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContratosBLL.Eliminar(contrato.ContratoId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
                MessageBox.Show("No se puede eliminar un contrato que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Contratos ContratoAnterior = ContratosBLL.Buscar(contrato.ContratoId);

            if (ContratoAnterior != null)
            {
                contrato = ContratoAnterior;
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Contrato no encontrado");
            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            CContratos cContratos = new CContratos();
            cContratos.Show();
        }

        private void ConsultarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            CClientes cClientes = new CClientes();
            cClientes.Show();
        }
    }
}
