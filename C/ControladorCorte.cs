using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorCorte
    {
        private ConDB conexion = new ConDB();

        public void ListarCorte(DataGridView dgv)
        {
            string consulta = @"
               SELECT 
                    c.id_corte_caja,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    c.inicio_fecha_hora,
                    c.fin_fecha_hora,
                    c.total_sistema,
                    c.total_real,
                    c.diferencia,
                    c.observacion,
                    c.estado
               FROM Corte_Caja c
               INNER JOIN Usuarios u ON c.id_usuario = u.id_usuario

            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
