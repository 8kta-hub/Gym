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
using Gym.C;

namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes : Form
    {
        ControladorClientes controlador = new ControladorClientes();
        public frm_Clientes()
        {
            InitializeComponent();
            this.Load += frm_Clientes_Load;
        }

        private void frm_Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btn_Nuevo_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Nuevo frm = new frm_Clientes_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btn_Modificar_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Nuevo frm = new frm_Clientes_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void btn_Membresias_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Membresias frm = new frm_Clientes_Membresias();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
            controlador.ListarClientes(dgv_Clientes);

            dgv_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Clientes.MultiSelect = false;
            dgv_Clientes.ReadOnly = true;

            dgv_Clientes.Columns["id_cliente"].Visible = false;
        }


    }
}
