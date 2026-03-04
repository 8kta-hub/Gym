using Gym.M;
using System;
using System.Collections.Generic;
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
                    cm.id_cliente_membresias,
                    cm.id_membresias,
                    cm.fecha_inicio,
                    cm.fecha_vencimiento,
                    cm.clases_restantes,
                    cm.ultima_clase,
                    cm.estado AS estado_membresia,
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

        private List<string> ObtenerDiasDeClase(int idMembresia)
        {
            string consulta = @"
                SELECT DISTINCT dia 
                FROM Membresias_Horario 
                WHERE id_membresias = @idMembresia";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idMembresia", idMembresia)
            };

            DataTable dt = conexion.ObtenerTabla(consulta, parametros);
            var dias = new List<string>();

            foreach (DataRow fila in dt.Rows)
                dias.Add(fila["dia"].ToString());

            return dias;
        }

        private int ContarDiasDeClasePerdidos(DateTime desde, DateTime hasta, List<string> diasDeClase)
        {
            var mapaDias = new Dictionary<DayOfWeek, string>
            {
                { DayOfWeek.Monday,    "Lunes"      },
                { DayOfWeek.Tuesday,   "Martes"     },
                { DayOfWeek.Wednesday, "Miércoles"  },
                { DayOfWeek.Thursday,  "Jueves"     },
                { DayOfWeek.Friday,    "Viernes"    },
                { DayOfWeek.Saturday,  "Sábado"     },
                { DayOfWeek.Sunday,    "Domingo"    }
            };

            int perdidos = 0;
            DateTime cursor = desde;

            while (cursor < hasta)
            {
                string nombreDia = mapaDias[cursor.DayOfWeek];
                if (diasDeClase.Contains(nombreDia))
                    perdidos++;

                cursor = cursor.AddDays(1);
            }

            return perdidos;
        }

        // Devuelve las clases restantes después del ingreso, o -1 si falló
        public int RegistrarIngreso(int idCliente, int idClienteMembresia,
            int idMembresia, int clasesRestantes, DateTime? ultimaClase, DateTime fechaInicio)
        {
            List<string> diasDeClase = ObtenerDiasDeClase(idMembresia);

            DateTime desde = ultimaClase.HasValue
                ? ultimaClase.Value.AddDays(1)
                : fechaInicio;

            DateTime hoy = DateTime.Today;

            int perdidas = ContarDiasDeClasePerdidos(desde, hoy, diasDeClase);
            int nuevasClases = clasesRestantes - perdidas - 1;
            if (nuevasClases < 0) nuevasClases = 0;

            using (SqlConnection cn = new SqlConnection(ConDB.strcnn))
            {
                cn.Open();
                SqlTransaction tx = cn.BeginTransaction();

                try
                {
                    string sqlUpdate = @"
                        UPDATE Cliente_Membresias
                        SET clases_restantes = @clases,
                            ultima_clase     = @hoy
                        WHERE id_cliente_membresias = @idClienteMembresia";

                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cn, tx);
                    cmdUpdate.Parameters.AddWithValue("@clases", nuevasClases);
                    cmdUpdate.Parameters.AddWithValue("@hoy", hoy);
                    cmdUpdate.Parameters.AddWithValue("@idClienteMembresia", idClienteMembresia);
                    cmdUpdate.ExecuteNonQuery();

                    string sqlIngreso = @"
                        INSERT INTO Registros (id_cliente, ingreso)
                        VALUES (@idCliente, GETDATE())";

                    SqlCommand cmdIngreso = new SqlCommand(sqlIngreso, cn, tx);
                    cmdIngreso.Parameters.AddWithValue("@idCliente", idCliente);
                    cmdIngreso.ExecuteNonQuery();

                    tx.Commit();
                    return nuevasClases;
                }
                catch
                {
                    tx.Rollback();
                    return -1;
                }
            }
        }
    }
}