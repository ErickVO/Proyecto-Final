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
using Proyecto_Final.UI.Registros;
using Proyecto_Final.UI.Consultas;
using Proyecto_Final.BLL;

namespace Proyecto_Final.UI.Menu
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        private int UsuarioId { get; set; }
        public MenuPrincipal(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
        }

        private void RegistrosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(RegistrosComboBox.SelectedIndex)
            {
                case 0:
                    RUsuarios rUsuarios = new RUsuarios(UsuarioId);
                    rUsuarios.Show();
                    break;
                case 1:
                    RContratos rContratos = new RContratos(UsuarioId);
                    rContratos.Show();
                    break;
                case 2:
                    REntradas rEntradas = new REntradas(UsuarioId);
                    rEntradas.Show();
                    break;
                case 3:
                    RSuplidores rSuplidores = new RSuplidores(UsuarioId);
                    rSuplidores.Show();
                    break;
                case 4:
                    RVentas rVentas = new RVentas(UsuarioId);
                    rVentas.Show();
                    break;
            }
        }
    }
}
