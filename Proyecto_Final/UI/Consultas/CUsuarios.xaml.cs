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
using System.Linq;

namespace Proyecto_Final.UI.Consultas
{
    /// <summary>
    /// Interaction logic for CUsuarios.xaml
    /// </summary>
    public partial class CUsuarios : Window
    {
        public CUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = UsuariosBLL.GetList(u => true);
                        break;
                    case 1://Id
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = UsuariosBLL.GetList(u => u.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2://Nombres
                        Listado = UsuariosBLL.GetList(u => u.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3://NombreUsuario
                        Listado = UsuariosBLL.GetList(u => u.NombreUsuario.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Clave
                        Listado = UsuariosBLL.GetList(u => u.Clave.Contains(CriterioTextBox.Text));
                        break;
                    case 5://Email
                        Listado = UsuariosBLL.GetList(u => u.Clave.Contains(CriterioTextBox.Text));
                        break;
                }
                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(u => u.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && u.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = UsuariosBLL.GetList(u => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
