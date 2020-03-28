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
                    RCacaos rCacaos = new RCacaos(UsuarioId);
                    rCacaos.Show();
                    break;
                case 1:
                    RClientes rClientes = new RClientes(UsuarioId);
                    rClientes.Show();
                    break;
                case 2:
                    RContratos rContratos = new RContratos(UsuarioId);
                    rContratos.Show();
                    break;
                case 3:
                    REntradas rEntradas = new REntradas(UsuarioId);
                    rEntradas.Show();
                    break;
                case 4:
                    RPagos rPagos = new RPagos(UsuarioId);
                    rPagos.Show();
                    break;
                case 5:
                    RSuplidores rSuplidores = new RSuplidores(UsuarioId);
                    rSuplidores.Show();
                    break;
                case 6:
                    RUsuarios rUsuarios = new RUsuarios(UsuarioId);
                    rUsuarios.Show();
                    break;
                case 7:
                    RVentas rVentas = new RVentas(UsuarioId);
                    rVentas.Show();
                    break;
            }
        }

        private void ConsultasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ConsultasComboBox.SelectedIndex)
            {
                case 0:
                    CCacaos cCacaos = new CCacaos();
                    cCacaos.Show();
                    break;
                case 1:
                    CClientes cClientes = new CClientes();
                    cClientes.Show();
                    break;
                case 2:
                    CContratos cContratos = new CContratos();
                    cContratos.Show();
                    break;
                case 3:
                    CEntradas cEntradas = new CEntradas();
                    cEntradas.Show();
                    break;
                case 4:
                    CPagos cPagos = new CPagos();
                    cPagos.Show();
                    break;
                case 5:
                    CSuplidores cSuplidores = new CSuplidores();
                    cSuplidores.Show();
                    break;
                case 6:
                    CUsuarios cUsuarios = new CUsuarios();
                    cUsuarios.Show();
                    break;
                case 7:
                    CVentas cVentas = new CVentas();
                    cVentas.Show();
                    break;
            }
        }
    }
}
