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
    /// Interaction logic for RUsuarios.xaml
    /// </summary>
    public partial class RUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public int UsuarioId { get; set; }
        public RUsuarios(int usuarioId)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioIdTextBox.Text = Convert.ToString(UsuarioId);
            this.DataContext = usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (usuario.UsuarioId == 0)
            {
                paso = UsuariosBLL.Guardar(usuario);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un usuario que no existe");
                    return;
                }
                paso = UsuariosBLL.Modificar(usuario);
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
            Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);

            if (AnteriorUsuario != null)
            {
                usuario = AnteriorUsuario;
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuarioId != usuario.UsuarioId)
            {
                if (UsuariosBLL.Eliminar(usuario.UsuarioId))
                {
                    limpiar();
                    MessageBox.Show("Eliminado Correctamente");
                }
                else
                    MessageBox.Show("No se Puede Eliminar un Usuario que no existe");
            }
            else
                MessageBox.Show("No se puede eliminar a un usuario online");
        }

        private void limpiar()
        {
            usuario = new Usuarios();
            reCargar();
        }
        
        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);

            return (AnteriorUsuario != null);
        }
    }
}
