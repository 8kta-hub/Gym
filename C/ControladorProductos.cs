using Gym.M;
using Gym.M.Entidades;
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
    internal class ControladorProductos
    {
        private ConDB conexion = new ConDB();

        public void ListarProductos(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    p.nombre AS Proveedor,
                    pr.codigo,
                    pr.nombre,
                    pr.stock,
                    pr.costo,
                    pr.precio_venta,
                    pr.descripcion,
                    pr.activo,
                    pr.fecha_creacion
                FROM Productos pr
                INNER JOIN Proveedores p ON pr.id_proveedor = p.id_proveedor
            ";

            conexion.CargarTabla(consulta, dgv);
        }

        public List<Producto> ObtenerProductosActivos()
        {
            string consulta = @"
        SELECT id_producto, codigo, nombre, costo, precio_venta
        FROM Productos
        WHERE activo = 1
        ORDER BY nombre";

            DataTable dt = conexion.ObtenerTabla(consulta);
            var lista = new List<Producto>();

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Producto
                {
                    IdProducto = Convert.ToInt32(fila["id_producto"]),
                    Codigo = Convert.ToInt32(fila["codigo"]),
                    Nombre = fila["nombre"].ToString(),
                    Costo = Convert.ToDecimal(fila["costo"]),
                    PrecioVenta = Convert.ToDecimal(fila["precio_venta"])
                });
            }

            return lista;
        }

        // ─────────────────────────────────────────
        // INSERT
        // ─────────────────────────────────────────
        public bool InsertProducto(int codigo, string nombre, int stock, decimal costo, decimal precioVenta, string descripcion, bool activo)
        {
            string sql = @"INSERT INTO Productos (codigo, nombre, stock, costo, precio_venta, descripcion, activo)
                           VALUES (@codigo, @nombre, @stock, @costo, @precio_venta, @descripcion, @activo, @fecha_creacion)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@codigo", codigo),
                new SqlParameter("@nombre",  nombre),
                new SqlParameter("@stock", stock),
                new SqlParameter("@costo", costo),
                new SqlParameter("@precio_venta", precioVenta),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@activo", activo)
            };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        // ─────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────
        public bool UpdateProducto(int id_producto, int codigo, string nombre, int stock, decimal costo, decimal precioVenta, string descripcion)
        {
            string sql = @"UPDATE Productos
                           SET    codigo  = @codigo,
                                  nombre  = @nombre,
                                  stock = @stock,
                                  costo = @costo,
                                  precio_venta = @precio_venta,
                                  descripcion = @descripcion
                           WHERE  id_producto  = @id_producto";

            SqlParameter[] parametros =
            {
                new SqlParameter("@codigo", codigo),
                new SqlParameter("@nombre",  nombre),
                new SqlParameter("@stock", stock),
                new SqlParameter("@costo", costo),
                new SqlParameter("@precio_venta", precioVenta),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@id_producto",  id_producto)
            };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        // ─────────────────────────────────────────
        // DELETE LÓGICO
        // ─────────────────────────────────────────
        public bool DeleteProducto(int id_producto)
        {
            string sql = "UPDATE Producto SET activo = 0 WHERE id_producto = @id_producto";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_producto", id_producto)
            };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }
    }
}
