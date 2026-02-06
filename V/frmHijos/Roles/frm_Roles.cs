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

namespace Gym.V.frmHijos.Roles
{
    public partial class frm_Roles : Form
    {
        public frm_Roles()
        {
            InitializeComponent();
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
