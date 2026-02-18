using Gym.M;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorConceptos
    {
        private ConDB conexion = new ConDB();

        public void ListarConceptos(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    id_concepto,
                    nombre,
                    tipo,
                    activo,
                    fecha_creacion,
                    modificable
                FROM Conceptos
            ";

            conexion.CargarTabla(consulta, dgv);
        }

        public bool InsertConceptos(string nombre, string tipo, bool activo)
        {
            string consulta = @"
                INSERT INTO Conceptos
                    (nombre, tipo, activo)
                    VALUES
                (@nombre, @tipo, @activo)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@activo", activo)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool UpdateConceptos(int idConcepto, string nombre, string tipo, bool activo)
        {
            string consulta = @"
                UPDATE Conceptos SET
                    nombre = @nombre,
                    tipo = @tipo,
                    activo = @activo
                WHERE id_concepto = @idConcepto";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idConcepto", idConcepto),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@activo", activo)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool DeleteConceptos(int idConcepto)
        {
            string consulta = "UPDATE Conceptos SET Activo = 0 WHERE id_concepto = @IdConcepto";

            SqlParameter[] parametros =
            {
            new SqlParameter("@idConcepto", idConcepto)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }
    }
}
