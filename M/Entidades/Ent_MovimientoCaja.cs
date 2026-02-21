using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class MovimientoCaja
    {
        public int IdMovimientoCaja { get; set; }
        public int IdUsuario { get; set; }
        public int IdConcepto { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal Monto { get; set; }
        public string Observaciones { get; set; }
    }
}