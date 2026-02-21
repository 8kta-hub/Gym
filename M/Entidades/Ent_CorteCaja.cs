using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class CorteCaja
    {
        public int IdCorteCaja { get; set; }
        public int IdUsuario { get; set; }
        public DateTime InicioFechaHora { get; set; }
        public DateTime FinFechaHora { get; set; }
        public decimal TotalSistema { get; set; }
        public decimal TotalReal { get; set; }
        public decimal Diferencia { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
    }
}