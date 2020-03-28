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
        public RVentas(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = contenedor;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            VentaIdTextBox.Text = "0";
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            ContratoIdTextBox.Text = string.Empty;
            CantidadCacaoTextBox.Text = string.Empty;
            contenedor.ventas = new Ventas();
            contenedor.ventasDetalle = new VentasDetalle();
            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            ContratoIdTextBox.IsEnabled = true;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Ventas VentaAnterior = VentasBLL.Buscar(contenedor.ventas.VentaId);
            return VentaAnterior != null;
        }

        private bool ExisteEnlaBaseDeDatosContratos()
        {
            Contratos contratoAnterior = ContratosBLL.Buscar(contenedor.ventasDetalle.ContratoId);
            return contratoAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ExisteEnlaBaseDeDatosContratos())
            {
                MessageBox.Show("Contrato No Existe");
                ContratoIdTextBox.Focus();
                return;
            }

            contenedor.ventas.UsuarioId = UsuarioId;

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
                    paso = VentasBLL.Modificar(contenedor.ventas);
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
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta No Encontrada");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToDecimal(CantidadCacaoTextBox.Text) <= Convert.ToDecimal(CantidadDisponibleTextBox.Text))
            {
                contenedor.ventas.VentaDetalle.Add(new VentasDetalle(contenedor.ventas.VentaId, Convert.ToInt32(ContratoIdTextBox.Text),
                Convert.ToDecimal(CantidadCacaoTextBox.Text)));

                Recargar();
                decimal cantidadDisponible = Convert.ToDecimal(CantidadDisponibleTextBox.Text);
                cantidadDisponible -= Convert.ToDecimal(CantidadCacaoTextBox.Text);
                CantidadDisponibleTextBox.Text = Convert.ToString(cantidadDisponible);

                CantidadCacaoTextBox.Clear();
                CantidadCacaoTextBox.Focus();

                ContratoIdTextBox.IsEnabled = false;
            }
            else
                MessageBox.Show("Ha excedido la cantidad maxima para agregar");
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.Items.Count > 1 && VentasDataGrid.SelectedIndex < VentasDataGrid.Items.Count - 1)
            {
                contenedor.ventas.VentaDetalle.RemoveAt(VentasDataGrid.SelectedIndex);
                Recargar();

                CantidadCacaoTextBox.Clear();
                CantidadCacaoTextBox.Focus();
            }

            if (VentasDataGrid.Items.Count == 1)
                ContratoIdTextBox.IsEnabled = true;
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
            if (!string.IsNullOrWhiteSpace(ContratoIdTextBox.Text))
            {
                AgregarButton.IsEnabled = true;
                int id;
                Contratos contrato = new Contratos();
                int.TryParse(ContratoIdTextBox.Text, out id);

                contrato = ContratosBLL.Buscar(id);
                if (contrato != null)
                {
                    CantidadAcordadaTextBox.Text = Convert.ToString(VentasBLL.BuscarCantidadTotal(id));

                    List<VentasDetalle> lista = (List<VentasDetalle>)VentasDataGrid.ItemsSource;

                    if(lista != null)
                    {
                        decimal cantidadDisponible = Convert.ToDecimal(CantidadAcordadaTextBox.Text);
                        foreach(var item in lista)
                        {
                            cantidadDisponible -= item.CantidadCacao;
                        }
                        CantidadDisponibleTextBox.Text = Convert.ToString(cantidadDisponible);
                    }
                    else
                    {
                        CantidadDisponibleTextBox.Text = Convert.ToString(CantidadAcordadaTextBox.Text);
                    }
                }
                else
                {
                    CantidadAcordadaTextBox.Text = "No existe Tal Contrato";
                    CantidadDisponibleTextBox.Text= "No existe Tal Contrato";
                    AgregarButton.IsEnabled = false;
                }
            }
        }
    }
}
