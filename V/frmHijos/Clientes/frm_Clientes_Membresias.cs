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
using Gym.M.Entidades;

namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes_Membresias : Form
    {
        private Cliente clienteActual;
        public frm_Clientes_Membresias(Cliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
        }
        private void frm_Clientes_Membresias_Load(object sender, EventArgs e)
        {
            CargarDatosEnControles(clienteActual);
        }

        private void btn_Pagar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            frm_Clientes_Membresias_Pago frm = new frm_Clientes_Membresias_Pago();
            Funciones.abrirFormModal(frm, this);
        }
       
        private void CargarDatosEnControles(Cliente cliente)
        {
            lbl_Nombre_ClientesMembresias.Text = cliente.Nombre;
            lbl_Apellido_ClientesMembresias.Text = cliente.Apellido;
            lbl_DNI_ClientesMembresias.Text = cliente.Dni;
            lbl_Telefono_ClientesMembresias.Text = cliente.Telefono;
        }
    }
}
