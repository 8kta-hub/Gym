using Gym.V.frmHijos.Usuarios;
using Gym.V.FuncionesV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.M;

namespace Gym.V.frmHijos.Corte
{
    public partial class frm_Corte : Form
    {
        string query = "Select c.inicio_fecha_hora, c.fin_fecha_hora, c.total_sistema, c.total_real, c.diferencia, u.usuario, c.observacion, c.estado From Corte_Caja c Join Usuarios u on c.id_usuario = u.id_usuario;";
        ConDB consultaSql = new ConDB();
        public frm_Corte()
        {
            InitializeComponent();
        }

        private void frm_Corte_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Corte);
        }

        private void btn_Nuevo_Corte_Click(object sender, EventArgs e)
        {
            frm_Corte_Nuevo frm = new frm_Corte_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Detalle_Corte_Click(object sender, EventArgs e)
        {

        }
    }
}
