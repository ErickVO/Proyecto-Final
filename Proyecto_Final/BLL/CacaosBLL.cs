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

        public static bool ExisteCacao()
        {
            List<Cacaos> cacaos = GetList(c => true);

            if (cacaos.Count > 0)
                return true;
            else
                return false;
        }

        public static bool comprarCacao(decimal cantidadTotal)
        {
            //verifica si se puede comprar el cacao y si se puede comprar se resta
            List<Cacaos> lista = GetList(c => true);

            if (lista == null)
                return false;

            int verificando = 0;
            List<int> usados = new List<int>();

            foreach(var item in lista)
            {
                if (item.Cantidad > 0)
                {
                    usados.Add(verificando);
                }

                while(item.Cantidad>0 && cantidadTotal>0)
                {
                    item.Cantidad--;
                    cantidadTotal--;
                }

                verificando++;
            }

            if (cantidadTotal == 0)
            {
                foreach(var item in usados)
                {
                    Modificar(lista[item]);
                }

                return true;
            }
            else
                return false;
        }

        public static void ActualizarCacao(int id, decimal cantidad, decimal costo)
        {
            Cacaos cacao = Buscar(id);

            cacao.Cantidad += cantidad;
            cacao.Costo = costo;

            Modificar(cacao);
        }
    }
}
