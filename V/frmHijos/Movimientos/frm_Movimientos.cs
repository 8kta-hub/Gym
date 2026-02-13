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
using Gym.C;

namespace Gym.V.frmHijos.Movimientos
{
    public partial class frm_Movimientos : Form
    {
        ControladorMovimientos controlador = new ControladorMovimientos();
        public frm_Movimientos()
        {
            InitializeComponent();
        }

        private void frm_Movimientos_Load(object sender, EventArgs e)
        {
            CargarMovimientos();
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

        private void CargarMovimientos()
        {
            controlador.ListarMovimientos(dgv_Movimientos);
            dgv_Movimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Movimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Movimientos.MultiSelect = false;
            dgv_Movimientos.ReadOnly = true;
        }
    }
}
