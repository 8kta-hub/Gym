using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorMembresiasHorarios
    {
        private ConDB conexion = new ConDB();

        public void ListarMembresiasHorarios(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    h.id_horario,
                    m.nombre AS Membresia,
                    h.hora_inicio,
                    h.hora_fin,
                    h.dia
                FROM Membresias_Horario h
                INNER JOIN Membresias m ON h.id_membresias = m.id_membresias
            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
