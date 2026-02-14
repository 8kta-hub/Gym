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
            INSERT INTO Clientes
            (cod_cliente, nombre, apellido, dni, telefono, email, activo, fecha_nac) 
            VALUES
            (@codCliente, @nombre, @apellido, @dni, @telefono, @email, @activo, @fechaNac)";

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
