using Gym.C;
using Gym.V.FuncionesV;
using System;
using System.Data;
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
        }

        private void frm_Clientes_Load(object sender, EventArgs e)
        {

            CargarClientes();
            CargarFiltro();
        }

        private void btn_Nuevo_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes_Nuevo frm = new frm_Clientes_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
                CargarClientes();
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
                CargarClientes();
        }

        private void btn_Membresias_Clientes_Click(object sender, EventArgs e)
        {
            Cliente cliente = CargarClienteSeleccionado();

            if (cliente == null)
            {
                MessageBox.Show("Seleccione un cliente");
                return;
            }

            frm_Clientes_Membresias frm = new frm_Clientes_Membresias(cliente);

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
                CargarClientes();
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
                "¿Desea eliminar este cliente?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteClientes(cliente.IdCliente);

                if (resultado)
                {
                    MessageBox.Show("Cliente eliminado correctamente");
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente");
                }
            }
        }

        private void txt_Buscar_Clientes_TextChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void cbx_FiltroCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        // Devuelve null si no hay fila seleccionada o si la celda está vacía
        private Cliente CargarClienteSeleccionado()
        {
            if (dgv_Clientes.SelectedRows.Count == 0 ||
                dgv_Clientes.SelectedRows[0].Cells["id_cliente"].Value == null)
                return null;

            DataGridViewRow fila = dgv_Clientes.SelectedRows[0];

            return new Cliente
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
        }

        private void CargarFiltro()
        {
            cbx_FiltroCliente.Items.Add("Activo");
            cbx_FiltroCliente.Items.Add("Deudor");
            cbx_FiltroCliente.Items.Add("Inactivo");
            cbx_FiltroCliente.Items.Add("Todos");
            cbx_FiltroCliente.SelectedIndex = 0; // Activo por defecto
        }

        private void CargarClientes()
        {
            string busqueda = txt_Buscar_Clientes.Text.Trim();
            string filtro = cbx_FiltroCliente.SelectedItem?.ToString() ?? "Activo";

            controlador.ListarClientes(dgv_Clientes, busqueda, filtro);

            dgv_Clientes.Columns["id_cliente"].Visible = false;
            dgv_Clientes.ClearSelection();

            //lbl_resultadosCantidad_Clientes.Text = dgv_Clientes.Rows.Count + " resultados";
        }
    }
}