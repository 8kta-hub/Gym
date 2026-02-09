using Gym.V.frmHijos.Roles;
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

namespace Gym.V.frmHijos.Ventas
{
    public partial class frm_Ventas : Form
    {
        public frm_Ventas()
        {
            InitializeComponent();
        }

        private void btn_Nuevo_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas_Nuevo frm = new frm_Ventas_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Detalle_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas_Detalle VentasDetalle = new frm_Ventas_Detalle();
            Funciones.abrirFormModal(VentasDetalle, this);
        }
    }
}
