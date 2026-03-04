using Gym.M;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.C
{
    internal class ControladorMovimientos
    {
        private ConDB conexion = new ConDB();

        public void ListarMovimientos(DataGridView dgv)
        {
            string consulta = @"
                Select 
                    m.fecha_creacion,
                    c.id_concepto,
                    c.nombre, 
                    m.tipo_movimiento,
                    m.monto, 
                    m.tipo_pago,
                    u.id_usuario,
                    u.usuario, 
                    m.observaciones 
                    From Movimiento_Caja m 
                    Inner Join Conceptos c on m.id_concepto = c.id_concepto 
                    Inner Join Usuarios u on m.id_usuario = u.id_usuario;
            ";

            conexion.CargarTabla(consulta, dgv);
        }

        public bool InsertMovimiento(int idUsuario, int idConcepto,
                             string tipoMovimiento, string tipoPago,
                             decimal monto, string observaciones)
        {
            string sql = @"
                INSERT INTO Movimiento_Caja
                    (id_usuario, id_concepto, tipo_movimiento, tipo_pago, fecha_creacion, monto, observaciones)
                VALUES
                    (@id_usuario, @id_concepto, @tipo_movimiento, @tipo_pago, GETDATE(), @monto, @observaciones)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_usuario", idUsuario),
                new SqlParameter("@id_concepto", idConcepto),
                new SqlParameter("@tipo_movimiento", tipoMovimiento),
                new SqlParameter("@tipo_pago", tipoPago),
                new SqlParameter("@monto", monto),
                new SqlParameter("@observaciones", observaciones)
    };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        public bool UpdateMovimiento(int idMovimiento,int idUsuario,
                             int idConcepto,string tipoMovimiento,
                             string tipoPago,decimal monto,string observaciones)
        {
            string sql = @"
                UPDATE Movimiento_Caja
                SET    id_usuario = @id_usuario,
                       id_concepto = @id_concepto,
                       tipo_movimiento = @tipo_movimiento,
                       tipo_pago = @tipo_pago,
                       monto = @monto,
                       observaciones = @observaciones
                WHERE  id_movimiento_caja = @id_movimiento";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id_usuario", idUsuario),
                new SqlParameter("@id_concepto", idConcepto),
                new SqlParameter("@tipo_movimiento", tipoMovimiento),
                new SqlParameter("@tipo_pago", tipoPago),
                new SqlParameter("@monto", monto),
                new SqlParameter("@observaciones", observaciones),
                new SqlParameter("@id_movimiento", idMovimiento)
            };

            int filas = conexion.EjecutarComando(sql, parametros);
            return filas > 0;
        }

        public int ObtenerIdUsuarioPorNombre(string nombreUsuario)
        {
            string sql = "SELECT id_usuario FROM Usuarios WHERE usuario = @usuario";

            SqlParameter[] parametros =
            {
        new SqlParameter("@usuario", nombreUsuario)
    };

            object resultado = conexion.ObtenerValor(sql, parametros);

            if (resultado != null)
                return Convert.ToInt32(resultado);
            else
                return 0; // o lanzar excepción
        }

        public void CargarConceptosEnCombo(ComboBox cmb, string tipo = null)
        {
            string consulta = @"
            SELECT id_concepto, nombre
            FROM Conceptos
            WHERE activo = 1";

            if (!string.IsNullOrEmpty(tipo))
                consulta += $" AND tipo = '{tipo}'";

            consulta += " ORDER BY nombre";

            DataTable dt = conexion.ObtenerTabla(consulta);

            cmb.DataSource = dt;
            cmb.DisplayMember = "nombre";
            cmb.ValueMember = "id_concepto";
            cmb.SelectedIndex = -1;
        }
    }
}
