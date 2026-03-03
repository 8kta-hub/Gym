using Gym.M;
using Gym.M.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Gym.C
{
    internal class ControladorRegistro
    {
        private ConDB conexion = new ConDB();

        public DataTable BuscarClientePorCodigo(int codCliente)
        {
            string consulta = @"
                SELECT 
                    c.id_cliente,
                    c.nombre,
                    c.apellido,
                    c.dni,
                    c.activo,
                    cm.fecha_vencimiento,
                    cm.estado AS estado_membresia,
                    DATEDIFF(DAY, CAST(GETDATE() AS DATE), cm.fecha_vencimiento) AS dias_restantes,
                    (
                        SELECT COUNT(*) 
                        FROM Cliente_Membresias cm2 
                        WHERE cm2.id_cliente = c.id_cliente 
                        AND cm2.estado = 'Pendiente de pago'
                    ) AS membresias_pendientes
                FROM Clientes c
                LEFT JOIN Cliente_Membresias cm 
                    ON cm.id_cliente = c.id_cliente 
                    AND cm.estado = 'Activo'
                WHERE c.cod_cliente = @codCliente";

            SqlParameter[] parametros =
            {
                new SqlParameter("@codCliente", codCliente)
            };

            return conexion.ObtenerTabla(consulta, parametros);
        }

        public bool RegistrarIngreso(int idCliente)
        {
            string consulta = @"
                INSERT INTO Registros (id_cliente, ingreso)
                VALUES (@idCliente, GETDATE())";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idCliente", idCliente)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }
    }
}