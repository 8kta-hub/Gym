using Gym.M;
using Gym.M.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorProveedores
    {
        private ConDB conexion = new ConDB();

        public void ListarProveedores(DataGridView dgv, string filtro = "Activo")
        {
            string whereFiltro = filtro == "Activo" ? "WHERE activo = 1"
                               : filtro == "Inactivo" ? "WHERE activo = 0"
                               : "";

            string consulta = $@"
                SELECT
                    id_proveedor,
                    nombre,
                    cuit,
                    telefono,
                    email,
                    activo,
                    fecha_creacion
                FROM Proveedores
                {whereFiltro}
                ORDER BY nombre";

            conexion.CargarTabla(consulta, dgv);
        }

        public List<Proveedor> ObtenerProveedoresActivos()
        {
            string consulta = @"
                SELECT id_proveedor, nombre
                FROM Proveedores
                WHERE activo = 1
                ORDER BY nombre";

            DataTable dt = conexion.ObtenerTabla(consulta);
            var lista = new List<Proveedor>();

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Proveedor
                {
                    IdProveedor = Convert.ToInt32(fila["id_proveedor"]),
                    Nombre = fila["nombre"].ToString()
                });
            }

            return lista;
        }

        public bool InsertProveedor(string nombre, string cuit, string telefono, string email)
        {
            string consulta = @"
                INSERT INTO Proveedores (nombre, cuit, telefono, email)
                VALUES (@nombre, @cuit, @telefono, @email)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",   nombre),
                new SqlParameter("@cuit",     cuit),
                new SqlParameter("@telefono", telefono),
                new SqlParameter("@email",    email)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        public bool UpdateProveedor(int idProveedor, string nombre, string cuit,
            string telefono, string email, bool activo)
        {
            string consulta = @"
                UPDATE Proveedores SET
                    nombre   = @nombre,
                    cuit     = @cuit,
                    telefono = @telefono,
                    email    = @email,
                    activo   = @activo
                WHERE id_proveedor = @idProveedor";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",      nombre),
                new SqlParameter("@cuit",        cuit),
                new SqlParameter("@telefono",    telefono),
                new SqlParameter("@email",       email),
                new SqlParameter("@activo",      activo),
                new SqlParameter("@idProveedor", idProveedor)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        public bool DeleteProveedor(int idProveedor)
        {
            string consulta = "UPDATE Proveedores SET activo = 0 WHERE id_proveedor = @idProveedor";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idProveedor", idProveedor)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }
    }
}