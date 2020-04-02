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
    /// Interaction logic for RVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        //
        ContenedorVentas contenedor = new ContenedorVentas();
        private int UsuarioId { get; set; }
        private string UsuarioNombre { get; set; }
        List<int> ClientesId = new List<int>();
        public rVentas(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            FechaCreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            FechaModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            VentaIdTextBox.Text = "0";
            obtenerClientes();
            ContratoIdComboBox.IsEnabled = false;
            CantidadTextBox.IsEnabled = false;
            this.DataContext = contenedor;
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

        private void obtenerContratos(int id)
        {
            List<Contratos> contratos = ContratosBLL.GetList(c => c.ClienteId == id);

            foreach (var item in contratos)
            {
                ContratoIdComboBox.Items.Add(item.ContratoId);
            }
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            BalanceLabel.Content = "";

            UsuarioLabel.Content = UsuarioNombre;
            CantidadPendienteLabel.Content = string.Empty;
            ClientesComboBox.SelectedIndex = -1;
            ContratoIdComboBox.Items.Clear();

            ClientesComboBox.IsEnabled = true;
            ContratoIdComboBox.IsEnabled = false;

            contenedor = new ContenedorVentas();
            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Ventas VentaAnterior = VentasBLL.Buscar(contenedor.ventas.VentaId);
            return VentaAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (contenedor.ventas.VentaId == 0)
                contenedor.ventas.UsuarioId = UsuarioId;

            contenedor.ventas.ClienteId = ClientesId[ClientesComboBox.SelectedIndex];
            llenarVentaDetalle();

            if (VentaIdTextBox.Text == "0")
            {
                if (!VentasBLL.EntradaValida(contenedor.ventas))
                {
                    MessageBox.Show("Ya ha sido utilizada este ContratoId");
                    return;
                }
                paso = VentasBLL.Guardar(contenedor.ventas);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se Puede Modificar una Venta Que no Existe");
                    return;
                }
                else
                {
                    contenedor.ventas.FechaModificacion = DateTime.Now;
                    paso = VentasBLL.Modificar(contenedor.ventas);
                }
            }

            if (paso)
            {
                ContratosBLL.RestarCantidad(contenedor.ventas.VentaDetalle[0].ContratoId, Convert.ToDecimal(CantidadPendienteLabel.Content));
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se Pudo Guardar la Venta");
        }

        private void llenarVentaDetalle()
        {
            foreach (var item in contenedor.listaVentas)
            {
                contenedor.ventas.VentaDetalle.Add(new VentasDetalle(item.VentaId, item.ContratoId, item.Cantidad, item.Importe));
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas AnteriorVenta = VentasBLL.Buscar(contenedor.ventas.VentaId);
            if (AnteriorVenta == null)
            {
                MessageBox.Show("No se Puede Eliminar un venta que no existe");
                return;
            }

            List<Pagos> pagos = PagosBLL.GetList(p => true);

            foreach (var item in pagos)
            {
                if (item.PagoDetalle[0].VentaId == contenedor.ventas.VentaId)
                {
                    MessageBox.Show("No se puede eliminar esta ya que tiene un pago");
                    return;
                }
            }

            if (VentasBLL.Eliminar(contenedor.ventas.VentaId))
            {
                ContratosBLL.RestablecerCantidadPendiente(contenedor.ventas.VentaDetalle[0].ContratoId);
                Limpiar();
                MessageBox.Show("Eliminado");
            }
            else
                MessageBox.Show("No se Puede Eliminar Una Venta Que no Existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas VentaAnterior = VentasBLL.Buscar(contenedor.ventas.VentaId);

            if (VentaAnterior != null)
            {
                contenedor.ventas = VentaAnterior;
                llenarDataGrid();
                obtenerListado();
                UsuarioLabel.Content = obtenerNombreUsuario(contenedor.ventas.UsuarioId);

                Contratos contrato = ContratosBLL.Buscar(Convert.ToInt32(ContratoIdComboBox.SelectedItem));
                CantidadPendienteLabel.Content = Convert.ToString(contrato.CantidadPendiente);

                ClientesComboBox.IsEnabled = false;
                ContratoIdComboBox.IsEnabled = false;

                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta No Encontrada");
            }
        }

        private void obtenerListado()
        {
            for (int i = 0; i < ClientesId.Count; i++)
            {
                if (ClientesId[i] == contenedor.ventas.ClienteId)
                    ClientesComboBox.SelectedIndex = i;
            }

            ContratoIdComboBox.Items.Add(contenedor.ventas.VentaDetalle[0].ContratoId);
            ContratoIdComboBox.SelectedIndex = 0;
        }

        private void llenarDataGrid()
        {
            contenedor.listaVentas = new List<ListaVentas>();

            foreach (var item in contenedor.ventas.VentaDetalle)
            {
                contenedor.listaVentas.Add(new ListaVentas(item.VentaId, item.ContratoId, item.Cantidad, item.Precio, item.Cantidad * item.Precio));
            }
        }

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (contenedor.ventasDetalle.Cantidad > Convert.ToDecimal(CantidadPendienteLabel.Content))
            {
                MessageBox.Show("Ha excedido la cantidad disponible");
                return;
            }

            if (ContratoIdComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un contrato");
                return;
            }

            contenedor.listaVentas.Add(new ListaVentas(contenedor.ventas.VentaId, Convert.ToInt32(ContratoIdComboBox.SelectedItem), contenedor.ventasDetalle.Cantidad, obtenerPrecio()));
            calcularVenta();
            Recargar();

            CantidadTextBox.Clear();
            CantidadTextBox.Focus();
        }

        private decimal obtenerPrecio()
        {
            Contratos contrato = ContratosBLL.Buscar(Convert.ToInt32(ContratoIdComboBox.SelectedItem));

            return contrato.Precio;
        }

        private void calcularVenta()
        {
            decimal total = 0.0m;
            decimal balance = 0.0m;
            decimal cantidad = 0.0m;

            foreach (var item in contenedor.listaVentas)
            {
                item.Total = item.Cantidad * item.Importe;
                total += item.Total;
                balance += item.Total;
                cantidad += item.Cantidad;
            }

            if (contenedor.ventas.VentaId > 0)
            {
                if (PagosBLL.ExistePago())
                {
                    List<Pagos> pagos = PagosBLL.GetList(p => true);

                    foreach(var item in pagos)
                    {
                        if(item.PagoDetalle[0].VentaId == contenedor.ventas.VentaId)
                        {
                            balance -= item.Total;
                        }
                    }
                }
            }

            Contratos contrato = ContratosBLL.Buscar(Convert.ToInt32(ContratoIdComboBox.SelectedItem));

            BalanceLabel.Content = Convert.ToString(balance);
            TotalLabel.Content = Convert.ToString(total);
            CantidadPendienteLabel.Content = Convert.ToString(contrato.Cantidad - cantidad);
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.Items.Count > 1 && VentasDataGrid.SelectedIndex < VentasDataGrid.Items.Count - 1)
            {
                contenedor.listaVentas.RemoveAt(VentasDataGrid.SelectedIndex);
                calcularVenta();
                Recargar();

                CantidadTextBox.Clear();
                CantidadTextBox.Focus();
            }

            if (VentasDataGrid.Items.Count == 1)
                ClientesComboBox.IsEnabled = true;
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }

        private void ClientesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientesComboBox.SelectedIndex < 0)
            {
                ContratoIdComboBox.IsEnabled = false;
                return;
            }

            ContratoIdComboBox.IsEnabled = true;

            VentasDataGrid.ItemsSource = new List<ListaVentas>();

            obtenerContratos(ClientesId[ClientesComboBox.SelectedIndex]);

            Recargar();
        }

        private void ContratoIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContratoIdComboBox.SelectedIndex < 0)
            {
                CantidadTextBox.IsEnabled = false;
                return;
            }

            Contratos contrato = ContratosBLL.Buscar(Convert.ToInt32(ContratoIdComboBox.SelectedItem));

            if (contenedor.ventas.VentaId == 0)
                CantidadPendienteLabel.Content = Convert.ToString(contrato.CantidadPendiente);

            CantidadTextBox.IsEnabled = true;

            VentasDataGrid.ItemsSource = new List<ListaVentas>();

            Recargar();
        }
    }
}
