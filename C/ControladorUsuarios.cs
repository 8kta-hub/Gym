using Gym.M;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorUsuarios
    {
        private ConDB conexion = new ConDB();

        public void ListarUsuarios(DataGridView dgv, string busqueda = "", string filtro = "Todos")
        {
            string whereFiltro = filtro == "Activo" ? "AND activo = 1"
                               : filtro == "Inactivo" ? "AND activo = 0"
                               : "";

            string consulta = $@"
                SELECT
                    id_usuario,
                    nombre,
                    apellido,
                    dni,
                    telefono,
                    email,
                    usuario,
                    horario_inicio,
                    horario_fin,
                    descripcion,
                    activo
                FROM Usuarios
                WHERE (
                    nombre   LIKE @busqueda OR
                    apellido LIKE @busqueda OR
                    dni      LIKE @busqueda OR
                    usuario  LIKE @busqueda OR
                    email    LIKE @busqueda
                )
                {whereFiltro}
                ORDER BY apellido, nombre";

            SqlParameter[] parametros =
            {
                new SqlParameter("@busqueda", "%" + busqueda + "%")
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public bool InsertarUsuario(string nombre, string apellido, string dni,
                                    string telefono, string email, string usuario,
                                    string contrasena, int idRol, TimeSpan horarioInicio,
                                    TimeSpan horarioFin, string descripcion)
        {
            string consulta = @"
                INSERT INTO Usuarios 
                    (nombre, apellido, dni, telefono, email, usuario, contrasena,
                     horario_inicio, horario_fin, descripcion, activo)
                VALUES 
                    (@nombre, @apellido, @dni, @telefono, @email, @usuario,
                     HASHBYTES('SHA2_256', @contrasena),
                     @horarioInicio, @horarioFin, @descripcion, 1);

                DECLARE @id_usuario INT = SCOPE_IDENTITY();

                INSERT INTO Usuario_Rol (id_usuario, id_rol)
                VALUES (@id_usuario, @idRol)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",        nombre),
                new SqlParameter("@apellido",      apellido),
                new SqlParameter("@dni",           dni),
                new SqlParameter("@telefono",      telefono),
                new SqlParameter("@email",         email),
                new SqlParameter("@usuario",       usuario),
                new SqlParameter("@contrasena",    contrasena),
                new SqlParameter("@horarioInicio", horarioInicio),
                new SqlParameter("@horarioFin",    horarioFin),
                new SqlParameter("@descripcion",   descripcion),
                new SqlParameter("@idRol",         idRol)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool UpdateUsuario(int idUsuario, string nombre, string apellido, string dni,
                                  string telefono, string email, string usuario,
                                  TimeSpan horarioInicio, TimeSpan horarioFin,
                                  string descripcion, bool activo)
        {
            string consulta = @"
                UPDATE Usuarios SET
                    nombre         = @nombre,
                    apellido       = @apellido,
                    dni            = @dni,
                    telefono       = @telefono,
                    email          = @email,
                    usuario        = @usuario,
                    horario_inicio = @horarioInicio,
                    horario_fin    = @horarioFin,
                    descripcion    = @descripcion,
                    activo         = @activo
                WHERE id_usuario = @idUsuario";

            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",        nombre),
                new SqlParameter("@apellido",      apellido),
                new SqlParameter("@dni",           dni),
                new SqlParameter("@telefono",      telefono),
                new SqlParameter("@email",         email),
                new SqlParameter("@usuario",       usuario),
                new SqlParameter("@horarioInicio", horarioInicio),
                new SqlParameter("@horarioFin",    horarioFin),
                new SqlParameter("@descripcion",   descripcion),
                new SqlParameter("@activo",        activo),
                new SqlParameter("@idUsuario",     idUsuario)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool UpdateContrasena(int idUsuario, string nuevaContrasena)
        {
            string consulta = @"
                UPDATE Usuarios 
                SET contrasena = HASHBYTES('SHA2_256', @contrasena)
                WHERE id_usuario = @idUsuario";

            SqlParameter[] parametros =
            {
                new SqlParameter("@contrasena", nuevaContrasena),
                new SqlParameter("@idUsuario",  idUsuario)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool DeleteUsuario(int idUsuario)
        {
            string consulta = "UPDATE Usuarios SET activo = 0 WHERE id_usuario = @idUsuario";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idUsuario", idUsuario)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }
    }
}