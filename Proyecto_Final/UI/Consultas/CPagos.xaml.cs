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
    /// Interaction logic for CPagos.xaml
    /// </summary>
    public partial class cPagos : Window
    {
        public cPagos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Pagos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = PagosBLL.GetList(p => true);
                        break;
                    case 1://PagoId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = PagosBLL.GetList(p => p.PagoId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2://ClienteId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = PagosBLL.GetList(p => p.ClienteId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 3://Total
                        try
                        {
                            decimal total = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = PagosBLL.GetList(p => p.Total == total);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un total valido");
                        }
                        break;
                    case 4://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = PagosBLL.GetList(p => p.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                }
                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(p => p.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && p.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = PagosBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}
