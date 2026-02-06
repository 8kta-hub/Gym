using Gym.V.frmHijos.Compras;
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
    public partial class frm_Clientes_Membresias : Form
    {
        public frm_Clientes_Membresias()
        {
            InitializeComponent();
        }

        private void btn_Pagar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            frm_Clientes_Membresias_Pago frm = new frm_Clientes_Membresias_Pago();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
