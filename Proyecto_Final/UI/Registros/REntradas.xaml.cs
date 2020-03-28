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
    public partial class REntradas : Window
    {
        Entradas entrada = new Entradas();
        private int UsuarioId { get; set; }
        public REntradas(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = entrada;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            EntradaIdTextBox.Text = "0";
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = entrada;
        }

        private void Limpiar()
        {
            EntradaIdTextBox.Text = "0";
            SuplidorIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
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

        private bool ExisteEnLaBaseDeDatosSuplidores()
        {
            Suplidores SuplidorAnterior = SuplidoresBLL.Buscar(entrada.SuplidorId);
            return SuplidorAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!ExisteEnLaBaseDeDatosSuplidores())
            {
                MessageBox.Show("Suplidor No Existe");
                SuplidorIdTextBox.Focus();
                return;
            }

            entrada.UsuarioId = UsuarioId;

            if (EntradaIdTextBox.Text == "0")
                paso = EntradasBLL.Guardar(entrada);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
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
            if (ContratosBLL.Eliminar(entrada.EntradaId))
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
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Entrada no encontrada");
            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            CEntradas cEntradas = new CEntradas();
            cEntradas.Show();
        }

        private void ConsultarSuplidoresButton_Click(object sender, RoutedEventArgs e)
        {
            CSuplidores cSuplidores = new CSuplidores();
            cSuplidores.Show();
        }
    }
}
