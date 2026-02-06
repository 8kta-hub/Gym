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

namespace Gym.V.frmHijos.Corte
{
    public partial class frm_Corte : Form
    {
        public frm_Corte()
        {
            InitializeComponent();
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
