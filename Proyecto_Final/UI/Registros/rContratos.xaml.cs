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
using Proyecto_Final.UI.Consultas;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RContratos.xaml
    /// </summary>
    public partial class rContratos : Window
    {
        Contratos contrato = new Contratos();
        private int UsuarioId { get; set; }
        private string UsuarioNombre { get; set; }

        List<int> ClientesId = new List<int>();
        List<int> CacaosId = new List<int>();
        public rContratos(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            FechaCreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            FechaModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            ContratoIdTextBox.Text = "0";
            ObtenerClientes();
            ObtenerCacaos();
            this.DataContext = contrato;
        }

        private void ObtenerClientes()
        {
            List<Clientes> clientes = ClientesBLL.GetList(p => true);

            foreach (var item in clientes)
            {
                ClienteIdComboBox.Items.Add(item.Nombres);
                ClientesId.Add(item.ClienteId);
            }
        }

        private void ObtenerCacaos()
        {
            List<Cacaos> cacaos = CacaosBLL.GetList(p => true);

            foreach (var item in cacaos)
            {
                CacaoIdComboBox.Items.Add(item.Tipo);
                CacaosId.Add(item.CacaoId);
            }
        }

        private void Recargar()
        {
            this.DataContext = null;
            this.DataContext = contrato;
        }

        private void Limpiar()
        {
            contrato = new Contratos();
            TotalLabel.Content = "";
            CantidadPendienteLabel.Content = "";

            ClienteIdComboBox.SelectedIndex = -1;
            CacaoIdComboBox.SelectedIndex = -1;

            UsuarioLabel.Content = UsuarioNombre;

            ClienteIdComboBox.IsEnabled = true;
            CacaoIdComboBox.IsEnabled = true;

            CantidadTextBox.IsEnabled = false;

            Recargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Contratos contratoAnterior = ContratosBLL.Buscar(contrato.ContratoId);
            return contratoAnterior != null;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (contrato.ContratoId == 0)
                contrato.UsuarioId = UsuarioId;

            if (ClienteIdComboBox.SelectedIndex < 0)
                return;

            if (CacaoIdComboBox.SelectedIndex < 0)
                return;

            contrato.ClienteId = ClientesId[ClienteIdComboBox.SelectedIndex];
            contrato.CacaoId = CacaosId[CacaoIdComboBox.SelectedIndex];

            if (ContratoIdTextBox.Text == "0")
            {
                if (CacaosBLL.ContratarCacao(contrato.CacaoId, contrato.Cantidad))
                {
                    contrato.CantidadPendiente = contrato.Cantidad;
                    paso = ContratosBLL.Guardar(contrato);
                }
                else
                    MessageBox.Show("Excedio la existencia de cacao");
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    contrato.FechaModificacion = DateTime.Now;
                    paso = ContratosBLL.Modificar(contrato);
                }
                else
                {
                    MessageBox.Show("No se Puede Modificar un Contrato que no existe");
                    return;
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("El Contrato No se Pudo Guardar");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (contrato.ContratoId == 0)
            {
                MessageBox.Show("No se puede eliminar el 0");
                return;
            }

            if (ContratosBLL.Eliminar(contrato.ContratoId))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
                MessageBox.Show("No se puede eliminar un contrato que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Contratos ContratoAnterior = ContratosBLL.Buscar(contrato.ContratoId);

            if (ContratoAnterior != null)
            {
                contrato = ContratoAnterior;
                obtenerListado();
                UsuarioLabel.Content = obtenerNombreUsuario(contrato.UsuarioId);

                ClienteIdComboBox.IsEnabled = false;
                CacaoIdComboBox.IsEnabled = false;

                Recargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Contrato no encontrado");
            }
        }

        private void obtenerListado()
        {
            for (int i = 0; i < ClientesId.Count; i++)
            {
                if (ClientesId[i] == contrato.ClienteId)
                    ClienteIdComboBox.SelectedIndex = i;
            }

            for (int i = 0; i < CacaosId.Count; i++)
            {
                if (CacaosId[i] == contrato.CacaoId)
                    CacaoIdComboBox.SelectedIndex = i;
            }
        }

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            cContratos cContratos = new cContratos();
            cContratos.Show();
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CantidadTextBox.Text))
                return;

            decimal cantidad;

            try
            {
                cantidad = Convert.ToDecimal(CantidadTextBox.Text);
            }
            catch (FormatException)
            {
                TotalLabel.Content = "0";
                return;
            }

            decimal total = cantidad * Convert.ToDecimal(PrecioLabel.Content);

            TotalLabel.Content = Convert.ToString(total);
        }

        private void CacaoIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CacaoIdComboBox.SelectedIndex < 0)
            {
                CantidadTextBox.Clear();
                CantidadTextBox.IsEnabled = false;
            }
            else
            {
                Cacaos cacao = CacaosBLL.Buscar(CacaosId[CacaoIdComboBox.SelectedIndex]);
                PrecioLabel.Content = Convert.ToString(cacao.Precio);
                CantidadTextBox.IsEnabled = true;
            }
        }
    }
}
