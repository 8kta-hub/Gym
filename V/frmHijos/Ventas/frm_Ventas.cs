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
using Gym.C;

namespace Gym.V.frmHijos.Ventas
{
    public partial class frm_Ventas : Form
    {
        ControladorVentas controlador = new ControladorVentas();
        public frm_Ventas()
        {
            InitializeComponent();
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            CargarVentas();
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

        private void CargarVentas()
        {
            controlador.ListarVentas(dgv_Ventas);
            dgv_Ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Ventas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Ventas.MultiSelect = false;
            dgv_Ventas.ReadOnly = true;
        }
    }
}
