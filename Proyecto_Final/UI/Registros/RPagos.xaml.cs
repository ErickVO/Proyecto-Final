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
using Proyecto_Final.Contenedores;
using Proyecto_Final.UI.Consultas;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RPagos.xaml
    /// </summary>
    public partial class RPagos : Window
    {
        ContenedorPagos contenedor = new ContenedorPagos();
        public int UsuarioId { get; set; }
        public RPagos(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = contenedor;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            ClienteIdTextBox.IsEnabled = true;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!existeCliente())
            {
                MessageBox.Show("ClienteId no existe");
                return;
            }

            contenedor.pagos.UsuarioId = UsuarioId;

            if (contenedor.pagos.PagoId == 0)
                paso = PagosBLL.Guardar(contenedor.pagos);
            else
            {
                if (!existeEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Pago que no existe");
                    return;
                }
                else
                    paso = PagosBLL.Modificar(contenedor.pagos);
            }
            decimal cantidadTotal = 0;
            foreach( var item in contenedor.pagos.PagoDetalle)
            {
                cantidadTotal += item.Cantidad;
            }

            ContratosBLL.pagar(contenedor.pagos.PagoDetalle[0].ClienteId, cantidadTotal);

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

            Pagos pago = PagosBLL.Buscar(contenedor.pagos.PagoId);

            if (pago != null)
            {
                ClienteIdTextBox.IsEnabled = false;
                contenedor.pagos = pago;
                contenedor.pagosDetalle.ClienteId = contenedor.pagos.PagoDetalle[0].ClienteId;
                reCargar();
            }
            else
            {
                limpiar();
                MessageBox.Show("Pago no encontrado");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasBLL.Eliminar(contenedor.pagos.PagoId))
            {
                limpiar();
                MessageBox.Show("Eliminado");
            }
            else
                MessageBox.Show("No se puede eliminar un pago que no existe");
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if(!ContratosBLL.verificarPago(contenedor.pagosDetalle.ClienteId,contenedor.pagosDetalle.Cantidad))
            {
                MessageBox.Show("Pago excedido");
                return;
            }

            contenedor.pagos.PagoDetalle.Add(new PagosDetalle(contenedor.pagosDetalle.ClienteId, TipoComboBox.Text, Convert.ToDecimal(CantidadCacaoTextBox.Text), Convert.ToDecimal(PrecioTextBox.Text)));

            contenedor.pagos.Monto += contenedor.pagosDetalle.Cantidad * contenedor.pagosDetalle.Precio;
            reCargar();

            CantidadCacaoTextBox.Clear();
            CantidadCacaoTextBox.Focus();
            ClienteIdTextBox.IsEnabled = false;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagosDataGrid.Items.Count > 1 && PagosDataGrid.SelectedIndex < PagosDataGrid.Items.Count - 1)
            {
                contenedor.pagos.PagoDetalle.RemoveAt(PagosDataGrid.SelectedIndex);
                contenedor.pagos.Monto -= contenedor.pagosDetalle.Cantidad * contenedor.pagosDetalle.Precio;
                reCargar();
            }

            if (PagosDataGrid.Items.Count == 1)
                ClienteIdTextBox.IsEnabled = true;
        }

        private void ConsultarClientesButton_Click(object sender, RoutedEventArgs e)
        {
            CClientes cClientes = new CClientes();
            cClientes.Show();
        }

        private void ConsultarPagosButton_Click(object sender, RoutedEventArgs e)
        {
            CPagos cPagos = new CPagos();
            cPagos.Show();
        }

        private void limpiar()
        {
            contenedor = new ContenedorPagos();
            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }

        private bool existeEnLaBaseDeDatos()
        {
            Pagos pago = PagosBLL.Buscar(contenedor.pagos.PagoId);

            return (pago != null);
        }

        private bool existeCliente()
        {
            Clientes cliente = ClientesBLL.Buscar(contenedor.pagosDetalle.ClienteId);
            return (cliente != null);
        }

        private void TipoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PrecioTextBox != null)
            {
                if (!string.IsNullOrWhiteSpace(PrecioTextBox.Text))
                {
                    if (TipoComboBox.SelectedIndex == 0)
                        PrecioTextBox.Text = "1000.0";
                    else if (TipoComboBox.SelectedIndex == 1)
                        PrecioTextBox.Text = "2000.0";
                    else
                        PrecioTextBox.Text = "3000.0";
                }
            }
            
        }
    }
}
