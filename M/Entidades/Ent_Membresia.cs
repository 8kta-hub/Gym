using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class Membresia
    {
        public int IdMembresia { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Tipo { get; set; }
        public int CantidadMsd { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        // Relación con horarios
        public List<MembresiaHorario> Horarios { get; set; } = new List<MembresiaHorario>();
    }

    public class MembresiaHorario
    {
        public int IdHorario { get; set; }
        public int IdMembresia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Dia { get; set; }
    }
}



