using Gym.M;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorRoles
    {
        private ConDB conexion = new ConDB();

        public void ListarRoles(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    nombre,
                    permiso,
                    descripcion,
                    activo
                FROM Roles
            ";
            conexion.CargarTabla(consulta, dgv);
        }

        // Para cargar el combo en frm_Usuarios_Roles
        public DataTable ObtenerRoles()
        {
            string consulta = "SELECT id_rol, nombre, permiso FROM Roles WHERE activo = 1";
            using (SqlConnection cnn = new SqlConnection(ConDB.strcnn))
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter(consulta, cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool UpdatePermisosRol(int idRol, string permisos)
        {
            string consulta = "UPDATE Roles SET permiso = @permiso WHERE id_rol = @idRol";
            SqlParameter[] parametros =
            {
                new SqlParameter("@permiso", permisos),
                new SqlParameter("@idRol",   idRol)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }
    }
}