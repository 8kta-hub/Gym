using Gym.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym.C
{
    internal class ControladorUsuarios
    {
        private ConDB conexion = new ConDB();

        public void ListarUsuarios(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    nombre,
                    apellido,
                    dni,
                    telefono,
                    email,
                    usuario,
                    descripcion,
                    estado
                FROM Usuarios
            ";

            conexion.CargarTabla(consulta, dgv);
        }

        public bool InsertarUsuario(string nombre, string apellido, string dni, 
                                    string telefono, string email, string usuario, string contrasena,
                                    int idRol, DateTime horarioInicio,
                                    DateTime horarioFin, string descripcion)
        {
            string comando = 
                @"Insert Into Usuarios (nombre, apellido, dni, telefono, email, usuario, contrasena, descripcion) 
                Values (@nombre, @apellido, @dni, @telefono, @email, @usuario, @contrasena, @descripcion)

                Declare @id_usuario int = Scope_Identity();

                Insert Into Usuario_Rol (id_usuario, id_rol)
                Values (@id_usuario, @id_rol)
                ";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellido", apellido),
                new SqlParameter("@dni", dni),
                new SqlParameter("@telefono", telefono),
                new SqlParameter("@email", email),
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@contrasena", contrasena),
                new SqlParameter("@descripcion", descripcion),
                new SqlParameter("@id_rol", idRol)
            };

            int filas = conexion.EjecutarComando(comando, parametros);

            return filas > 0;


        }
    }
}
