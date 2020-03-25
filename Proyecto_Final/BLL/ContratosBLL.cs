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
    public class ContratosBLL
    {
        public static bool Guardar(Contratos contrato)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Contratos.Add(contrato) != null)
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

        public static bool Modificar(Contratos contrato)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(contrato).State = EntityState.Modified;
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

        public static Contratos Buscar(int Id)
        {
            Contratos contrato = new Contratos();
            Contexto db = new Contexto();

            try
            {
                contrato = db.Contratos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return contrato;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = ContratosBLL.Buscar(Id);
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

        public static List<Contratos> GetList(Expression<Func<Contratos, bool>> contrato)
        {
            List<Contratos> Lista = new List<Contratos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Contratos.Where(contrato).ToList();
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
