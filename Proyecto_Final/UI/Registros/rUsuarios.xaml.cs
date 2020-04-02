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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        int UsuarioId = 0;
        string UsuarioNombre = string.Empty;
        public rUsuarios(int usuarioId, string usuarioNombre)
        {
            InitializeComponent();
            UsuarioId = usuarioId;
            UsuarioNombre = usuarioNombre;
            UsuarioLabel.Content = UsuarioNombre;
            CreacionLabel.ContentStringFormat = "MM/dd/yyyy";
            ModificacionLabel.ContentStringFormat = "MM/dd/yyyy";
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
                usuario.UsuarioIdCreacion = UsuarioId;

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
                UsuarioLabel.Content = obtenerNombreUsuario(usuario.UsuarioIdCreacion);
                reCargar();
            }
            else
                MessageBox.Show("No existe");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuarioId != usuario.UsuarioId)
            {
                Usuarios AnteriorUsuario = UsuariosBLL.Buscar(usuario.UsuarioId);
                if (AnteriorUsuario == null)
                {
                    MessageBox.Show("No se Puede Eliminar un usuario que no existe");
                    return;
                }

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

        private void ConsultarUsuariosButton_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();
        }

        private void limpiar()
        {
            usuario = new Usuarios();

            UsuarioLabel.Content = UsuarioNombre;

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

        private string obtenerNombreUsuario(int id)
        {
            Usuarios usuarios = UsuariosBLL.Buscar(id);

            return usuarios.NombreUsuario;
        }

    }
}
