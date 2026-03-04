using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class Operacion
    {
        public int IdOperacion { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCliente { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreProducto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }

    public class DetalleVentaItem
    {
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}