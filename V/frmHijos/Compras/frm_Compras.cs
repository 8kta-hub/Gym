using Gym.V.frmHijos.Conceptos;
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

namespace Gym.V.frmHijos.Compras
{
    public partial class frm_Compras : Form
    {
        public frm_Compras()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Compras_Click(object sender, EventArgs e)
        {
            frm_Compras_Nuevo frm = new frm_Compras_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Detalle_Compras_Click(object sender, EventArgs e)
        {

        }
    }
}
