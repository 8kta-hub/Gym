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

namespace Gym.V.frmHijos.Conceptos
{
    public partial class frm_Conceptos : Form
    {
        public frm_Conceptos()
        {
            InitializeComponent();
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
