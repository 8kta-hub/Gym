using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorProductos
    {
        private ConDB conexion = new ConDB();

        public void ListarProductos(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    pr.id_producto,
                    p.nombre AS Proveedor,
                    pr.codigo,
                    pr.nombre,
                    pr.stock,
                    pr.costo,
                    pr.precio_venta,
                    pr.descripcion,
                    pr.estado,
                    pr.fecha_creacion
                FROM Productos pr
                INNER JOIN Proveedores p ON pr.id_proveedor = p.id_proveedor

            ";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
