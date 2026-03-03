using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}