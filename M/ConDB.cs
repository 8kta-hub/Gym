using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Gym.M
{
    public class ConDB
    {
        public static string strcnn = "Data Source = DESKTOP-2UJD34U\\SQLEXPRESS; Initial Catalog = Gimnasio; Integrated Security = True;";
        //public static string strcnn = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Gimnasio; Integrated Security = True;";

        //Método SELECT
        public void CargarTabla(string consulta, DataGridView dgv)
        {
            using (SqlConnection cnn = new SqlConnection(strcnn))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);

                SqlDataReader lector = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                dgv.DataSource = dt;
            }
        }

        // Método SELECT con parámetros
        public void CargarTabla(string consulta, DataGridView dgv, SqlParameter[] parametros)
        {
            using (SqlConnection cnn = new SqlConnection(strcnn))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);
                command.Parameters.AddRange(parametros);
                SqlDataReader lector = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                dgv.DataSource = dt;
            }
        }

        //Método INSERT, UPDATE, DELETE
        public int EjecutarComando(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection cn = new SqlConnection(strcnn))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(consulta, cn);

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
