using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    estado,
                    fecha_creacion,
                    modificable
                FROM Conceptos
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
