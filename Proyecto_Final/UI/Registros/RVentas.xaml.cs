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
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Ventas VentaAnterior = VentasBLL.Buscar(contenedor.ventas.VentaId);
            return VentaAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

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
                MessageBox.Show("Orden No Encontrada");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            contenedor.ventas.VentaDetalle.Add(new VentasDetalle(contenedor.ventas.VentaId, Convert.ToInt32(ContratoIdTextBox.Text),
                Convert.ToDecimal(CantidadCacaoTextBox)));

            Recargar();

            ContratoIdTextBox.Clear();
            CantidadCacaoTextBox.Clear();
            ContratoIdTextBox.Focus();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.Items.Count > 1 && VentasDataGrid.SelectedIndex < VentasDataGrid.Items.Count - 1)
            {
                contenedor.ventas.VentaDetalle.RemoveAt(VentasDataGrid.SelectedIndex);
                Recargar();
            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            CVentas cVentas = new CVentas();
            cVentas.Show();
        }
    }
}
