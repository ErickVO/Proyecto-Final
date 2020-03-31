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
using Proyecto_Final.UI.Consultas;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for RCacaos.xaml
    /// </summary>
    public partial class RCacaos : Window
    {
        Cacaos cacao = new Cacaos();
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;

        public RCacaos(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            CreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            ModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
            this.DataContext = cacao;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
            UsuarioLabel.Content = UsuarioNombre;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if(cacao.CacaoId == 0)
                cacao.UsuarioId = UsuarioId;

            cacao.FechaModificacion = DateTime.Now;

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
                UsuarioLabel.Content = obtenerNombreUsuario(cacao.UsuarioId);
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

        private void ConsultarCacaosButton_Click(object sender, RoutedEventArgs e)
        {
            CCacaos cCacaos = new CCacaos();
            cCacaos.Show();
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

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }

        /*private void EntradaIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntradaIdTextBox.Text))
            {
                int id = 0;
                try
                {
                    id = Convert.ToInt32(cacao.CacaoId);
                }
                catch (FormatException)
                {
                    return;
                }

                if(id >= 1)
                {
                    return;
                }

                int entradaId;
                Entradas entrada = new Entradas();
                int.TryParse(EntradaIdTextBox.Text, out entradaId);

                entrada = EntradasBLL.Buscar(entradaId);
                if (entrada != null)
                {
                    CantidadTextBox.Text = Convert.ToString(entrada.Cantidad);
                }
                else
                {
                    CantidadTextBox.Text = "No existe Tal Entrada";
                }
            }
        }*/
    }
}
