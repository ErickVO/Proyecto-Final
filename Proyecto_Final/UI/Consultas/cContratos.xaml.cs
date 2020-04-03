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
    /// Interaction logic for CContratos.xaml
    /// </summary>
    public partial class cContratos : Window
    {
        public cContratos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var Listado = new List<Contratos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        Listado = ContratosBLL.GetList(c => true);
                        break;
                    case 1://ContratoId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ContratosBLL.GetList(c => c.ContratoId == id);
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
                            Listado = ContratosBLL.GetList(c => c.ClienteId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 3://CacaoId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ContratosBLL.GetList(c => c.CacaoId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                    case 4://UsuarioId
                        try
                        {
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            Listado = ContratosBLL.GetList(c => c.UsuarioId == id);
                            MessageBox.Show("ID");
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Por favor, ingrese un ID valido");
                        }
                        break;
                }
                if (DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
                    Listado = Listado.Where(c => c.FechaCreacion.Date >= DesdeDatePicker.SelectedDate.Value && c.FechaCreacion.Date <= HastaDatePicker.SelectedDate.Value).ToList();
            }
            else
            {
                Listado = ContratosBLL.GetList(c => true);
            }

            List<ContratoGrid> contratoGrid = new List<ContratoGrid>();

            foreach(var item in Listado)
            {
                contratoGrid.Add(new ContratoGrid(item.ContratoId, item.Fecha, item.ClienteId, item.FechaVencimiento, item.CacaoId, item.Cantidad, item.Precio, item.Total, item.CantidadPendiente, item.FechaCreacion, item.FechaModificacion, item.UsuarioId));
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = contratoGrid;
        }

        public class ContratoGrid 
        {
            public int ContratoId { get; set; }
            public DateTime Fecha { get; set; }
            public int ClienteId { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public int CacaoId { get; set; }
            public decimal Cantidad { get; set; }
            public decimal Precio { get; set; }
            public decimal Total { get; set; }
            public decimal CantidadPendiente { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaModificacion { get; set; }
            public int UsuarioId { get; set; }


            public ContratoGrid(int contratoId, DateTime fecha, int clienteId, DateTime fechaVencimiento, int cacaoId, decimal cantidad, decimal precio, decimal total, decimal cantidadPendiente, DateTime fechaCreacion, DateTime fechaModificacion, int usuarioId)
            {
                ContratoId = contratoId;
                Fecha = fecha;
                ClienteId = clienteId;
                FechaVencimiento = fechaVencimiento;
                CacaoId = cacaoId;
                Cantidad = cantidad;
                Precio = precio;
                Total = total;
                CantidadPendiente = cantidadPendiente;
                FechaCreacion = fechaCreacion;
                FechaModificacion = fechaModificacion;
                UsuarioId = usuarioId;
            }
        }
    }
}
