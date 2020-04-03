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
    /// Interaction logic for CVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = VentasBLL.GetList(v => true);
                        break;
                    case 1://VentaId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = VentasBLL.GetList(v => v.VentaId == id);
                            MessageBox.Show("ID");
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
                            Listado = VentasBLL.GetList(v => v.ClienteId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 3://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = VentasBLL.GetList(v => v.UsuarioId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                }
                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(v => v.Fecha.Date >= DesdeDatePicker.SelectedDate.Value && v.Fecha.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = VentasBLL.GetList(v => true);
            }

            List<VentaGrid> ventaGrid = new List<VentaGrid>();

            foreach(var item in Listado)
            {
                ventaGrid.Add(new VentaGrid(item.VentaId, item.Fecha, item.ClienteId, item.Total, item.Balance, item.FechaCreacion, item.FechaModificacion, item.UsuarioId));
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = ventaGrid;
        }

        private class VentaGrid
        {
            public int VentaId { get; set; }
            public DateTime Fecha { get; set; }
            public int ClienteId { get; set; }
            public decimal Total { get; set; }
            public decimal Balance { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaModificacion { get; set; }
            public int UsuarioId { get; set; }

            public VentaGrid()
            {
                VentaId = 0;
                Fecha = DateTime.Now;
                ClienteId = 0;
                Total = 0.0m;
                Balance = 0.0m;
                FechaCreacion = DateTime.Now;
                FechaModificacion = DateTime.Now;
                UsuarioId = 0;
            }

            public VentaGrid(int ventaId, DateTime fecha, int clienteId, decimal total, decimal balance, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
            {
                VentaId = ventaId;
                Fecha = fecha;
                ClienteId = clienteId;
                Total = total;
                Balance = balance;
                FechaCreacion = fechaCreacion;
                FechaModificacion = fechaModificacion;
                UsuarioId = usuarioId;
            }
        }
    }
}
