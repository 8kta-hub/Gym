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

namespace Gym.V.frmHijos
{
    public partial class frm_Usuarios : Form
    {
        public frm_Usuarios()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios_Nuevo userNuevo = new frm_Usuarios_Nuevo();
            userNuevo.ShowDialog();
        }
    }
}
