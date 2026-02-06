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

namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes : Form
    {
        public frm_Clientes()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Nuevo frm = new frm_Clientes_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Nuevo frm = new frm_Clientes_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Membresias_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Membresias frm = new frm_Clientes_Membresias();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
