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
    /// Interaction logic for CEntradas.xaml
    /// </summary>
    public partial class cEntradas : Window
    {
        public cEntradas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Entradas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = EntradasBLL.GetList(e => true);
                        break;
                    case 1://Id
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = EntradasBLL.GetList(e => e.EntradaId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                }
                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(e => e.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && e.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = EntradasBLL.GetList(e => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
