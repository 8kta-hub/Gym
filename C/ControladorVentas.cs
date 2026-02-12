using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    c.nombre + ' ' + c.apellido AS Cliente,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    o.fecha,
                    o.total,
                    o.tipo,
                    o.estado
                FROM Operaciones o
                INNER JOIN Clientes c ON o.id_cliente = c.id_cliente
                INNER JOIN Usuarios u ON o.id_usuario = u.id_usuario

            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
