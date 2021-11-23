using Microsoft.EntityFrameworkCore;
using RegistroDePrestamo.DAL;
using RegistroDePrestamo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.BLL
{
    public class ClienteBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.CodigoCliente))
                return Insertar(clientes);

            else
                return Modificar(clientes);
        }
        private static bool Insertar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Clientes.Add(clientes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM PrestamoDetalle Where Id={clientes.CodigoCliente}");

                foreach (var item in clientes.Detalles)
                {
                    contexto.Entry(item).State = EntityState.Added;


                }

                contexto.Entry(clientes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var clientes = ClienteBLL.Buscar(id);

                if (clientes != null)
                {
                    contexto.Clientes.Remove(clientes);
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Clientes Buscar(int id)
        {
            Clientes tarea = new Clientes();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Clientes.Include(x => x.Detalles).Where(x => x.CodigoCliente == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Clientes.Any(e => e.CodigoCliente == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> Lista = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Clientes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}

