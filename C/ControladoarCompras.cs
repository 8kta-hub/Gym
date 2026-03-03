using Gym.M;
using Gym.M.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladoarCompras
    {
        private ConDB conexion = new ConDB();

        public void ListarCompras(DataGridView dgv, DateTime fechaInicio, DateTime fechaFin)
        {
            string consulta = @"
                SELECT
                    c.id_compra,
                    p.nombre AS Proveedor,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    c.fecha,
                    c.total,
                    c.estado
                FROM Compras c
                INNER JOIN Proveedores p ON c.id_proveedor = p.id_proveedor
                INNER JOIN Usuarios u   ON c.id_usuario   = u.id_usuario
                WHERE c.fecha BETWEEN @fechaInicio AND @fechaFin
                ORDER BY c.fecha DESC";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicio", fechaInicio.Date),
                new SqlParameter("@fechaFin",    fechaFin.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public void ObtenerDetalleCompra(int idCompra, DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    pr.nombre          AS Producto,
                    dc.cantidad        AS Cantidad,
                    dc.precio_unitario AS CostoUnitario,
                    dc.subtotal        AS Subtotal
                FROM Detalle_Compra dc
                INNER JOIN Productos pr ON dc.id_producto = pr.id_producto
                WHERE dc.id_compra = @idCompra";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idCompra", idCompra)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public bool InsertCompraCompleta(int idProveedor, int idUsuario,
            List<DetalleCompraItem> items)
        {
            decimal total = 0;
            foreach (var item in items)
                total += item.Subtotal;

            using (SqlConnection cn = new SqlConnection(ConDB.strcnn))
            {
                cn.Open();
                SqlTransaction tx = cn.BeginTransaction();

                try
                {
                    string sqlCabecera = @"
                        INSERT INTO Compras (id_proveedor, id_usuario, fecha, total, estado)
                        VALUES (@idProveedor, @idUsuario, GETDATE(), @total, 'Finalizada');
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdCabecera = new SqlCommand(sqlCabecera, cn, tx);
                    cmdCabecera.Parameters.AddWithValue("@idProveedor", idProveedor);
                    cmdCabecera.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdCabecera.Parameters.AddWithValue("@total", total);

                    int idCompra = Convert.ToInt32(cmdCabecera.ExecuteScalar());

                    foreach (var item in items)
                    {
                        string sqlDetalle = @"
                            INSERT INTO Detalle_Compra
                                (id_compra, id_producto, cantidad, precio_unitario, subtotal)
                            VALUES
                                (@idCompra, @idProducto, @cantidad, @precioUnitario, @subtotal)";

                        SqlCommand cmdDetalle = new SqlCommand(sqlDetalle, cn, tx);
                        cmdDetalle.Parameters.AddWithValue("@idCompra", idCompra);
                        cmdDetalle.Parameters.AddWithValue("@idProducto", item.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precioUnitario", item.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                        cmdDetalle.ExecuteNonQuery();

                        string sqlStock = @"
                            UPDATE Productos SET stock = stock + @cantidad
                            WHERE id_producto = @idProducto";

                        SqlCommand cmdStock = new SqlCommand(sqlStock, cn, tx);
                        cmdStock.Parameters.AddWithValue("@cantidad", item.Cantidad);
                        cmdStock.Parameters.AddWithValue("@idProducto", item.IdProducto);
                        cmdStock.ExecuteNonQuery();
                    }

                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                }
            }
        }

        public bool DeleteCompra(int idCompra)
        {
            string consulta = "UPDATE Compras SET estado = 'Cancelada' WHERE id_compra = @idCompra";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idCompra", idCompra)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }
    }
}