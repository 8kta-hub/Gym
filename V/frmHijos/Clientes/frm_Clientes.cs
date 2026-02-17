using Gym.C;
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
using Gym.M.Entidades;

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
            Cliente cliente = CargarClienteSeleccionado();

            if (cliente == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            frm_Clientes_Nuevo frm = new frm_Clientes_Nuevo(cliente);

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

        private void btn_Eliminar_Clientes_Click(object sender, EventArgs e)
        {
            Cliente cliente = CargarClienteSeleccionado();

            if (cliente == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea Eliminar este cliente?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteClientes(cliente.IdCliente);

                if (resultado)
                {
                    MessageBox.Show("Cliente Eliminado correctamente");
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente");
                }
            }
        }

        private Cliente CargarClienteSeleccionado()
        {
            if (dgv_Clientes.SelectedRows.Count == 0)
                return null;

            DataGridViewRow fila = dgv_Clientes.SelectedRows[0];

            Cliente cliente = new Cliente
            {
                IdCliente = Convert.ToInt32(fila.Cells["id_cliente"].Value),
                CodCliente = Convert.ToInt32(fila.Cells["cod_cliente"].Value),
                Nombre = fila.Cells["nombre"].Value.ToString(),
                Apellido = fila.Cells["apellido"].Value.ToString(),
                Dni = fila.Cells["dni"].Value.ToString(),
                Telefono = fila.Cells["telefono"].Value.ToString(),
                Email = fila.Cells["email"].Value.ToString(),
                Activo = Convert.ToBoolean(fila.Cells["activo"].Value),
                FechaNac = Convert.ToDateTime(fila.Cells["fecha_nac"].Value)
            };

            return cliente;
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

        private void dgv_Clientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Clientes.ClearSelection();
        }
    }
}
