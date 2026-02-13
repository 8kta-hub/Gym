using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.V.frmHijos.Usuarios;
using Gym.V.FuncionesV;
using Gym.C;

namespace Gym.V.frmHijos
{
    public partial class frm_Usuarios : Form
    {
        ControladorUsuarios controlador = new ControladorUsuarios();
        public frm_Usuarios()
        {
            InitializeComponent();
        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btn_Nuevo_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios_Nuevo frm = new frm_Usuarios_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificiar_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios_Nuevo frm = new frm_Usuarios_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Roles_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios_Roles frm = new frm_Usuarios_Roles();
            Funciones.abrirFormModal(frm, this);
        }

        private void CargarUsuarios()
        {
            controlador.ListarUsuarios(dgv_Usuarios);
            dgv_Usuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Usuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Usuarios.MultiSelect = false;
            dgv_Usuarios.ReadOnly = true;
        }
    }
}
