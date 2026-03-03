using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.M;
using System.Security.Cryptography;

namespace Gym.C
{
    public class ControladorLogin
    {
        ConDB conexion = new ConDB();
        public bool ConfirmarUsuarioContraseña(string usuario, string contrasena)
        {
            string consulta = @"
            SELECT COUNT(*) 
            FROM Usuarios 
            WHERE usuario = @usuario 
            AND contrasena = @contrasena";

            SqlParameter[] parametros =
            {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contrasena", contrasena)
            };

            int cantidad = Convert.ToInt32(conexion.ObtenerValor(consulta, parametros));

            return cantidad > 0;
        }

        public string GenerarHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
