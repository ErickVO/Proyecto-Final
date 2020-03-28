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
using Proyecto_Final.Contenedores;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RPagos.xaml
    /// </summary>
    public partial class RPagos : Window
    {
        ContenedorPagos contenedor = new ContenedorPagos();
        public int UsuarioId { get; set; }
        public RPagos(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = contenedor;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void limpiar()
        {
            contenedor = new ContenedorPagos();
            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }
    }
}
