using Gym.V.frmHijos.Corte;
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

namespace Gym.V.frmHijos.Conceptos
{
    public partial class frm_Conceptos : Form
    {
        string query = "Select nombre, tipo, estado, fecha_creacion, modificable From Conceptos";
        ConDB consultaSql = new ConDB();
        public frm_Conceptos()
        {
            InitializeComponent();
        }

        private void frm_Conceptos_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Conceptos);
        }

        private void btn_Nuevo_Conceptos_Click(object sender, EventArgs e)
        {
            frm_Conceptos_Nuevo frm = new frm_Conceptos_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Conceptos_Click(object sender, EventArgs e)
        {
            frm_Conceptos_Nuevo frm = new frm_Conceptos_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
