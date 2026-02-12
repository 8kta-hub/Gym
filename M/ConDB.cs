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
        public static string strcnn = "Data Source = DESKTOP-2UJD34U\\SQLEXPRESS; Initial Catalog = gim_db; Integrated Security = True;";
        //public static string strcnn = "Data Source = OKTY; Initial Catalog = gim_db; Integrated Security = True;";


        public void CargarTabla(string consulta, DataGridView dgv)
        {
            using(SqlConnection cnn = new SqlConnection(strcnn))
            {
                SqlCommand command = new SqlCommand(consulta, cnn);
                SqlDataReader lector = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(lector);
                dgv.DataSource = dt;
            }
        }
    }
}
