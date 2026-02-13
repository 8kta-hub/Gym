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
using Gym.C;

namespace Gym.V.frmHijos.Roles
{
    public partial class frm_Roles : Form
    {
        ControladorRoles controlador = new ControladorRoles();
        public frm_Roles()
        {
            InitializeComponent();
        }

        private void frm_Roles_Load(object sender, EventArgs e)
        {
            CargarRoles();
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

        private void CargarRoles()
        {
            controlador.ListarRoles(dgv_Roles);
            dgv_Roles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Roles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Roles.MultiSelect = false;
            dgv_Roles.ReadOnly = true;
        }
    }
}
