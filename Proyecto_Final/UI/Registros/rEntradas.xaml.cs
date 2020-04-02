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
    /// Interaction logic for REntradas.xaml
    /// </summary>
    public partial class rEntradas : Window
    {
        Entradas entrada = new Entradas();
        private int UsuarioId { get; set; }
        private string UsuarioNombre { get; set; }
        List<int> SuplidoresId = new List<int>();
        List<int> CacaosId = new List<int>();
        public rEntradas(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            FechaCreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            FechaModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            EntradaIdTextBox.Text = "0";
            ObtenerSuplidor();
            ObtenerCacaos();
            CantidadTextBox.IsEnabled = false;
            CostoTextBox.IsEnabled = false;
            this.DataContext = entrada;
        }

        private void ObtenerSuplidor()
        {
            List<Suplidores> suplidores = SuplidoresBLL.GetList(p => true);

            foreach (var item in suplidores)
            {
                SuplidorIdComboBox.Items.Add(item.Nombres);
                SuplidoresId.Add(item.SuplidorId);
            }
        }

        private void ObtenerCacaos()
        {
            List<Cacaos> cacaos = CacaosBLL.GetList(p => true);

            foreach (var item in cacaos)
            {
                CacaoIdComboBox.Items.Add(item.Tipo);
                CacaosId.Add(item.CacaoId);
            }
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = entrada;
        }

        private void Limpiar()
        {
            EntradaIdTextBox.Text = "0";
            CantidadTextBox.Text = string.Empty;

            SuplidorIdComboBox.SelectedIndex = -1;
            CacaoIdComboBox.SelectedIndex = -1;

            UsuarioLabel.Content = UsuarioNombre;

            SuplidorIdComboBox.IsEnabled = true;
            CacaoIdComboBox.IsEnabled = true;
            CantidadTextBox.IsEnabled = false;
            CostoTextBox.IsEnabled = false;

            entrada = new Entradas();
            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Entradas EntradatoAnterior = EntradasBLL.Buscar(entrada.EntradaId);
            return EntradatoAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (entrada.EntradaId == 0)
                entrada.UsuarioId = UsuarioId;

            if (SuplidorIdComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un suplidor");
                return;
            }

            entrada.SuplidorId = SuplidoresId[SuplidorIdComboBox.SelectedIndex]; //obtener el id del suplidor seleccionado
            entrada.CacaoId = CacaosId[CacaoIdComboBox.SelectedIndex];

            if (EntradaIdTextBox.Text == "0")
                paso = EntradasBLL.Guardar(entrada);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    entrada.FechaModificacion = DateTime.Now;
                    paso = EntradasBLL.Modificar(entrada);
                }
                else
                {
                    MessageBox.Show("No se Puede Modificar una Entrada que no existe");
                    return;
                }
            }

            if (paso)
            {
                CacaosBLL.ActualizarCacao(entrada.CacaoId, entrada.Cantidad, entrada.Costo);
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("La Entrada No se Pudo Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Entradas AnteriorEntradas = EntradasBLL.Buscar(entrada.EntradaId);
            if (AnteriorEntradas == null)
            {
                MessageBox.Show("No se Puede Eliminar una entrada que no existe");
                return;
            }

            if (EntradasBLL.Eliminar(entrada.EntradaId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
                MessageBox.Show("No se puede eliminar una Entrada que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Entradas entradaAnterior = EntradasBLL.Buscar(entrada.EntradaId);

            if (entradaAnterior != null)
            {
                entrada = entradaAnterior;
                obtenerListado();
                UsuarioLabel.Content = obtenerNombreUsuario(entrada.UsuarioId);

                SuplidorIdComboBox.IsEnabled = false;
                CacaoIdComboBox.IsEnabled = false;
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Entrada no encontrada");
            }
        }

        private void obtenerListado()
        {
            for (int i = 0; i < SuplidoresId.Count; i++)
            {
                if (SuplidoresId[i] == entrada.SuplidorId)
                    SuplidorIdComboBox.SelectedIndex = i;
            }

            for (int i = 0; i < CacaosId.Count; i++)
            {
                if (CacaosId[i] == entrada.CacaoId)
                    CacaoIdComboBox.SelectedIndex = i;
            }
        }

        private void ConsultarEntradasButton_Click(object sender, RoutedEventArgs e)
        {
            cEntradas cEntradas = new cEntradas();
            cEntradas.Show();
        }

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CantidadTextBox.Text))
                return;

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
                return;

            decimal cantidad;
            decimal costo;

            try
            {
                cantidad = Convert.ToDecimal(CantidadTextBox.Text);
                costo = Convert.ToDecimal(CostoTextBox.Text);
            }
            catch (FormatException)
            {
                TotalLabel.Content = "0";
                return;
            }

            decimal total = cantidad * costo;

            TotalLabel.Content = Convert.ToString(total);
        }

        private void CacaoIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CacaoIdComboBox.SelectedIndex < 0)
            {
                CantidadTextBox.Clear();
                CostoTextBox.Clear();
                CantidadTextBox.IsEnabled = false;
                CostoTextBox.IsEnabled = false;
            }
            else
            {
                CantidadTextBox.IsEnabled = true;
                CostoTextBox.IsEnabled = true;
            }
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CantidadTextBox.Text))
                return;

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
                return;

            decimal cantidad;
            decimal costo;

            try
            {
                cantidad = Convert.ToDecimal(CantidadTextBox.Text);
                costo = Convert.ToDecimal(CostoTextBox.Text);
            }
            catch (FormatException)
            {
                TotalLabel.Content = "0";
                return;
            }

            decimal total = cantidad * costo;

            TotalLabel.Content = Convert.ToString(total);
        }
    }
}
