using Gym.M;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.M.Entidades;

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

        public List<Membresia> ObtenerMembresiasActivas()
        {
            var lista = new List<Membresia>();

            string consulta = @"
                SELECT id_membresias, nombre , precio , tipo , cantidad_msd
                FROM Membresias
                WHERE activo = 1";

            DataTable dt = conexion.ObtenerTabla(consulta);

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Membresia
                {
                    IdMembresia = Convert.ToInt32(fila["id_membresias"]),
                    Nombre = fila["nombre"].ToString(),
                    Precio = Convert.ToDecimal(fila["precio"]),
                    Tipo = fila["tipo"].ToString(),
                    CantidadMsd = Convert.ToInt32(fila["cantidad_msd"])
                });
            }
            
            return lista;
        }

        // Devuelve un objeto Membresia por su ID
        // Lo usa frm_Clientes_Membresias para pasar la membresía al form de pago
        public Membresia ObtenerMembresiaPorId(int idMembresia)
        {
            string consulta = @"
        SELECT id_membresias, nombre, precio, tipo, cantidad_msd 
        FROM Membresias 
        WHERE id_membresias = @idMembresia";

            SqlParameter[] parametros =
            {
        new SqlParameter("@idMembresia", idMembresia)
    };

            DataTable dt = conexion.ObtenerTabla(consulta, parametros);

            if (dt.Rows.Count == 0) return null;

            return new Membresia
            {
                IdMembresia = Convert.ToInt32(dt.Rows[0]["id_membresias"]),
                Nombre = dt.Rows[0]["nombre"].ToString(),
                Precio = Convert.ToDecimal(dt.Rows[0]["precio"]),
                Tipo = dt.Rows[0]["tipo"].ToString(),
                CantidadMsd = Convert.ToInt32(dt.Rows[0]["cantidad_msd"])
            };
        }
        public bool InsertMembresia(string nombre, decimal precio, string tipo,
                                    int cantidadMsd, bool activo)
        {
            string consulta = @"
                INSERT INTO Membresias
                    (nombre, precio, tipo, cantidad_msd, fecha_creacion, activo)
                VALUES
                    (@nombre, @precio, @tipo, @cantidadMsd, GETDATE(), @activo)";
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",      nombre),
                new SqlParameter("@precio",      precio),
                new SqlParameter("@tipo",        tipo),
                new SqlParameter("@cantidadMsd", cantidadMsd),
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
                                    string tipo, int cantidadMsd, bool activo)
        {
            string consulta = @"
                UPDATE Membresias SET
                    nombre       = @nombre,
                    precio       = @precio,
                    tipo         = @tipo,
                    cantidad_msd = @cantidadMsd,
                    activo       = @activo
                WHERE id_membresias = @idMembresia";
            SqlParameter[] parametros =
            {
                new SqlParameter("@nombre",       nombre),
                new SqlParameter("@precio",       precio),
                new SqlParameter("@tipo",         tipo),
                new SqlParameter("@cantidadMsd",  cantidadMsd),
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
