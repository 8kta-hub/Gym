using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdOperacion { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; }
        public string Estado { get; set; }
    }
}