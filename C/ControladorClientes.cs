using Gym.M;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorClientes
    {
        private ConDB conexion = new ConDB();

        public void ListarClientes(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    id_cliente,
                    cod_cliente,
                    nombre,
                    apellido,
                    dni,
                    telefono,
                    email,
                    fecha_nac,
                    activo
                FROM Clientes";

            conexion.CargarTabla(consulta, dgv);
        }

        public bool InsertClienteMembresia(int idCliente, int idMembresia,
                                    decimal precioCongelado, DateTime fechaInicio)
        {
            // Busca cantidad_msd para calcular la fecha de vencimiento
            // Ahora usa ConDB en vez de abrir conexión manualmente
            string consultaDias = "SELECT cantidad_msd FROM Membresias WHERE id_membresias = @idMembresia";
            SqlParameter[] paramDias =
            {
                new SqlParameter("@idMembresia", idMembresia)
            };

            DataTable dt = conexion.ObtenerTabla(consultaDias, paramDias);
            int dias = Convert.ToInt32(dt.Rows[0]["cantidad_msd"]);
            // dt.Rows[0] accede a la primera (y única) fila del resultado

            // Calcula la fecha de vencimiento sumando los días a la fecha de inicio
            DateTime fechaVencimiento = fechaInicio.AddDays(dias);

            string consulta = @"
            INSERT INTO Cliente_Membresias
                (id_cliente, id_membresias, precio_congelado, fecha_inicio, fecha_vencimiento, estado)
            VALUES
                (@idCliente, @idMembresia, @precio, @fechaInicio, @fechaVencimiento, 'Activo')";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idCliente",        idCliente),
                new SqlParameter("@idMembresia",      idMembresia),
                new SqlParameter("@precio",           precioCongelado),
                new SqlParameter("@fechaInicio",      fechaInicio),
                new SqlParameter("@fechaVencimiento", fechaVencimiento)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        public bool InsertClientes(int codCliente, string nombre,
                                   string apellido, string dni, string telefono,
                                   string email, bool activo, DateTime fechaNac)
        {
            string consulta = @"
                    INSERT INTO Clientes
                    (cod_cliente, nombre, apellido, dni, telefono, email, fecha_nac, activo)
                    VALUES
                    (@codCliente, @nombre, @apellido, @dni, @telefono, @email, @fechaNac, @activo)";

            SqlParameter[] parametros =
            {
                        new SqlParameter("@codCliente", codCliente),
                        new SqlParameter("@nombre", nombre),
                        new SqlParameter("@apellido", apellido),
                        new SqlParameter("@dni", dni),
                        new SqlParameter("@telefono", telefono),
                        new SqlParameter("@email", email),
                        new SqlParameter("@activo", activo),
                        new SqlParameter("@fechaNac", fechaNac)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool UpdateClientes(int idCliente, int codCliente, string nombre,
                                   string apellido, string dni, string telefono,
                                   string email, bool activo, DateTime fechaNac)
        {
            string consulta = @"
                    UPDATE Clientes SET
                        cod_cliente = @codCliente,
                        nombre = @nombre,
                        apellido = @apellido,
                        dni = @dni,
                        telefono = @telefono,
                        email = @email,
                        activo = @activo,
                        fecha_nac = @fechaNac
                    WHERE id_cliente = @idCliente";

            SqlParameter[] parametros =
            {
                new SqlParameter("@codCliente", codCliente),
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellido", apellido),
                new SqlParameter("@dni", dni),
                new SqlParameter("@telefono", telefono),
                new SqlParameter("@email", email),
                new SqlParameter("@activo", activo),
                new SqlParameter("@fechaNac", fechaNac),
                new SqlParameter("@idCliente", idCliente)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }

        public bool DeleteClientes(int idCliente)
        {
            string consulta = "UPDATE Clientes SET Activo = 0 WHERE id_cliente = @IdCliente";

            SqlParameter[] parametros =
            {
            new SqlParameter("@idCliente", idCliente)
            };

            int filas = conexion.EjecutarComando(consulta, parametros);
            return filas > 0;
        }
    }
}
