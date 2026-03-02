using Gym.M;
using Gym.M.Entidades;
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

        //------------------------------------------------MEMBRESIA CLIENTE--------------------------------------------------

        public void ListarMembresiasDeCliente(int idCliente, DataGridView dgv, string filtro = "Activo")
        {
            string whereFiltro = filtro == "Todas"
                ? ""
                : "AND cm.estado = @filtro";

            string consulta = $@"
                SELECT 
                    cm.id_cliente_membresias,
                    cm.id_cliente,
                    cm.id_membresias,
                    m.nombre             AS Membresía,
                    cm.precio_congelado  AS Precio,
                    m.tipo               AS Tipo,
                    cm.fecha_inicio      AS Inicio,
                    cm.fecha_vencimiento AS Vencimiento,
                    cm.estado            AS Estado
                FROM Cliente_Membresias cm
                INNER JOIN Membresias m ON cm.id_membresias = m.id_membresias
                WHERE cm.id_cliente = @idCliente
                {whereFiltro}";

            SqlParameter[] parametros = filtro == "Todas"
                ? new SqlParameter[] { new SqlParameter("@idCliente", idCliente) }
                : new SqlParameter[]
                {
                    new SqlParameter("@idCliente", idCliente),
                    new SqlParameter("@filtro",    filtro)
                };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public bool InsertClienteMembresia(int idCliente, int idMembresia, decimal precioCongelado)
        {
            string consulta = @"
                INSERT INTO Cliente_Membresias
                    (id_cliente, id_membresias, precio_congelado, fecha_inicio, fecha_vencimiento, estado)
                VALUES
                    (@idCliente, @idMembresia, @precio, '1900-01-01', '1900-01-01', 'Pendiente de pago')";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idCliente",   idCliente),
                new SqlParameter("@idMembresia", idMembresia),
                new SqlParameter("@precio",      precioCongelado)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        // Se llama al confirmar el pago para actualizar fechas y estado
        public bool ConfirmarPagoMembresia(int idClienteMembresia, DateTime fechaInicio, int cantidadMsd)
        {
            DateTime fechaVencimiento = fechaInicio.AddDays(cantidadMsd);

            string consulta = @"
                UPDATE Cliente_Membresias SET
                    fecha_inicio      = @fechaInicio,
                    fecha_vencimiento = @fechaVencimiento,
                    estado            = 'Activo'
                WHERE id_cliente_membresias = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicio",      fechaInicio),
                new SqlParameter("@fechaVencimiento", fechaVencimiento),
                new SqlParameter("@id",               idClienteMembresia)
             };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }

        // Marca como Inactiva la membresía de un cliente (baja lógica)
        // No borra el registro para conservar el historial
        public bool DeleteClienteMembresia(int idClienteMembresia)
        {
            // Recibe el id de la fila en Cliente_Membresias, no el id del cliente
            // así toca exactamente esa asignación y no otras del mismo cliente
            string consulta = @"
                UPDATE Cliente_Membresias 
                SET estado = 'Inactivo' 
                WHERE id_cliente_membresias = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", idClienteMembresia)
            };

            return conexion.EjecutarComando(consulta, parametros) > 0;
        }
    }
}
