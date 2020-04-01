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
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        List<int> ClientesId = new List<int>();
        public RPagos(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            CreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            ModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            obtenerClientes();
            this.DataContext = contenedor;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if(contenedor.pagos.PagoId == 0)
                contenedor.pagos.UsuarioId = UsuarioId;

            if (ClientesComboBox.SelectedIndex < 0)
                return;

            contenedor.pagos.ClienteId = ClientesId[ClientesComboBox.SelectedIndex];

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
                llenarDataGrid();
                UsuarioLabel.Content = obtenerNombreUsuario(contenedor.pagos.UsuarioId);

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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
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

            contenedor.listaPagos.Add(new ListaPagos(contenedor.pagos.PagoId, Convert.ToInt32(VentaComboBox.SelectedItem), contenedor.pagosDetalle.Monto));
            calcularSaldo(contenedor.listaPagos);
            reCargar();

            MontoTextBox.Clear();
            MontoTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (PagosDataGrid.Items.Count > 1 && PagosDataGrid.SelectedIndex < PagosDataGrid.Items.Count - 1)
            {
                contenedor.listaPagos.RemoveAt(PagosDataGrid.SelectedIndex);
                calcularSaldo(contenedor.listaPagos);
                reCargar();
            }

            if (PagosDataGrid.Items.Count == 1)
                ClientesComboBox.IsEnabled = true;
        }

        private void ConsultarPagosButton_Click(object sender, RoutedEventArgs e)
        {
            CPagos cPagos = new CPagos();
            cPagos.Show();
        }

        private void limpiar()
        {
            contenedor = new ContenedorPagos();

            BalanceLabel.Content = "";
            UsuarioLabel.Content = UsuarioNombre;
            ClientesComboBox.SelectedIndex = -1;
            VentaComboBox.Items.Clear();

            ClientesComboBox.IsEnabled = true;
            VentaComboBox.IsEnabled = true;

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
            VentaComboBox.Items.Clear();

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
                return;

            PagosDataGrid.ItemsSource = new List<ListaPagos>();

            obtenerVentas(ClientesId[ClientesComboBox.SelectedIndex]);

            reCargar();
        }

        private void VentaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VentaComboBox.SelectedIndex < 0)
                return;

            contenedor.listaPagos = new List<ListaPagos>();

            BalanceLabel.Content = VentasBLL.obtenerBalance(Convert.ToInt32(VentaComboBox.SelectedItem));

            reCargar();
        }

        private void calcularSaldo(List<ListaPagos> listaPagos)
        {
            decimal total = VentasBLL.obtenerTotal(Convert.ToInt32(VentaComboBox.SelectedItem));
            contenedor.pagos.Total = 0;

            foreach(var item in listaPagos)
            {
                total -= item.Monto;
                item.Saldo = total;
                contenedor.pagos.Total += item.Monto;
            }
        }

        private void llenarDataGrid()
        {
            contenedor.listaPagos = new List<ListaPagos>();

            foreach(var item in contenedor.pagos.PagoDetalle)
            {
                contenedor.listaPagos.Add(new ListaPagos(item.PagoId, item.VentaId, item.Monto, item.Saldo));
            }
        }
    }
}
