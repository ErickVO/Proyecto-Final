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
    public class PagosBLL
    {
        public static bool Guardar(Pagos pago)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Pagos.Add(pago) != null)
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

        public static bool Modificar(Pagos pago)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM PagosDetalle Where PagoId = {pago.PagoId}");

                foreach (var item in pago.PagoDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(pago).State = EntityState.Modified;
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

        public static Pagos Buscar(int Id)
        {
            Pagos pago = new Pagos();
            Contexto db = new Contexto();

            try
            {
                pago = db.Pagos.Include(p => p.PagoDetalle).Where(p => p.PagoId == Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return pago;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var Eliminar = PagosBLL.Buscar(id);
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

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> pago)
        {
            Contexto db = new Contexto();
            List<Pagos> Lista = new List<Pagos>();

            try
            {
                Lista = db.Pagos.Where(pago).ToList();
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

        public static Pagos PagoDeVenta(int id)
        {
            Pagos pago = new Pagos();
            Contexto db = new Contexto();

            try
            {
                pago = db.Pagos.Include(p => p.PagoDetalle).Where(p => p.PagoDetalle[0].VentaId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return pago;
        }

        public static bool ExistePago()
        {
            List<Pagos> pagos = GetList(c => true);

            if (pagos.Count > 0)
                return true;
            else
                return false;
        }
    }
}
