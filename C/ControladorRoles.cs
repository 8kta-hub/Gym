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

        private ConDB db = new ConDB();

        // ─────────────────────────────────────────
        // LISTAR
        // ─────────────────────────────────────────
        public void ListarRoles(DataGridView dgv)
        {
            string sql = @"SELECT id_rol,
                                  nombre,
                                  permiso,
                                  descripcion,
                                  CASE WHEN activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado
                           FROM   Roles
                           ORDER  BY nombre";
            db.CargarTabla(sql, dgv);
        }

        // ─────────────────────────────────────────
        // INSERT
        // ─────────────────────────────────────────
        public bool InsertRol(string nombre, string permiso, string descripcion, bool activo)
        {
            string sql = @"INSERT INTO Roles (nombre, permiso, descripcion, activo)
                           VALUES (@nombre, @permiso, @descripcion, @activo)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",  nombre),
                new SqlParameter("@permiso", permiso),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@activo",  activo)
            };

            int filas = db.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        // ─────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────
        public bool UpdateRol(int id_rol, string nombre, string permiso, string descripcion, bool activo)
        {
            string sql = @"UPDATE Roles
                           SET    nombre  = @nombre,
                                  permiso = @permiso,
                                  descripcion = @descripcion,
                                  activo  = @activo
                           WHERE  id_rol  = @id_rol";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",  nombre),
                new SqlParameter("@permiso", permiso),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@activo",  activo),
                new SqlParameter("@id_rol",  id_rol)
            };

            int filas = db.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        // ─────────────────────────────────────────
        // DELETE LÓGICO
        // ─────────────────────────────────────────
        public bool DeleteRol(int id_rol)
        {
            string sql = "UPDATE Roles SET activo = 0 WHERE id_rol = @id_rol";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_rol", id_rol)
            };

            int filas = db.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        // ─────────────────────────────────────────
        // COMBO (para asignar roles a usuarios)
        // ─────────────────────────────────────────
        public DataTable ObtenerRolesParaCombo()
        {
            string sql = "SELECT id_rol, nombre FROM Roles WHERE activo = 1 ORDER BY nombre";

            using (SqlConnection con = new SqlConnection(ConDB.strcnn))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool UpdatePermisosRol(int id_rol, string permiso)
        {
            string sql = @"UPDATE Roles
                           SET    permiso = @permiso
                           WHERE  id_rol  = @id_rol";
            SqlParameter[] parametros =
            {
                new SqlParameter("@permiso", permiso),
                new SqlParameter("@id_rol",  id_rol)
            };
            return db.EjecutarComando(sql, parametros) > 0;
        }
    }
}