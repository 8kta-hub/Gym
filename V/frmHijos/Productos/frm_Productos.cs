using Gym.V.frmHijos.Ventas;
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

namespace Gym.V.frmHijos.Productos
{
    public partial class frm_Productos : Form
    {
        public frm_Productos()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos_Nuevo frm = new frm_Productos_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos_Nuevo frm = new frm_Productos_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
