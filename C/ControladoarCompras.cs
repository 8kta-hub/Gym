using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladoarCompras
    {
        private ConDB conexion = new ConDB();

        public void ListarCompras(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    c.id_compra,
                    p.nombre AS Proveedor,
                    u.nombre + ' ' + u.apellido AS Usuario,
                    c.fecha,
                    c.total,
                    c.estado
                FROM Compras c
                INNER JOIN Proveedores p ON c.id_proveedor = p.id_proveedor
                INNER JOIN Usuarios u ON c.id_usuario = u.id_usuario

            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
