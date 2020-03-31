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
                //revisar
                /*if (CacaosBLL.comprarCacao(contrato.CantidadTotal))
                {
                    if (db.Contratos.Add(contrato) != null)
                        paso = db.SaveChanges() > 0;
                }*/
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
                db.Database.ExecuteSqlRaw($"Delete FROM VentasDetalle Where ContratoId = {contrato.ContratoId}");

                foreach (var item in contrato.VentaDetalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
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
                contrato = db.Contratos.Include(c => c.VentaDetalle).Where(c => c.ContratoId == Id).SingleOrDefault();
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

        //revisar
        /*public static bool verificarPago(int clienteId, decimal cantidad)
        {
            List<Contratos> lista = GetList(c => c.ClienteId == clienteId);

            foreach(var item in lista)
            {
                if (calcularPago(cantidad, item.ContratoId) == true)
                    return true;
            }

            return false;
        }

        public static void pagar(int clienteId, decimal cantidad)
        {
            List<Contratos> lista = GetList(c => c.ClienteId == clienteId);

            foreach (var item in lista)
            {
                if (guardarPago(cantidad, item.ContratoId) == true)
                    return;
            }
        }

        private static bool calcularPago(decimal cantidad, int contratoId)
        {
            Contratos contrato = Buscar(contratoId);

            if (contrato.VentaDetalle == null)
                return false;

            foreach (var item in contrato.VentaDetalle)
            {
                while (item.CantidadCacao > 0 && cantidad > 0)
                {
                    item.CantidadCacao--;
                    cantidad--;
                }
            }

            if (cantidad == 0)
                return true;
            else
                return false;
        }

        private static bool guardarPago(decimal cantidad, int contratoId)
        {
            Contratos contrato = Buscar(contratoId);

            if (contrato.VentaDetalle == null)
                return false;

            foreach (var item in contrato.VentaDetalle)
            {
                while (item.CantidadCacao > 0 && cantidad > 0)
                {
                    item.CantidadCacao--;
                    cantidad--;
                }
            }

            if (cantidad == 0)
            {
                Modificar(contrato);

                return true;
            }
            else
                return false;
        }*/
    }
}
