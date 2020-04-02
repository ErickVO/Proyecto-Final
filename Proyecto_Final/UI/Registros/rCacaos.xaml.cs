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
    /// Interaction logic for rCacaos.xaml
    /// </summary>
    public partial class rCacaos : Window
    {
        Cacaos cacao = new Cacaos();
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;

        public rCacaos(int usuarioId, string usuarioNombre)
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
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (cacao.CacaoId == 0)
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
                else
                {
                    cacao.FechaModificacion = DateTime.Now;
                    paso = CacaosBLL.Modificar(cacao);
                }
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
            Cacaos AnteriorCacao = CacaosBLL.Buscar(cacao.CacaoId);
            if(AnteriorCacao == null)
            {
                MessageBox.Show("No se Puede Eliminar un cacao que no existe");
                return;
            }

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
            cCacaos cCacaos = new cCacaos();
            cCacaos.Show();
        }

        private void limpiar()
        {
            cacao = new Cacaos();

            UsuarioLabel.Content = UsuarioNombre;

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

    }
}
