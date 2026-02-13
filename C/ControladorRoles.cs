using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorRoles
    {
        private ConDB conexion = new ConDB();

        public void ListarRoles(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    nombre,
                    permiso,
                    descripcion,
                    activo
                FROM Roles
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
