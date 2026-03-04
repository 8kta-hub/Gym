using Gym.M;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorInicio
    {
        private ConDB conexion = new ConDB();

        public void ListarEntradasDia(DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    r.ingreso                          AS Hora,
                    c.cod_cliente                      AS Codigo,
                    c.nombre + ' ' + c.apellido        AS Cliente,
                    m.nombre                           AS Membresia,
                    cm.clases_restantes                AS ClasesRestantes,
                    cm.fecha_vencimiento               AS Vencimiento
                FROM Registros r
                INNER JOIN Clientes c          ON r.id_cliente = c.id_cliente
                LEFT  JOIN Cliente_Membresias cm
                    ON cm.id_cliente = c.id_cliente
                    AND cm.estado    = 'Activo'
                LEFT  JOIN Membresias m        ON m.id_membresias = cm.id_membresias
                WHERE CAST(r.ingreso AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY r.ingreso DESC";

            conexion.CargarTabla(consulta, dgv);
        }

        public int ContarEntradasHoy()
        {
            string consulta = @"
                SELECT COUNT(*)
                FROM Registros
                WHERE CAST(ingreso AS DATE) = CAST(GETDATE() AS DATE)";

            object resultado = conexion.ObtenerValor(consulta, null);
            return resultado == null ? 0 : Convert.ToInt32(resultado);
        }
    }
}