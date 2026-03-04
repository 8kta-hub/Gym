using Gym.M;
using Gym.M.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            string consulta = @"
                SELECT
                    u.id_usuario,
                    u.nombre,
                    u.apellido,
                    u.foto,
                    r.nombre AS rol
                FROM Usuarios u
                LEFT JOIN Usuario_Rol ur ON ur.id_usuario = u.id_usuario
                LEFT JOIN Roles r        ON r.id_rol       = ur.id_rol
                WHERE u.usuario = @usuario";

            SqlParameter[] parametros =
            {
                new SqlParameter("@usuario", nombreUsuario)
            };

            DataTable dt = conexion.ObtenerTabla(consulta, parametros);

            if (dt.Rows.Count == 0) return null;

            DataRow fila = dt.Rows[0];

            return new Usuario
            {
                IdUsuario = Convert.ToInt32(fila["id_usuario"]),
                Nombre = fila["nombre"].ToString(),
                Apellido = fila["apellido"].ToString(),
                NombreUsuario = nombreUsuario,
                Rol = fila["rol"].ToString(),
                Foto = fila["foto"] == DBNull.Value ? null : (byte[])fila["foto"]
            };
        }
    }
}
