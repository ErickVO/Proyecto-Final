using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;
using Proyecto_Final.DAL;
using System.Linq.Expressions;
using System.Linq;

namespace Proyecto_Final.BLL
{
    public class EntradasBLL
    {
        public static bool Guardar(Entradas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Entradas.Add(entrada) != null)
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

        public static bool Modificar(Entradas entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(entrada).State = EntityState.Modified;
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

        public static Entradas Buscar(int Id)
        {
            Entradas entrada = new Entradas();
            Contexto db = new Contexto();

            try
            {
                entrada = db.Entradas.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return entrada;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = EntradasBLL.Buscar(Id);
                db.Entry(Eliminar).State = EntityState.Deleted;
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

        public static List<Entradas> GetList(Expression<Func<Entradas, bool>> entrada)
        {
            List<Entradas> Lista = new List<Entradas>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Entradas.Where(entrada).ToList();
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
    }
}
