using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.M;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Gym.C
{
    public class ControladorReportes
    {
        private ConDB conexion = new ConDB();

        public void ListarReportesInventario(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    nombre,
                    costo,
                    precio_venta,
                    stock,
                    estado
                FROM Productos";

            conexion.CargarTabla(consulta, dgv);
        }

        public void CargarInventarioFiltrado(string estado, DataGridView dgv)
        {
            string consulta = @" 
                SELECT 
                    nombre,
                    costo,
                    precio_venta,
                    stock,
                    estado
                FROM Productos
                WHERE (@estado = 'Todos' 
                OR (@estado = 'Activo' AND estado = 'Activo')
                OR (@estado = 'Inactivo' AND estado = 'Inactivo')
                OR (@estado = 'Sin stock' AND estado = 'Sin stock'))";

            SqlParameter[] parametros =
            {
                new SqlParameter("@estado", estado)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public void ListarReportesMembresias(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    m.nombre as Membresia_Nombre,
                    c.nombre as Nombre,
                    c.apellido,
                    cm.fecha_inicio,
                    m.activo,
                    m.precio
                FROM Membresias m
                Join Cliente_Membresias cm on m.id_membresias = cm.id_membresias
                Join Clientes c on cm.id_cliente = c.id_cliente";

            conexion.CargarTabla(consulta, dgv);
        }

        public void BuscarMembresiasPorFechas(DateTime fechaInicial, DateTime fechaFinal ,DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    m.nombre as Membresia_Nombre,
                    c.nombre as Nombre,
                    c.apellido,
                    cm.fecha_inicio,
                    m.activo,
                    m.precio
                FROM Membresias m
                Join Cliente_Membresias cm on m.id_membresias = cm.id_membresias
                Join Clientes c on cm.id_cliente = c.id_cliente
                WHERE fecha_inicio >= @fechaInicial AND fecha_inicio < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            }; 

            

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public decimal CargarTotalPrecioMembresias()
        {
            string consulta = @"
                SELECT SUM(m.precio) 
                FROM Membresias m
                JOIN Cliente_Membresias cm ON m.id_membresias = cm.id_membresias";

            object resultado = conexion.ObtenerValor(consulta);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToDecimal(resultado);

            return 0;
        }

        public decimal CargarTotalPrecioMembresiasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            string consulta = @"
                SELECT SUM(m.precio) 
                FROM Membresias m
                JOIN Cliente_Membresias cm ON m.id_membresias = cm.id_membresias
                WHERE cm.fecha_inicio >= @fechaInicial AND cm.fecha_inicio < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            };

            object resultado = conexion.ObtenerValor(consulta, parametros);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToDecimal(resultado);

            return 0;
        }

        public void ListarReportesClientes(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    cod_cliente as Clave,
                    nombre as Nombre,
                    apellido as Apellido,
                    dni as DNI,
                    telefono as Telefono,
                    email as Email,
                    activo as Activo
                From Clientes";

            conexion.CargarTabla(consulta, dgv);
        }

        public void ListarReportesRegistros(DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    c.nombre,
                    c.apellido,
                    r.ingreso
                From Clientes c
                Join Registros r on c.id_cliente = r.id_cliente";

            conexion.CargarTabla(consulta, dgv);
        }

        public void BuscarRegistrosPorFechas(DateTime fechaInicial, DateTime fechaFinal, DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    c.nombre,
                    c.apellido,
                    r.ingreso
                From Clientes c
                Join Registros r on c.id_cliente = r.id_cliente
                WHERE r.ingreso >= @fechaInicial AND r.ingreso < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            }; 

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public void ListarReportesVentas(DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    o.fecha,
                    p.nombre,
                    p.costo,
                    p.precio_venta,
                    ganancia = (p.precio_venta - p.costo)
                From Operaciones o
                Join Detalle_Operacion do on o.id_operacion = do.id_operacion
                Join Productos p on do.id_producto = p.id_producto";
            conexion.CargarTabla(consulta, dgv);
        }

        public void BuscarVentasPorFechas(DateTime fechaInicial, DateTime fechaFinal, DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    o.fecha,
                    p.nombre,
                    p.costo,
                    p.precio_venta,
                    ganancia = (p.precio_venta - p.costo)
                From Operaciones o
                Join Detalle_Operacion do on o.id_operacion = do.id_operacion
                Join Productos p on do.id_producto = p.id_producto
                Where o.fecha >= @fechaInicial AND o.fecha < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public decimal CargarTotalPrecioVentas()
        {
            string consulta = @"
            SELECT SUM(p.precio_venta - p.costo)
            From Operaciones o
            Join Detalle_Operacion do on o.id_operacion = do.id_operacion
            Join Productos p on do.id_producto = p.id_producto";

            object resultado = conexion.ObtenerValor(consulta);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToDecimal(resultado);

            return 0;
        }

        public decimal CargarTotalPrecioVentasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            string consulta = @"
            SELECT SUM(p.precio_venta - p.costo)
            From Operaciones o
            Join Detalle_Operacion do on o.id_operacion = do.id_operacion
            Join Productos p on do.id_producto = p.id_producto
            Where o.fecha >= @fechaInicial AND o.fecha < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            };

            object resultado = conexion.ObtenerValor(consulta, parametros);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToDecimal(resultado);

            return 0;
        }

        public void ListarReportesMovimientos(DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    m.fecha_creacion,
                    c.nombre,
                    c.tipo,
                    m.monto,
                    m.tipo_movimiento,
                    u.usuario,
                    m.observaciones
                From Movimiento_Caja m
                Join Conceptos c on m.id_concepto = c.id_concepto
                Join Usuarios u on m.id_usuario = u.id_usuario
                    ";

            conexion.CargarTabla(consulta, dgv);
        }

        public void BuscarMovimientosPorFechas(DateTime fechaInicial, DateTime fechaFinal, DataGridView dgv)
        {
            string consulta = @"
                SELECT
                    m.fecha_creacion,
                    c.nombre,
                    c.tipo,
                    m.monto,
                    m.tipo_movimiento,
                    u.usuario,
                    m.observaciones
                From Movimiento_Caja m
                Join Conceptos c on m.id_concepto = c.id_concepto
                Join Usuarios u on m.id_usuario = u.id_usuario
                Where m.fecha_creacion >= @fechaInicial AND m.fecha_creacion < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public void CargarMovimientosFiltrados(string tipo, DataGridView dgv)
        {
            string consulta = @" 
                SELECT
                    m.fecha_creacion,
                    c.nombre,
                    c.tipo,
                    m.monto,
                    m.tipo_movimiento,
                    u.usuario,
                    m.observaciones
                From Movimiento_Caja m
                Join Conceptos c on m.id_concepto = c.id_concepto
                Join Usuarios u on m.id_usuario = u.id_usuario
                WHERE (@tipo = 'Todos' OR m.tipo_movimiento = @tipo)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@tipo", tipo)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public void ListarReportesVisitas(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    c.nombre,
                    c.apellido,
                    r.ingreso
                FROM Clientes c
                JOIN Registros r ON c.id_cliente = r.id_cliente
                JOIN Cliente_Membresias cm ON c.id_cliente = cm.id_cliente
                JOIN Membresias m ON cm.id_membresias = m.id_membresias
                WHERE m.tipo = 'Diario'";

            conexion.CargarTabla(consulta, dgv);
        }

        public void BuscarVisitasPorFechas(DateTime fechaInicial, DateTime fechaFinal, DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    c.nombre,
                    c.apellido,
                    r.ingreso
                FROM Clientes c
                JOIN Registros r ON c.id_cliente = r.id_cliente
                JOIN Cliente_Membresias cm ON c.id_cliente = cm.id_cliente
                JOIN Membresias m ON cm.id_membresias = m.id_membresias
                WHERE m.tipo = 'Diario' AND r.ingreso >= @fechaInicial AND r.ingreso < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            };

            conexion.CargarTabla(consulta, dgv, parametros);
        }

        public decimal CargarTotalPrecioVisitas()
        {
            string consulta = @"
            SELECT SUM(cm.precio_congelado)
            FROM Cliente_Membresias cm
            JOIN Membresias m 
            ON cm.id_membresias = m.id_membresias
            WHERE m.tipo = 'Diario'";

            object resultado = conexion.ObtenerValor(consulta);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToDecimal(resultado);

            return 0;
        }

        public decimal CargarTotalPrecioVisitasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            string consulta = @"
            SELECT SUM(cm.precio_congelado)
            FROM Cliente_Membresias cm
            JOIN Membresias m 
            ON cm.id_membresias = m.id_membresias
            WHERE m.tipo = 'Diario' AND cm.fecha_inicio >= @fechaInicial AND cm.fecha_inicio < @fechaFinal";

            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaInicial", fechaInicial),
                new SqlParameter("@fechaFinal", fechaFinal)
            };

            object resultado = conexion.ObtenerValor(consulta, parametros);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToDecimal(resultado);

            return 0;
        }
    }
}
