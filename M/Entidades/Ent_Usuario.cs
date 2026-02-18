using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.M.Entidades
{
    public class EntUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NomUsuario { get; set; }
        public byte[] Contraseña { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public byte[] Foto { get; set; }
    }
}
