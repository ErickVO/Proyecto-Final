using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Final.Entidades;
using Proyecto_Final.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Proyecto_Final.BLL
{
    public class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Usuarios.Add(usuario) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Usuarios Buscar(int id)
        {
            Usuarios usuario = new Usuarios();
            Contexto db = new Contexto();
            try
            {
                usuario = db.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuario;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Eliminar = db.Usuarios.Find(id);
                db.Entry(Eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuario)
        {
            List<Usuarios> Lista = new List<Usuarios>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Usuarios.Where(usuario).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }

        public static bool Existe(Usuarios usuario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Usuarios AnteriorUsuario = new Usuarios();

            try
            {
                if (db.Usuarios.Where(u => u.NombreUsuario == usuario.NombreUsuario && u.Clave == usuario.Clave).SingleOrDefault() != null)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static int ObtenerId(Usuarios usuario)
        {
            Contexto db = new Contexto();

            try
            {
                usuario = db.Usuarios.Where(u => u.NombreUsuario == usuario.NombreUsuario && u.Clave == usuario.Clave).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return usuario.UsuarioId;
        }
    }
}
