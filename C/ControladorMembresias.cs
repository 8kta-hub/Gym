using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorMembresias
    {
        private ConDB conexion = new ConDB();

        public void ListarMembresias(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    id_membresias,
                    nombre,
                    precio,
                    tipo,
                    cantidad_msd,
                    fecha_creacion,
                    activo
                FROM Membresias
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
