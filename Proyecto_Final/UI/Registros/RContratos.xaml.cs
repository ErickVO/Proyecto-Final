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

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RContratos.xaml
    /// </summary>
    public partial class RContratos : Window
    {
        Contratos contrato = new Contratos();
        private int UsuarioId { get; set; }
        public RContratos(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = contrato;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            ClienteIdTextBox.Text = "0";
        }
    }
}
