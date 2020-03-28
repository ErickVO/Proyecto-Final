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
using Proyecto_Final.Entidades;
using Proyecto_Final.BLL;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RCacaos.xaml
    /// </summary>
    public partial class RCacaos : Window
    {
        Cacaos cacao = new Cacaos();
        public int UsuarioId { get; set; }
        public RCacaos(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            this.DataContext = cacao;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            cacao.Tipo = TipoComboBox.Text;
            if (cacao.UsuarioId == 0)
                cacao.UsuarioId = UsuarioId;

            if (cacao.CacaoId == 0)
            {
                paso = CacaosBLL.Guardar(cacao);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un cacao que no existe");
                    return;
                }
                paso = CacaosBLL.Modificar(cacao);
            }

            if (paso)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Cacaos AnteriorCacao = CacaosBLL.Buscar(cacao.CacaoId);

            if (AnteriorCacao != null)
            {
                cacao = AnteriorCacao;
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CacaosBLL.Eliminar(cacao.CacaoId))
            {
                limpiar();
                MessageBox.Show("Eliminado Correctamente");
            }
            else
                MessageBox.Show("No se Puede Eliminar un cacao que no existe");
        }

        private void limpiar()
        {
            cacao = new Cacaos();
            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = cacao;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Cacaos AnteriorCacao = CacaosBLL.Buscar(cacao.CacaoId);

            return (AnteriorCacao != null);
        }
    }
}
