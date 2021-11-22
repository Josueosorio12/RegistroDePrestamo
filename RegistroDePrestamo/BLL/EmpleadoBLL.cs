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
   public class EmpleadoBLL
    {
        public static bool Guardar(Empleados empleados)
        {
            if (!Existe(empleados.CodigoEmpleado))
                return Insertar(empleados);

            else
                return Modificar(empleados);
        }
        private static bool Insertar(Empleados empleados)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Empleados.Add(empleados);
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
        private static bool Modificar(Empleados empleados)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM PrestamoDetalle Where Id={empleados.CodigoEmpleado}");

                contexto.Entry(empleados).State = EntityState.Modified;
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
                var empleados = EmpleadoBLL.Buscar(id);

                if (empleados != null)
                {
                    contexto.Empleados.Remove(empleados);
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
        public static Empleados Buscar(int id)
        {
            Empleados tarea = new Empleados();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Empleados.Include(x => x.Detalles).Where(x => x.CodigoEmpleado == id).SingleOrDefault();
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
                encontrado = contexto.Empleados.Any(e => e.CodigoEmpleado == id);
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
        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> criterio)
        {
            List<Empleados> Lista = new List<Empleados>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Empleados.Where(criterio).ToList();
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

