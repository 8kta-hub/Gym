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
                Select 
                    m.fecha_creacion, 
                    c.tipo, 
                    c.nombre, 
                    m.monto, 
                    m.tipo_movimiento, 
                    u.usuario, 
                    m.observaciones 
                    From Movimiento_Caja m 
                    Inner Join Conceptos c on m.id_concepto = c.id_concepto 
                    Inner Join Usuarios u on m.id_usuario = u.id_usuario;
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
