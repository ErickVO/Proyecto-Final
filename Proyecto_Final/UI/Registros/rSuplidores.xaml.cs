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
    /// Interaction logic for RSuplidores.xaml
    /// </summary>
    public partial class rSuplidores : Window
    {
        Suplidores suplidor = new Suplidores();
        private int UsuarioId { get; set; }
        private string UsuarioNombre { get; set; }
        public rSuplidores(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            FechaCreacionLabel.ContentStringFormat = "dd/MM/yyyy";
            FechaModificacionLabel.ContentStringFormat = "dd/MM/yyyy";
            SuplidorIdTextBox.Text = "0";
            this.DataContext = suplidor;
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = suplidor;
        }

        private void Limpiar()
        {
            suplidor = new Suplidores();

            UsuarioLabel.Content = UsuarioNombre;

            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Suplidores SuplidorAnterior = SuplidoresBLL.Buscar(suplidor.SuplidorId);
            return SuplidorAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (suplidor.SuplidorId == 0)
                suplidor.UsuarioId = UsuarioId;

            if (SuplidorIdTextBox.Text == "0")
                paso = SuplidoresBLL.Guardar(suplidor);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    suplidor.FechaModificacion = DateTime.Now;
                    paso = SuplidoresBLL.Modificar(suplidor);
                }
                else
                {
                    MessageBox.Show("No se Puede Modificar un suplidor que no existe");
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
                MessageBox.Show("El Suplidor No se Pudo Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Suplidores AnteriorSuplidor = SuplidoresBLL.Buscar(suplidor.SuplidorId);
            if (AnteriorSuplidor == null)
            {
                MessageBox.Show("No se Puede Eliminar un suplidor que no existe");
                return;
            }

            if (SuplidoresBLL.Eliminar(suplidor.SuplidorId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
                MessageBox.Show("No se puede eliminar un contrato que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Suplidores supidordaAnterior = SuplidoresBLL.Buscar(suplidor.SuplidorId);

            if (supidordaAnterior != null)
            {
                suplidor = supidordaAnterior;
                UsuarioLabel.Content = obtenerNombreUsuario(suplidor.UsuarioId);
                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Suplidor no encontrado");
            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cSuplidores = new cSuplidores();
            cSuplidores.Show();
        }

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }
    }
}
