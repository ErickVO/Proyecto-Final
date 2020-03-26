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
    public class CacaosBLL
    {
        public static bool Guardar(Cacaos cacao)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Cacaos.Add(cacao) != null)
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

        public static bool Modificar(Cacaos cacao)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(cacao).State = EntityState.Modified;
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

        public static Cacaos Buscar(int id)
        {
            Cacaos cacao = new Cacaos();
            Contexto db = new Contexto();
            try
            {
                cacao = db.Cacaos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return cacao;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Eliminar = db.Cacaos.Find(id);
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

        public static List<Cacaos> GetList(Expression<Func<Cacaos, bool>> cacao)
        {
            List<Cacaos> Lista = new List<Cacaos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.Cacaos.Where(cacao).ToList();
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
