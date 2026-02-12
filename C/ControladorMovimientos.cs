using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorMovimientos
    {
        private ConDB conexion = new ConDB();

        public void ListarMovimientos(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    mc.id_movimiento_caja,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    c.nombre AS Concepto,
                    mc.tipo_movimiento,
                    mc.fecha_creacion,
                    mc.monto,
                    mc.observaciones
                FROM Movimiento_Caja mc
                INNER JOIN Usuarios u ON mc.id_usuario = u.id_usuario
                INNER JOIN Conceptos c ON mc.id_concepto = c.id_concepto
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
