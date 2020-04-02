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
    /// Interaction logic for CClientes.xaml
    /// </summary>
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = ClientesBLL.GetList(c => true);
                        break;
                    case 1://ClienteId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ClientesBLL.GetList(c => c.ClienteId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2://Nombres
                        Listado = ClientesBLL.GetList(c => c.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Cedula
                        Listado = ClientesBLL.GetList(c => c.Cedula.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Telefono
                        Listado = ClientesBLL.GetList(c => c.Telefono.Contains(CriterioTextBox.Text));
                        break;
                    case 5://Celular
                        Listado = ClientesBLL.GetList(c => c.Celular.Contains(CriterioTextBox.Text));
                        break;
                    case 6://Direccion
                        Listado = ClientesBLL.GetList(c => c.Direccion.Contains(CriterioTextBox.Text));
                        break;
                    case 7://Email
                        Listado = ClientesBLL.GetList(c => c.Email.Contains(CriterioTextBox.Text));
                        break;
                    case 8://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ClientesBLL.GetList(c => c.UsuarioId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                }
                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && c.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = ClientesBLL.GetList(c => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}

