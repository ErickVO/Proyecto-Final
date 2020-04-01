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
    public partial class RVentas : Window
    {
        ContenedorVentas contenedor = new ContenedorVentas();
        private int UsuarioId { get; set; }
        private string UsuarioNombre { get; set; }
        List<int> ClientesId = new List<int>();
        public RVentas(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            FechaCreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            FechaModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            VentaIdTextBox.Text = "0";
            obtenerClientes();
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

            if (!VentasBLL.EntradaValida(contenedor.ventas))
            {
                MessageBox.Show("Ya ha sido utilizada este ContratoId");
                return;
            }

            if(contenedor.ventas.VentaId == 0)
                contenedor.ventas.UsuarioId = UsuarioId;

            contenedor.ventas.ClienteId = ClientesId[ClientesComboBox.SelectedIndex];

            if (VentaIdTextBox.Text == "0")
            {
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
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
                MessageBox.Show("No se Pudo Guardar la Venta");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (contenedor.ventas.VentaId == 0)
            {
                MessageBox.Show("No se puede eliminar el 0");
                return;
            }

            if (VentasBLL.Eliminar(contenedor.ventas.VentaId))
            {
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
                UsuarioLabel.Content = obtenerNombreUsuario(contenedor.ventas.UsuarioId);

                ClientesComboBox.IsEnabled = false;
                ContratoIdComboBox.IsEnabled = true;

                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta No Encontrada");
            }
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
            if(contenedor.ventasDetalle.Cantidad > Convert.ToDecimal(CantidadPendienteLabel.Content))
            {
                MessageBox.Show("Ha excedido la cantidad disponible");
                return;
            }

            contenedor.listaVentas.Add(new ListaVentas(contenedor.ventas.VentaId, Convert.ToInt32(ContratoIdComboBox.SelectedItem), contenedor.ventasDetalle.Cantidad, obtenerPrecio()));
            //continuar
        }

        private decimal obtenerPrecio()
        {
            Contratos contrato = ContratosBLL.Buscar(Convert.ToInt32(ContratoIdComboBox.SelectedItem));

            return contrato.Precio;
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
           // if (VentasDataGrid.Items.Count > 1 && VentasDataGrid.SelectedIndex < VentasDataGrid.Items.Count - 1)
            {
                //guardar los valores para realizar el calculo sin problemas
                //revisar
                /*decimal cantidadEliminar = contenedor.ventas.VentaDetalle[VentasDataGrid.SelectedIndex].CantidadCacao;
                decimal cantidadDisponible = Convert.ToDecimal(CantidadDisponibleTextBox.Text);*/

             //   contenedor.ventas.VentaDetalle.RemoveAt(VentasDataGrid.SelectedIndex);
                Recargar();

                //aumentar la cantidad disponible por el valor que se elimina
                //revisar
                /*cantidadDisponible += cantidadEliminar;
                CantidadDisponibleTextBox.Text = Convert.ToString(cantidadDisponible);*/

              //  CantidadCacaoTextBox.Clear();
              //  CantidadCacaoTextBox.Focus();
            }

            //if (VentasDataGrid.Items.Count == 1)
             //   ContratoIdTextBox.IsEnabled = true;
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            CVentas cVentas = new CVentas();
            cVentas.Show();
        }

        private void ConsultarContratosButton_Click(object sender, RoutedEventArgs e)
        {
            CContratos cContratos = new CContratos();
            cContratos.Show();
        }

        private void ContratoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           // if (!string.IsNullOrWhiteSpace(ContratoIdTextBox.Text))
            {
             //   AgregarButton.IsEnabled = true;
                //int contratoId;
                Contratos contrato = new Contratos();
              //  int.TryParse(ContratoIdTextBox.Text, out contratoId);

               // contrato = ContratosBLL.Buscar(contratoId);
                if (contrato != null)
                {
                    //revisar
                    //CantidadAcordadaTextBox.Text = Convert.ToString(VentasBLL.BuscarCantidadTotal(contratoId));

                    int ventaId;
                    int.TryParse(VentaIdTextBox.Text, out ventaId);

                    //si la venta es nueva, la cantidad disponible sera igual a la del contrato
                    //sino sera igual a la que este guardada

                    //revisar
                    /*if(ventaId > 0)
                        CantidadDisponibleTextBox.Text = Convert.ToString(contenedor.ventas.CantidadDisponible);
                    else
                        CantidadDisponibleTextBox.Text = Convert.ToString(CantidadAcordadaTextBox.Text);*/
                }
                else
                {
             //       CantidadAcordadaTextBox.Text = "No existe Tal Contrato";
               //     CantidadDisponibleTextBox.Text= "No existe Tal Contrato";
                 //   AgregarButton.IsEnabled = false;
                }
            }
        }

        private void calcularDisponible(List<VentasDetalle> lista)
        {
            //resta todos los elementos del datagrid a la cantidad disponible
           // decimal cantidadDisponible = Convert.ToDecimal(CantidadDisponibleTextBox.Text);
            foreach (var item in lista)
            {
                //revisar
                //cantidadDisponible -= item.CantidadCacao;
            }
            //CantidadDisponibleTextBox.Text = Convert.ToString(cantidadDisponible);
        }
    }
}
