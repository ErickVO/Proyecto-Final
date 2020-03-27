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
    /// Interaction logic for REntradas.xaml
    /// </summary>
    public partial class REntradas : Window
    {
        Entradas entrada = new Entradas();
        private int UsuarioId { get; set; }
        public REntradas(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            this.DataContext = entrada;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            EntradaIdTextBox.Text = "0";
        }
    }
}
