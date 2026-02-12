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

namespace Gym.V.frmHijos.Roles
{
    public partial class frm_Roles : Form
    {
        string query = "Select nombre, permiso, descripcion, activo From Roles";
        ConDB consultaSql = new ConDB();
        public frm_Roles()
        {
            InitializeComponent();
        }

        private void frm_Roles_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Roles);
        }

        private void btn_Nuevo_Roles_Click(object sender, EventArgs e)
        {
            frm_Roles_Nuevo frm = new frm_Roles_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Roles_Click(object sender, EventArgs e)
        {
            frm_Roles_Nuevo frm = new frm_Roles_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
