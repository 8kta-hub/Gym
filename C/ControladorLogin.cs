using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.M;
using System.Security.Cryptography;
using System.Data;
using System.Security.Policy;

namespace Gym.C
{
    public class ControladorLogin
    {
        ConDB conexion = new ConDB();
        public bool ConfirmarUsuarioContraseña(string usuario, byte[] contrasena)
        {
            string consulta = @"
            SELECT COUNT(*) 
            FROM Usuarios 
            WHERE usuario = @usuario 
            AND contrasena = @contrasena";

            SqlParameter[] parametros =
            {
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contrasena", SqlDbType.VarBinary) { Value = contrasena }
            };

            int cantidad = Convert.ToInt32(conexion.ObtenerValor(consulta, parametros));

            return cantidad > 0;
        }

        public string TraerDNI(string usuario)
        {
            string consulta = @"
            SELECT dni 
            FROM Usuarios 
            WHERE usuario = @usuario ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@usuario", usuario)
            };

            object resultado = conexion.ObtenerValor(consulta, parametros);



            return resultado?.ToString();
        }

        public bool CambiarContraseñas(string usuario, byte[] contrasena)
        {
            string consulta = @"
            UPDATE Usuarios
            SET contrasena = @contrasena
            WHERE usuario = @usuario ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@contrasena", SqlDbType.VarBinary) { Value = contrasena },
                new SqlParameter("@usuario", usuario)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);

            return filas > 0;
        }

        public byte[] GenerarHash(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
            }
        }
    }
}
