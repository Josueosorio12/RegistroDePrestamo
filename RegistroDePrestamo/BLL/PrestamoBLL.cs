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
   public class PrestamoBLL
    {
        public static bool Guardar(Prestamos prestamo)
        {
            if (!Existe(prestamo.Prestamoid))
                return Insertar(prestamo);

            else
                return Modificar(prestamo);
        }
        private static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(prestamo);
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
        private static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM PrestamoDetalle Where Id={prestamo.Prestamoid}");

                foreach (var item in prestamo.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;

                    contexto.Entry(item.oPrestamo).State = EntityState.Modified;
                }

                contexto.Entry(prestamo).State = EntityState.Modified;
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
                var prestamo = PrestamoBLL.Buscar(id);

                if (prestamo != null)
                {
                    contexto.Prestamos.Remove(prestamo);
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
        public static Prestamos Buscar(int id)
        {
            Prestamos tarea = new Prestamos();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Prestamos.Include(x => x.Detalle).Where(x => x.Prestamoid == id).SingleOrDefault();
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
                encontrado = contexto.Prestamos.Any(e => e.Prestamoid == id);
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
        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> Lista = new List<Prestamos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Prestamos.Where(criterio).ToList();
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

