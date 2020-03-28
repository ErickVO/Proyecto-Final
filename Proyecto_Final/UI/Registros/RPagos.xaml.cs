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
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

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
                contenedor.pagos = pago;
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
            contenedor.pagos.PagoDetalle.Add(new PagosDetalle(contenedor.pagosDetalle.ClienteId, TipoComboBox.Text, Convert.ToDecimal(CantidadCacaoTextBox.Text), Convert.ToDecimal(PrecioTextBox.Text)));

            ClienteIdTextBox.Clear();
            CantidadCacaoTextBox.Clear();
            PrecioTextBox.Clear();
            ClienteIdTextBox.Focus();

            reCargar();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagosDataGrid.Items.Count > 1 && PagosDataGrid.SelectedIndex < PagosDataGrid.Items.Count - 1)
            {
                contenedor.pagos.PagoDetalle.RemoveAt(PagosDataGrid.SelectedIndex);
                reCargar();
            }
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
    }
}
