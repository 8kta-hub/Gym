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
                    p.id_proveedor,
                    p.nombre AS Proveedor,
                    pr.id_producto,
                    pr.codigo,
                    pr.nombre AS ProductoNombre,
                    pr.stock,
                    pr.costo,
                    pr.precio_venta,
                    pr.descripcion,
                    pr.estado,
                    pr.fecha_creacion
                FROM Productos pr
                INNER JOIN Proveedores p ON pr.id_proveedor = p.id_proveedor
            ";

            conexion.CargarTabla(consulta, dgv);
        }

        

        // ─────────────────────────────────────────
        // INSERT
        // ─────────────────────────────────────────
        public bool InsertProducto(int idProveedor, int codigo, string nombre, int stock, decimal costo, decimal precioVenta, string descripcion)
        {
            string sql = @"INSERT INTO Productos (id_proveedor, codigo, nombre, stock, costo, precio_venta, descripcion)
                           VALUES (@id_proveedor, @codigo, @nombre, @stock, @costo, @precio_venta, @descripcion)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_proveedor", idProveedor),
                new SqlParameter("@codigo", codigo),
                new SqlParameter("@nombre",  nombre),
                new SqlParameter("@stock", stock),
                new SqlParameter("@costo", costo),
                new SqlParameter("@precio_venta", precioVenta),
                new SqlParameter("@descripcion", descripcion)
            };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        // ─────────────────────────────────────────
        // UPDATE
        // ─────────────────────────────────────────
        public bool UpdateProducto(int id_producto, int idProveedor, int codigo, string nombre, int stock, decimal costo, decimal precioVenta, string descripcion, string estado)
        {
            string sql = @"UPDATE Productos
                           SET    id_proveedor = @id_proveedor,
                                  codigo  = @codigo,
                                  nombre  = @nombre,
                                  stock = @stock,
                                  costo = @costo,
                                  precio_venta = @precio_venta,
                                  descripcion = @descripcion,
                                  estado = @estado
                           WHERE  id_producto  = @id_producto";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_proveedor", idProveedor),
                new SqlParameter("@codigo", codigo),
                new SqlParameter("@nombre",  nombre),
                new SqlParameter("@stock", stock),
                new SqlParameter("@costo", costo),
                new SqlParameter("@precio_venta", precioVenta),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@estado", estado),
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
            string sql = "UPDATE Productos SET estado = 'Inactivo' WHERE id_producto = @id_producto";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_producto", id_producto)
            };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }

       public void CargarProveedoresEnCombo(ComboBox cmb)
        {
            string consulta = @"
            SELECT id_proveedor, nombre
            FROM Proveedores
            WHERE activo = 1";

            DataTable dt = conexion.ObtenerTabla(consulta);

            cmb.DataSource = dt;
            cmb.DisplayMember = "nombre";      // Lo que se muestra
            cmb.ValueMember = "id_proveedor";  // Lo que se guarda
            cmb.SelectedIndex = -1;
        }

        public List<Producto> ObtenerProductosActivos()
        {
            string consulta = @"
            SELECT id_producto, codigo, nombre, costo, precio_venta
            FROM Productos
            WHERE estado = 'Activo'
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
    }
}
