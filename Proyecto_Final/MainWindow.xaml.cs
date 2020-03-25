using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto_Final.BLL;
using Proyecto_Final.Entidades;
using Proyecto_Final.UI.Menu;

namespace Proyecto_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuarios usuario = new Usuarios();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {


            //abrir menu para los registros
            if (UsuariosBLL.Existe(usuario))
            {
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.Show();
            }
            else
                MessageBox.Show("Usuario no existente");
        }
    }
}
