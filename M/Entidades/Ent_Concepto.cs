using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class Concepto
    {
        public int IdConcepto { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Modificable { get; set; }
    }
}
