using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorUsuarios
    {
        private ConDB conexion = new ConDB();

        public void ListarUsuarios(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    id_usuario,
                    nombre,
                    apellido,
                    dni,
                    telefono,
                    email,
                    usuario,
                    descripcion,
                    estado
                FROM Usuarios
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
