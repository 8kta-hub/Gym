using Gym.M;
using Gym.M.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorVentas
    {
        private ConDB conexion = new ConDB();

        public void ListarVentas(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    o.id_operacion,
                    o.folio,
                    c.nombre + ' ' + c.apellido AS Cliente,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    o.fecha,
                    o.total,
                    o.estado
                FROM Operaciones o
                INNER JOIN Clientes c ON o.id_cliente = c.id_cliente
                INNER JOIN Usuarios u ON o.id_usuario = u.id_usuario
                ORDER BY o.fecha DESC";

            conexion.CargarTabla(consulta, dgv);
        }

        public bool DeleteVenta(int idVenta)
        {
            string consulta = "UPDATE Ventas SET estado = 'Cancelada' WHERE id_operacion = @id_operacion";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_operacion", idVenta)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        public void ObtenerDetalleVenta(int idVenta, DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    pr.nombre          AS Producto,
                    do.cantidad        AS Cantidad,
                    do.precio_unitario AS CostoUnitario,
                    do.subtotal        AS Subtotal
                FROM Detalle_Operacion do
                INNER JOIN Productos pr ON do.id_producto = pr.id_producto
                WHERE do.id_operacion = @id_operacion";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_operacion", idVenta)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public int InsertOperacion(int idCliente, decimal total)
        {
            string consulta = @"
                INSERT INTO Operaciones
                    (id_cliente, id_usuario, fecha, total, tipo, estado)
                VALUES
                    (@idCliente, 1, GETDATE(), @total, 'Venta', 'Pagado');

                SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idCliente", idCliente),
                new SqlParameter("@total",     total)
            };

            DataTable dt = conexion.ObtenerTabla(consulta, parametros);
            return Convert.ToInt32(dt.Rows[0][0]);
        }


        public bool InsertPago(int idOperacion, decimal monto, string metodo, string observacion)
        {
            string consulta = @"
                INSERT INTO Pagos
                    (id_operacion, monto, metodo, estado, observaciones)
                VALUES
                    (@idOperacion, @monto, @metodo, 'Aprobado', @observacion)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idOperacion",  idOperacion),
                new SqlParameter("@monto",        monto),
                new SqlParameter("@metodo",       metodo),
                new SqlParameter("@observacion",  observacion)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        public string ObtenerFolio(int idOperacion)
        {
            string consulta = "SELECT folio FROM Operaciones WHERE id_operacion = @idOperacion";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idOperacion", idOperacion)
            };

            DataTable dt = conexion.ObtenerTabla(consulta, parametros);
            return dt.Rows[0]["folio"].ToString();
        }

        public bool AnularPago(int idPago)
        {
            string consulta = "UPDATE Pagos SET estado = 'Anulado' WHERE id_pago = @idPago";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idPago", idPago)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }


        public void ListarPagosPorMembresia(int idClienteMembresia, DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    p.id_pago,
                    p.id_operacion,
                    o.folio,
                    p.fecha_hora    AS Fecha,
                    p.monto         AS Monto,
                    p.metodo        AS Método,
                    p.estado        AS Estado,
                    p.observaciones AS Observación
                FROM Pagos p
                INNER JOIN Operaciones o ON p.id_operacion = o.id_operacion
                INNER JOIN Cliente_Membresias cm ON o.id_cliente = cm.id_cliente
                WHERE cm.id_cliente_membresias = @idClienteMembresia
                ORDER BY p.fecha_hora DESC";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idClienteMembresia", idClienteMembresia)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public bool InsertVentaCompleta(int idCliente, int idUsuario,
            List<DetalleVentaItem> items)
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
                        INSERT INTO Operaciones (id_cliente, id_usuario, fecha, total, estado)
                        VALUES (@id_cliente, @id_usuario, GETDATE(), @total, 'Finalizada');
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdCabecera = new SqlCommand(sqlCabecera, cn, tx);
                    cmdCabecera.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmdCabecera.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmdCabecera.Parameters.AddWithValue("@total", total);

                    int idOperacion = Convert.ToInt32(cmdCabecera.ExecuteScalar());

                    string sqlMovimiento = @"
                    INSERT INTO Movimiento_Caja
                        (id_usuario, id_concepto, tipo_movimiento, fecha_creacion, monto, observaciones)
                    VALUES
                        (@id_usuario, @id_concepto, @tipo_movimiento, GETDATE(), @monto, @observaciones)";

                    SqlCommand cmdMovimiento = new SqlCommand(sqlMovimiento, cn, tx);

                    cmdMovimiento.Parameters.AddWithValue("@id_usuario", idUsuario);
                    cmdMovimiento.Parameters.AddWithValue("@id_concepto", 1); // 🔥 ID concepto Venta
                    cmdMovimiento.Parameters.AddWithValue("@tipo_movimiento", "Ingreso");
                    cmdMovimiento.Parameters.AddWithValue("@monto", total);
                    cmdMovimiento.Parameters.AddWithValue("@observaciones", "Venta de productos");

                    cmdMovimiento.ExecuteNonQuery();

                    foreach (var item in items)
                    {
                        string sqlDetalle = @"
                            INSERT INTO Detalle_Operacion
                                (id_operacion, id_producto, cantidad, precio_unitario, subtotal)
                            VALUES
                                (@id_operacion, @id_producto, @cantidad, @precioUnitario, @subtotal)";

                        SqlCommand cmdDetalle = new SqlCommand(sqlDetalle, cn, tx);
                        cmdDetalle.Parameters.AddWithValue("@id_operacion", idOperacion);
                        cmdDetalle.Parameters.AddWithValue("@id_producto", item.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precioUnitario", item.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                        cmdDetalle.ExecuteNonQuery();

                        string sqlStock = @"
                        UPDATE Productos 
                        SET stock = stock - @cantidad
                        WHERE id_producto = @id_producto
                        AND stock >= @cantidad";

                        SqlCommand cmdStock = new SqlCommand(sqlStock, cn, tx);
                        cmdStock.Parameters.AddWithValue("@cantidad", item.Cantidad);
                        cmdStock.Parameters.AddWithValue("@id_producto", item.IdProducto);

                        int filasAfectadas = cmdStock.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            throw new Exception("Stock insuficiente para el producto.");
                        }
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
    }
}