using RegistroDePrestamo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDePrestamo.BLL
{
   public class LoginBLL
    {
        public static bool Validar(string NombreUsuario, string Contrasena)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var validar = from prestamo in contexto.Prestamos
                              where prestamo.NombreDeUsuario == NombreUsuario
                              && prestamo.Contrasena == GetSHA256(Contrasena)
                              select prestamo;

                if (validar.Count() > 0)
                {
                    paso = true;
                }
                else
                {
                    paso = false;
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

        public static string GetSHA256(string contrasena)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();

            stream = sha256.ComputeHash(encoding.GetBytes(contrasena));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }
    }
}