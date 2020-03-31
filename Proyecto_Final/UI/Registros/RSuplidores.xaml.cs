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
    public partial class RSuplidores : Window
    {
        Suplidores suplidor = new Suplidores();
        private int UsuarioId { get; set; }
        public RSuplidores(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = suplidor;
            //UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            //SuplidorIdTextBox.Text = "0";
        }

        //private void Recargar()
        //{
        //    this.DataContext = null;
        //    this.DataContext = suplidor;
        //}

        //private void Limpiar()
        //{
        //    SuplidorIdTextBox.Text = "0";
        //    NombresTextBox.Text = string.Empty;
        //    DireccionTextBox.Text = string.Empty;
        //    EmailTextBox.Text = string.Empty;
        //    TelefonoTextBox.Text = string.Empty;
        //    CedulaTextBox.Text = string.Empty;
        //    suplidor = new Suplidores();
        //    Recargar();
        //}

        //private void NuevoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Limpiar();
        //}

        //private bool ExisteEnLaBaseDeDatos()
        //{
        //    Suplidores SuplidorAnterior = SuplidoresBLL.Buscar(suplidor.SuplidorId);
        //    return SuplidorAnterior != null;
        //}

        //private void GuardarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    bool paso = false;

        //    suplidor.UsuarioId = UsuarioId;

        //    if (SuplidorIdTextBox.Text == "0")
        //        paso = SuplidoresBLL.Guardar(suplidor);
        //    else
        //    {
        //        if (ExisteEnLaBaseDeDatos())
        //        {
        //            paso = SuplidoresBLL.Modificar(suplidor);
        //        }
        //        else
        //        {
        //            MessageBox.Show("No se Puede Modificar un suplidor que no existe");
        //            return;
        //        }
        //    }

        //    if (paso)
        //    {
        //        Limpiar();
        //        MessageBox.Show("Guardado");
        //    }
        //    else
        //    {
        //        MessageBox.Show("El Suplidor No se Pudo Guardar");
        //    }
        //}

        //private void EliminarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SuplidoresBLL.Eliminar(suplidor.SuplidorId))
        //    {
        //        MessageBox.Show("Eliminado");
        //        Limpiar();
        //    }
        //    else
        //        MessageBox.Show("No se puede eliminar un contrato que no existe");
        //}

        //private void BuscarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Suplidores supidordaAnterior = SuplidoresBLL.Buscar(suplidor.SuplidorId);

        //    if (supidordaAnterior != null)
        //    {
        //        suplidor = supidordaAnterior;
        //        Recargar();
        //    }
        //    else
        //    {
        //        Limpiar();
        //        MessageBox.Show("Suplidor no encontrado");
        //    }
        //}

        //private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    CSuplidores cSuplidores = new CSuplidores();
        //    cSuplidores.Show();
        //}
    }
}
