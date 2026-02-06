using Gym.V.frmHijos.Productos;
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

namespace Gym.V.frmHijos.Movimientos
{
    public partial class frm_Movimientos : Form
    {
        public frm_Movimientos()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos_Nuevos frm = new frm_Movimientos_Nuevos();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos_Nuevos frm = new frm_Movimientos_Nuevos();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
