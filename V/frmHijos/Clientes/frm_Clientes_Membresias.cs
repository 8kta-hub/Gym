using Gym.C;
using Gym.M.Entidades;
using Gym.V.FuncionesV;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes_Membresias : Form
    {
        private ControladorClientes controladorClientes = new ControladorClientes();
        private ControladorMembresias controladorMembresias = new ControladorMembresias();
        private Cliente clienteActual;

        public frm_Clientes_Membresias(Cliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
        }

        private void frm_Clientes_Membresias_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
            CargarComboMembresias();
            CargarFiltro();
            CargarMembresiasDelCliente();
        }

        private void CargarDatosCliente()
        {
            lbl_Nombre_ClientesMembresias.Text = clienteActual.Nombre;
            lbl_Apellido_ClientesMembresias.Text = clienteActual.Apellido;
            lbl_Telefono_ClientesMembresias.Text = clienteActual.Telefono;
            lbl_DNI_ClientesMembresias.Text = clienteActual.Dni;
        }

        private void CargarComboMembresias()
        {
            var lista = controladorMembresias.ObtenerMembresiasActivas();
            cmb_Membresia_ClientesMembresias.DisplayMember = "Nombre";
            cmb_Membresia_ClientesMembresias.ValueMember = "IdMembresia";
            cmb_Membresia_ClientesMembresias.DataSource = lista;
            cmb_Membresia_ClientesMembresias.SelectedIndex = -1;
            LimpiarLabelsMembresia();
        }

        private void CargarFiltro()
        {
            cbx_filtro_ClientesMembresias.Items.Add("Activo");
            cbx_filtro_ClientesMembresias.Items.Add("Pendiente de pago");
            cbx_filtro_ClientesMembresias.Items.Add("Inactivo");
            cbx_filtro_ClientesMembresias.Items.Add("Todas");
            cbx_filtro_ClientesMembresias.SelectedIndex = 0; // Activo por defecto
        }

        private void cbx_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMembresiasDelCliente();
        }

        private void cmb_Membresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Membresia_ClientesMembresias.SelectedItem is Membresia m)
            {
                lbl_Precio_ClientesMembresias.Text = "$" + m.Precio.ToString("N2");

                int meses = 0, semanas = 0, dias = 0;
                switch (m.Tipo)
                {
                    case "Mensual": meses = m.CantidadMsd / 30; break;
                    case "Semanal": semanas = m.CantidadMsd / 7; break;
                    case "Diario": dias = m.CantidadMsd; break;
                }

                lbl_Meses_ClientesMembresias.Text = meses > 0 ? meses.ToString() : "-";
                lbl_Semanas_ClientesMembresias.Text = semanas > 0 ? semanas.ToString() : "-";
                lbl_Dias_ClientesMembresias.Text = dias > 0 ? dias.ToString() : "-";
            }
            else
            {
                LimpiarLabelsMembresia();
            }
        }

        private void LimpiarLabelsMembresia()
        {
            lbl_Precio_ClientesMembresias.Text = "$$$$$$";
            lbl_Meses_ClientesMembresias.Text = "######";
            lbl_Semanas_ClientesMembresias.Text = "######";
            lbl_Dias_ClientesMembresias.Text = "######";
        }


        private void btn_Agregar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            if (cmb_Membresia_ClientesMembresias.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una membresía", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var membresia = (Membresia)cmb_Membresia_ClientesMembresias.SelectedItem;

            bool resultado = controladorClientes.InsertClienteMembresia(
                clienteActual.IdCliente,
                membresia.IdMembresia,
                membresia.Precio
            );

            if (resultado)
            {
                MessageBox.Show("Membresía agregada, pendiente de pago", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetear el combo después de agregar
                cmb_Membresia_ClientesMembresias.SelectedIndex = -1;
                LimpiarLabelsMembresia();

                // Mostrar pendientes para que el usuario la vea
                cbx_filtro_ClientesMembresias.SelectedItem = "Pendiente de pago";
                CargarMembresiasDelCliente();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la membresía", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Pagar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            if (dgv_ClientesMembresias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una membresía del listado para pagar",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgv_ClientesMembresias.SelectedRows[0];
            string estado = fila.Cells["Estado"].Value.ToString();

            // Solo se pueden pagar membresías pendientes o inactivas
            if (estado != "Pendiente de pago" && estado != "Inactivo")
            {
                MessageBox.Show("Solo se pueden pagar membresías pendientes o inactivas",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idClienteMembresia = Convert.ToInt32(fila.Cells["id_cliente_membresias"].Value);
            int idMembresia = Convert.ToInt32(fila.Cells["id_membresias"].Value);

            var membresia = controladorMembresias.ObtenerMembresiaPorId(idMembresia);

            if (membresia == null)
            {
                MessageBox.Show("No se pudo obtener la membresía", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm_Clientes_Membresias_Pago frmPago = new frm_Clientes_Membresias_Pago(
                clienteActual,
                membresia,
                idClienteMembresia
            );

            DialogResult resultado = Funciones.abrirFormModal(frmPago, this);

            if (resultado == DialogResult.OK)
            {
                cbx_filtro_ClientesMembresias.SelectedIndex = 0; // volver a Activo
                CargarMembresiasDelCliente();
            }
        }

        private void btn_Eliminar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            if (dgv_ClientesMembresias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una membresía a eliminar");
                return;
            }

            string estado = dgv_ClientesMembresias.SelectedRows[0].Cells["Estado"].Value.ToString();

            // Una membresía pagada no se puede eliminar
            if (estado == "Activo")
            {
                MessageBox.Show("No se puede eliminar una membresía activa y paga",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Desea eliminar esta membresía del cliente?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int idClienteMembresia = Convert.ToInt32(
                    dgv_ClientesMembresias.SelectedRows[0].Cells["id_cliente_membresias"].Value);

                bool resultado = controladorClientes.DeleteClienteMembresia(idClienteMembresia);

                if (resultado)
                {
                    MessageBox.Show("Membresía eliminada correctamente");
                    cmb_Membresia_ClientesMembresias.SelectedIndex = -1;
                    LimpiarLabelsMembresia();
                    CargarMembresiasDelCliente();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la membresía");
                }
            }
        }

        private void CargarMembresiasDelCliente()
        {
            string filtro = cbx_filtro_ClientesMembresias.SelectedItem?.ToString() ?? "Activo";

            controladorClientes.ListarMembresiasDeCliente(
                clienteActual.IdCliente, dgv_ClientesMembresias, filtro);

            dgv_ClientesMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ClientesMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ClientesMembresias.MultiSelect = false;
            dgv_ClientesMembresias.ReadOnly = true;

            if (dgv_ClientesMembresias.Columns.Contains("id_cliente_membresias"))
                dgv_ClientesMembresias.Columns["id_cliente_membresias"].Visible = false;
            if (dgv_ClientesMembresias.Columns.Contains("id_cliente"))
                dgv_ClientesMembresias.Columns["id_cliente"].Visible = false;
            if (dgv_ClientesMembresias.Columns.Contains("id_membresias"))
                dgv_ClientesMembresias.Columns["id_membresias"].Visible = false;
        }
    }
}