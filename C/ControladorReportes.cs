using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.M;
using System.Windows.Forms;

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
                    stock
                FROM Productos";

            conexion.CargarTabla(consulta, dgv);
        }

        public void ListarReportesMembresias(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    m.nombre as Membresia_Nombre,
                    c.nombre as Nombre,
                    c.apellido,
                    m.fecha_creacion,
                    m.fecha_vec,
                    m.activo,
                    m.precio
                FROM Membresias m
                Join Cliente_Membresias cm on m.id_membresias = cm.id_membresias
                Join Clientes c on cm.id_cliente = c.id_cliente";

            conexion.CargarTabla(consulta, dgv);
        }

        public void ListarReportesClientes(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    c.id_cliente as Identificador,
                    c.cod_cliente as Clave,
                    c.nombre,
                    c.apellido,
                    m.fecha_vec,
                    c.activo
                From Clientes c
                Join Cliente_Membresias cm on c.id_cliente = cm.id_cliente
                Join Membresias m on cm.id_membresias = m.id_membresias";

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
                Join Productos p on do.id_producto = p.id_producto
                    ";

            conexion.CargarTabla(consulta, dgv);
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

        public void ListarReportesVisitas(DataGridView dgv)
        {
            string consulta = @"
                SELECT 
                    nombre,
                    apellido
                From Clientes
                where cod_cliente = 7777";

            conexion.CargarTabla(consulta, dgv);
        }
    }
}
