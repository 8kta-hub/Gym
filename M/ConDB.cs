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
        public static string strcnn = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Gimnasio; Integrated Security = True;";

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

        // Método SELECT que devuelve un DataTable en vez de llenар un DataGridView
        // Se usa cuando el destino de los datos no es un grid sino un combo u otra estructura
        public DataTable ObtenerTabla(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection cnn = new SqlConnection(strcnn))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);

                if (parametros != null)
                    command.Parameters.AddRange(parametros);

                SqlDataReader lector = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                return dt;
            }
        }

        //Trae unicamente un valor
        public object ObtenerValor(string consulta, SqlParameter[] parametros = null)
        {
            using (SqlConnection cnn = new SqlConnection(strcnn))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(consulta, cnn);

                if (parametros != null)
                    command.Parameters.AddRange(parametros);

                return command.ExecuteScalar();
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
