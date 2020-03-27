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
    /// Interaction logic for RSuplidores.xaml
    /// </summary>
    public partial class RSuplidores : Window
    {
        Suplidores suplidor = new Suplidores();
        private int UsuarioId { get; set; }
        public RSuplidores(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = suplidor;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            SuplidorIdTextBox.Text = "0";
        }
    }
}
