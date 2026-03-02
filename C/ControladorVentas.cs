using Gym.M;
using System;
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
                    o.tipo,
                    o.estado
                FROM Operaciones o
                INNER JOIN Clientes c ON o.id_cliente = c.id_cliente
                INNER JOIN Usuarios u ON o.id_usuario = u.id_usuario";

            conexion.CargarTabla(consulta, dgv);
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


        // Lee el folio generado por SQL para mostrárselo al usuario
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

        // No borra el registro, cambia el estado a Anulado
        // Así se conserva el historial del pago
        public bool AnularPago(int idPago)
        {
            string consulta = "UPDATE Pagos SET estado = 'Anulado' WHERE id_pago = @idPago";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idPago", idPago)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }


        // JOIN con Operaciones para traer el folio junto con los datos del pago
        // ORDER BY DESC para mostrar el más reciente primero
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
    }
}