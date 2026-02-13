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
using Gym.C;

namespace Gym.V.frmHijos.Productos
{
    public partial class frm_Productos : Form
    {
        ControladorProductos controlador = new ControladorProductos();
        public frm_Productos()
        {
            InitializeComponent();
        }

        private void frm_Productos_Load(object sender, EventArgs e)
        {
            CargarProductos();
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

        private void CargarProductos()
        {
            controlador.ListarProductos(dgv_Productos);
            dgv_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Productos.MultiSelect = false;
            dgv_Productos.ReadOnly = true;
        }
    }
}
