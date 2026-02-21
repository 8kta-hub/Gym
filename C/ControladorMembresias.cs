using Gym.M;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorMembresias
    {
        private ConDB conexion = new ConDB();

        public void ListarMembresias(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    id_membresias,
                    nombre,
                    precio,
                    tipo,
                    cantidad_msd,
                    fecha_creacion,
                    fecha_vec,
                    activo
                FROM Membresias";
            conexion.CargarTabla(consulta, dgv);
        }

        public void ListarHorariosMembresia(int idMembresia, DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    id_horario,
                    dia,
                    hora_inicio,
                    hora_fin
                FROM Membresias_Horario
                WHERE id_membresias = @idMembresia";
            SqlParameter[] parametros =
            {
                new SqlParameter("@idMembresia", idMembresia)
            };
            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public bool InsertMembresia(string nombre, decimal precio, string tipo,
                                    int cantidadMsd, DateTime fechaVec, bool activo)
        {
            string consulta = @"
                INSERT INTO Membresias
                    (nombre, precio, tipo, cantidad_msd, fecha_creacion, fecha_vec, activo)
                VALUES
                    (@nombre, @precio, @tipo, @cantidadMsd, GETDATE(), @fechaVec, @activo)";
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",      nombre),
                new SqlParameter("@precio",      precio),
                new SqlParameter("@tipo",        tipo),
                new SqlParameter("@cantidadMsd", cantidadMsd),
                new SqlParameter("@fechaVec",    fechaVec),
                new SqlParameter("@activo",      activo)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool InsertHorarioMembresia(int idMembresia, TimeSpan horaInicio,
                                           TimeSpan horaFin, string dia)
        {
            string consulta = @"
                INSERT INTO Membresias_Horario
                    (id_membresias, hora_inicio, hora_fin, dia)
                VALUES
                    (@idMembresia, @horaInicio, @horaFin, @dia)";
            SqlParameter[] parametros =
            {
                new SqlParameter("@idMembresia", idMembresia),
                new SqlParameter("@horaInicio",  horaInicio),
                new SqlParameter("@horaFin",     horaFin),
                new SqlParameter("@dia",         dia)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool UpdateMembresia(int idMembresia, string nombre, decimal precio,
                                    string tipo, int cantidadMsd, DateTime fechaVec, bool activo)
        {
            string consulta = @"
                UPDATE Membresias SET
                    nombre       = @nombre,
                    precio       = @precio,
                    tipo         = @tipo,
                    cantidad_msd = @cantidadMsd,
                    fecha_vec    = @fechaVec,
                    activo       = @activo
                WHERE id_membresias = @idMembresia";
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",       nombre),
                new SqlParameter("@precio",       precio),
                new SqlParameter("@tipo",         tipo),
                new SqlParameter("@cantidadMsd",  cantidadMsd),
                new SqlParameter("@fechaVec",     fechaVec),
                new SqlParameter("@activo",       activo),
                new SqlParameter("@idMembresia",  idMembresia)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool UpdateHorarioMembresia(int idHorario, TimeSpan horaInicio,
                                           TimeSpan horaFin, string dia)
        {
            string consulta = @"
                UPDATE Membresias_Horario SET
                    hora_inicio = @horaInicio,
                    hora_fin    = @horaFin,
                    dia         = @dia
                WHERE id_horario = @idHorario";
            SqlParameter[] parametros =
            {
                new SqlParameter("@horaInicio", horaInicio),
                new SqlParameter("@horaFin",    horaFin),
                new SqlParameter("@dia",        dia),
                new SqlParameter("@idHorario",  idHorario)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool DeleteMembresia(int idMembresia)
        {
            string consulta = "UPDATE Membresias SET activo = 0 WHERE id_membresias = @idMembresia";
            SqlParameter[] parametros =
            {
                new SqlParameter("@idMembresia", idMembresia)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool DeleteHorarioMembresia(int idHorario)
        {
            string consulta = "DELETE FROM Membresias_Horario WHERE id_horario = @idHorario";
            SqlParameter[] parametros =
            {
                new SqlParameter("@idHorario", idHorario)
            };
            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }
    }
}
