using Gym.V.frmHijos.Movimientos;
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

namespace Gym.V.frmHijos
{
    public partial class frm_membresias : Form
    {
        public frm_membresias()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Nuevo frm = new frm_Membresias_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Nuevo frm = new frm_Membresias_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Horarios_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Horarios frm = new frm_Membresias_Horarios();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
