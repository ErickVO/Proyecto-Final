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
    /// Interaction logic for CSuplidores.xaml
    /// </summary>
    public partial class CSuplidores : Window
    {
        public CSuplidores()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Suplidores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = SuplidoresBLL.GetList(s => true);
                        break;
                    case 1://Id
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = SuplidoresBLL.GetList(s => s.SuplidorId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2://Nombres
                        Listado = SuplidoresBLL.GetList(s => s.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Cedula
                        Listado = SuplidoresBLL.GetList(s => s.Cedula.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Direccion
                        Listado = SuplidoresBLL.GetList(s => s.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }
                Listado = Listado.Where(s => s.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && s.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = SuplidoresBLL.GetList(s => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
