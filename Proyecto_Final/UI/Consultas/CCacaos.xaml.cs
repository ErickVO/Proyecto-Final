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
    /// Interaction logic for CCacaos.xaml
    /// </summary>
    public partial class cCacaos : Window
    {
        public cCacaos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Cacaos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = CacaosBLL.GetList(s => true);
                        break;
                    case 1://CacaoId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CacaosBLL.GetList(c => c.CacaoId == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 2://Tipo
                        Listado = CacaosBLL.GetList(s => s.Tipo.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Cantidad
                        try
                        {
                            decimal cantidad = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CacaosBLL.GetList(c => c.Cantidad == cantidad);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese una cantidad valida");
                        }
                        break;
                    case 4://Costo
                        try
                        {
                            decimal costo = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CacaosBLL.GetList(c => c.Costo == costo);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un costo valido");
                        }
                        break;
                    case 5://Precio
                        try
                        {
                            decimal precio = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CacaosBLL.GetList(c => c.Precio == precio);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un precio valido");
                        }
                        break;
                    case 6://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = CacaosBLL.GetList(c => c.UsuarioId == id);
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
                Listado = CacaosBLL.GetList(c => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = Listado;
        }
    }
}

