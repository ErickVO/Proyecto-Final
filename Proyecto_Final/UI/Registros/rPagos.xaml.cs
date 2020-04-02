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
using Proyecto_Final.Contenedores;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for rPagos.xaml
    /// </summary>
    public partial class rPagos : Window
    {
        ContenedorPagos contenedor = new ContenedorPagos();
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        List<int> ClientesId = new List<int>();
        public rPagos(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            CreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            ModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            obtenerClientes();
            VentaComboBox.IsEnabled = false;
            MontoTextBox.IsEnabled = false;
            this.DataContext = contenedor;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (contenedor.pagos.PagoId == 0)
                contenedor.pagos.UsuarioId = UsuarioId;

            contenedor.pagos.ClienteId = ClientesId[ClientesComboBox.SelectedIndex];
            llenarPagoDetalle();

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
                {
                    contenedor.pagos.FechaModificacion = DateTime.Now;
                    paso = PagosBLL.Modificar(contenedor.pagos);
                }
            }

            if (paso)
            {
                VentasBLL.RestarBalance(contenedor.pagos.PagoDetalle[0].VentaId, Convert.ToDecimal(BalanceLabel.Content));
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void llenarPagoDetalle()
        {
            foreach (var item in contenedor.listaPagos)
            {
                contenedor.pagos.PagoDetalle.Add(new PagosDetalle(item.PagoId, item.VentaId, item.Monto, item.Saldo));
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Pagos pago = PagosBLL.Buscar(contenedor.pagos.PagoId);

            if (pago != null)
            {
                contenedor.pagos = pago;
                llenarDataGrid();
                obtenerListado();
                UsuarioLabel.Content = obtenerNombreUsuario(contenedor.pagos.UsuarioId);

                Ventas venta = VentasBLL.Buscar(Convert.ToInt32(VentaComboBox.SelectedItem));
                BalanceLabel.Content = Convert.ToString(venta.Balance);

                ClientesComboBox.IsEnabled = false;
                VentaComboBox.IsEnabled = false;

                reCargar();
            }
            else
            {
                limpiar();
                MessageBox.Show("Pago no encontrado");
            }
        }

        private void obtenerListado()
        {
            for (int i = 0; i < ClientesId.Count; i++)
            {
                if (ClientesId[i] == contenedor.pagos.ClienteId)
                    ClientesComboBox.SelectedIndex = i;
            }

            VentaComboBox.Items.Add(contenedor.pagos.PagoDetalle[0].VentaId);
            VentaComboBox.SelectedIndex = 0;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (contenedor.pagos.PagoId == 0)
            {
                MessageBox.Show("No se puede eliminar el 0");
                return;
            }

            if (PagosBLL.Eliminar(contenedor.pagos.PagoId))
            {
                limpiar();
                MessageBox.Show("Eliminado");
            }
            else
                MessageBox.Show("No se puede eliminar un pago que no existe");
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

            if (contenedor.pagosDetalle.Monto > Convert.ToDecimal(BalanceLabel.Content))
            {
                MessageBox.Show("Ha excedido el pago posible");
                return;
            }

            if (VentaComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una venta");
                return;
            }

            contenedor.listaPagos.Add(new ListaPagos(contenedor.pagos.PagoId, Convert.ToInt32(VentaComboBox.SelectedItem), contenedor.pagosDetalle.Monto));
            calcularPago();
            reCargar();

            MontoTextBox.Clear();
            MontoTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagosDataGrid.Items.Count > 1 && PagosDataGrid.SelectedIndex < PagosDataGrid.Items.Count - 1)
            {
                contenedor.listaPagos.RemoveAt(PagosDataGrid.SelectedIndex);
                calcularPago();
                reCargar();

                MontoTextBox.Clear();
                MontoTextBox.Focus();
            }

            if (PagosDataGrid.Items.Count == 1)
                ClientesComboBox.IsEnabled = true;
        }

        private void ConsultarPagosButton_Click(object sender, RoutedEventArgs e)
        {
            cPagos cPagos = new cPagos();
            cPagos.Show();
        }

        private void limpiar()
        {
            contenedor = new ContenedorPagos();

            BalanceLabel.Content = string.Empty;
            UsuarioLabel.Content = UsuarioNombre;
            ClientesComboBox.SelectedIndex = -1;
            VentaComboBox.Items.Clear();

            ClientesComboBox.IsEnabled = true;
            VentaComboBox.IsEnabled = false;

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

        private void obtenerClientes()
        {
            List<Clientes> clientes = ClientesBLL.GetList(p => true);

            foreach (var item in clientes)
            {
                ClientesComboBox.Items.Add(item.Nombres);
                ClientesId.Add(item.ClienteId);
            }
        }

        private void obtenerVentas(int id)
        {
            List<Ventas> ventas = VentasBLL.GetList(v => v.ClienteId == id);

            foreach (var item in ventas)
            {
                VentaComboBox.Items.Add(item.VentaId);
            }
        }

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }

        private void ClientesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientesComboBox.SelectedIndex < 0)
            {
                VentaComboBox.IsEnabled = false;
                return;
            }

            VentaComboBox.IsEnabled = true;

            PagosDataGrid.ItemsSource = new List<ListaPagos>();

            obtenerVentas(ClientesId[ClientesComboBox.SelectedIndex]);

            reCargar();
        }

        private void VentaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VentaComboBox.SelectedIndex < 0)
            {
                MontoTextBox.IsEnabled = false;
                return;
            }

            Ventas venta = VentasBLL.Buscar(Convert.ToInt32(VentaComboBox.SelectedItem));

            if (contenedor.pagos.PagoId == 0)
                BalanceLabel.Content = Convert.ToString(venta.Balance);

            MontoTextBox.IsEnabled = true;

            PagosDataGrid.ItemsSource = new List<ListaPagos>();

            reCargar();
        }

        private void calcularPago()
        {
            Ventas venta = VentasBLL.Buscar(Convert.ToInt32(VentaComboBox.SelectedItem));

            decimal total = 0.0m;

            foreach (var item in contenedor.listaPagos)
            {
                total += item.Monto;
                venta.Balance -= item.Monto;
                item.Saldo = venta.Balance;
            }

            TotalLabel.Content = Convert.ToString(total);
            BalanceLabel.Content = Convert.ToString(venta.Balance);
        }

        private void llenarDataGrid()
        {
            contenedor.listaPagos = new List<ListaPagos>();

            foreach (var item in contenedor.pagos.PagoDetalle)
            {
                contenedor.listaPagos.Add(new ListaPagos(item.PagoId, item.VentaId, item.Monto, item.Saldo));
            }
        }

    }
}
