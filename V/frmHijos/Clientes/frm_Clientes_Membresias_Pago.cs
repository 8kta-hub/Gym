using Gym.C;
using Gym.M.Entidades;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes_Membresias_Pago : Form
    {
        private ControladorVentas controladorVentas = new ControladorVentas();
        private ControladorClientes controladorClientes = new ControladorClientes();

        private Cliente clienteActual;
        private Membresia membresiaActual;
        private int idClienteMembresia; // para actualizar fechas al confirmar el pago

        public frm_Clientes_Membresias_Pago(Cliente cliente, Membresia membresia, int idClienteMembresia)
        {
            InitializeComponent();
            clienteActual = cliente;
            membresiaActual = membresia;
            this.idClienteMembresia = idClienteMembresia;
        }

        private void frm_Clientes_Membresias_Pago_Load(object sender, EventArgs e)
        {
            // fecha de inicio = hoy, porque se paga en este momento
            DateTime inicio = DateTime.Today;

            lbl_Precio_ClientesMembresiasPagos.Text = "$" + membresiaActual.Precio.ToString("N2");


            lbl_Total_ClientesMembresiasPagos.Text = "-";
            lbl_Total_ClientesMembresiasPagos.Visible = false;
            label3.Visible = false; 

            lbl_Fecha_ClientesMembresiasPagos.Text = inicio.ToString("dd/MM/yyyy");
            lbl_EstadoMembresia_ClientesMembresiasPagos.Text = "Pendiente de pago";
            lbl_EstadoMembresia_ClientesMembresiasPagos.ForeColor = System.Drawing.Color.OrangeRed;

            txt_Importe_ClientesMembresiasPagos.Text = membresiaActual.Precio.ToString("N2");

            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Efectivo");
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Tarjeta de débito");
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Tarjeta de crédito");
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Transferencia");
            cmb_TipoDePago_ClientesMembresiasPagos.SelectedIndex = 0;

            CargarHistorialPagos();
        }


        // Ejecuta los 3 pasos: operación → pago → asignación membresía
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_TipoDePago_ClientesMembresiasPagos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un tipo de pago", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string metodo = cmb_TipoDePago_ClientesMembresiasPagos.SelectedItem.ToString();
                string observacion = txt_Observacion_ClientesMembresiasPagos.Text.Trim();
                decimal total = membresiaActual.Precio;

                // Paso 1: crear la operación, el folio lo genera SQL automáticamente
                int idOperacion = controladorVentas.InsertOperacion(
                    clienteActual.IdCliente,
                    total
                );

                if (idOperacion <= 0)
                {
                    MessageBox.Show("No se pudo crear la operación", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Paso 2: registrar el pago con método y observación
                bool pagoOk = controladorVentas.InsertPago(
                    idOperacion, total, metodo, observacion);

                if (!pagoOk)
                {
                    MessageBox.Show("No se pudo registrar el pago", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Paso 3: actualizar fechas y estado de la membresía a Activo
                bool membresiaOk = controladorClientes.ConfirmarPagoMembresia(
                    idClienteMembresia,
                    DateTime.Today,
                    membresiaActual.CantidadMsd
                );

                if (!membresiaOk)
                {
                    MessageBox.Show("No se pudo confirmar la membresía", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!membresiaOk)
                {
                    MessageBox.Show("No se pudo asignar la membresía", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener el folio 
                string folio = controladorVentas.ObtenerFolio(idOperacion);

                // Actualizar estado de la membresía en el label
                lbl_EstadoMembresia_ClientesMembresiasPagos.Text = "Pagado";
                lbl_EstadoMembresia_ClientesMembresiasPagos.ForeColor = System.Drawing.Color.ForestGreen;

                // Deshabilitar el botón para evitar doble pago
                btn_Agregar__ClientesMembresiasPagos.Enabled = false;

                MessageBox.Show(
                    $"Pago registrado correctamente\nFolio: {folio}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mostrar el total una vez confirmado el pago
                lbl_Total_ClientesMembresiasPagos.Text = "$" + txt_Importe_ClientesMembresiasPagos.Text;
                lbl_Total_ClientesMembresiasPagos.Visible = true;
                label3.Visible = true;

                // Refrescar el historial con el pago recién agregado
                CargarHistorialPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── BOTÓN ELIMINAR PAGO ───────────────────────────────────────────────
        // Anula el pago seleccionado en el grid (baja lógica)
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv__ClientesMembresiasPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un pago a eliminar");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Desea anular este pago?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int idPago = Convert.ToInt32(
                    dgv__ClientesMembresiasPagos.SelectedRows[0].Cells["id_pago"].Value);

                bool resultado = controladorVentas.AnularPago(idPago);

                if (resultado)
                {
                    MessageBox.Show("Pago anulado correctamente");
                    CargarHistorialPagos();
                }
                else
                {
                    MessageBox.Show("No se pudo anular el pago");
                }
            }
        }

        // ── BOTÓN REIMPRIMIR ──────────────────────────────────────────────────
        // Muestra el folio del pago seleccionado en el grid
        private void btn_Reimprimir_Click(object sender, EventArgs e)
        {
            if (dgv__ClientesMembresiasPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un pago para reimprimir");
                return;
            }

            string folio = dgv__ClientesMembresiasPagos
                .SelectedRows[0].Cells["folio"].Value.ToString();

            // Por ahora muestra el folio, acá se puede conectar una impresora después
            MessageBox.Show(
                $"Folio: {folio}",
                "Reimprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── CARGAR HISTORIAL DE PAGOS ─────────────────────────────────────────
        // Muestra todos los pagos del cliente en el dgv
        private void CargarHistorialPagos()
        {
            // Usa idClienteMembresia en lugar de idCliente
            controladorVentas.ListarPagosPorMembresia(
                idClienteMembresia, dgv__ClientesMembresiasPagos);

            dgv__ClientesMembresiasPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv__ClientesMembresiasPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv__ClientesMembresiasPagos.MultiSelect = false;
            dgv__ClientesMembresiasPagos.ReadOnly = true;

            if (dgv__ClientesMembresiasPagos.Columns.Contains("id_pago"))
                dgv__ClientesMembresiasPagos.Columns["id_pago"].Visible = false;
            if (dgv__ClientesMembresiasPagos.Columns.Contains("id_operacion"))
                dgv__ClientesMembresiasPagos.Columns["id_operacion"].Visible = false;
        }
    }
}