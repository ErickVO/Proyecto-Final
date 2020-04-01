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
    public class SuplidoresBLL
    {
        public static bool Guardar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if(db.Suplidores.Add(suplidor) != null)
                    paso = db.SaveChanges() > 0;

            }catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Suplidores suplidor)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(suplidor).State = EntityState.Modified;
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

        public static Suplidores Buscar(int Id)
        {
            Suplidores suplidores = new Suplidores();
            Contexto db = new Contexto();

            try
            {
                suplidores = db.Suplidores.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return suplidores;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = SuplidoresBLL.Buscar(Id);
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

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidor)
        {
            List<Suplidores> Lista = new List<Suplidores>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Suplidores.Where(suplidor).ToList();
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

        public static bool ExisteSuplidor()
        {
            List<Suplidores> suplidores = GetList(c => true);

            if (suplidores.Count > 0)
                return true;
            else
                return false;
        }
    }
}
