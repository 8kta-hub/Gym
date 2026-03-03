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
            // fecha de inicio es de hoy porque se paga en este momento
            DateTime inicio = DateTime.Today;
            CargarTiposDePago();
            CargarHistorialPagos();

            lbl_Precio_ClientesMembresiasPagos.Text = "$" + membresiaActual.Precio.ToString("N2");


            lbl_Total_ClientesMembresiasPagos.Text = "-";
            lbl_Total_ClientesMembresiasPagos.Visible = false;
            label3.Visible = false; 

            lbl_Fecha_ClientesMembresiasPagos.Text = inicio.ToString("dd/MM/yyyy");
            lbl_EstadoMembresia_ClientesMembresiasPagos.Text = "Pendiente de pago";
            lbl_EstadoMembresia_ClientesMembresiasPagos.ForeColor = System.Drawing.Color.OrangeRed;

            lbl_Vuelto_ClientesMembresiasPagos.Visible = false;
            label5.Visible = false;

        }


        // Ejecuta los 3 pasos: operación → pago → asignación membresía
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación: método de pago seleccionado
                if (cmb_TipoDePago_ClientesMembresiasPagos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un tipo de pago", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación: importe debe ser un número válido
                if (!decimal.TryParse(txt_Importe_ClientesMembresiasPagos.Text, out decimal importe))
                {
                    MessageBox.Show("El importe ingresado no es válido", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validación: importe debe ser mayor o igual al precio
                if (importe < membresiaActual.Precio)
                {
                    MessageBox.Show(
                        $"El importe debe ser mayor o igual al precio de la membresía (${membresiaActual.Precio:N2})",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string metodo = cmb_TipoDePago_ClientesMembresiasPagos.SelectedItem.ToString();
                string observacion = txt_Observacion_ClientesMembresiasPagos.Text.Trim();
                decimal total = membresiaActual.Precio;
                decimal vuelto = metodo == "Efectivo" ? importe - total : 0;

                // Confirmación antes de procesar
                string mensajeConfirmacion = metodo == "Efectivo"
                    ? $"Membresía: {membresiaActual.Nombre}\nTotal: ${total:N2}\nImporte recibido: ${importe:N2}\nVuelto: ${vuelto:N2}\nMétodo: {metodo}\n\n¿Confirmar pago?"
                    : $"Membresía: {membresiaActual.Nombre}\nTotal: ${total:N2}\nMétodo: {metodo}\n\n¿Confirmar pago?";

                var confirmacion = MessageBox.Show(mensajeConfirmacion, "Confirmar pago",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) return;

                // Paso 1: crear la operación
                int idOperacion = controladorVentas.InsertOperacion(clienteActual.IdCliente, total);

                if (idOperacion <= 0)
                {
                    MessageBox.Show("No se pudo crear la operación", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Paso 2: registrar el pago
                bool pagoOk = controladorVentas.InsertPago(idOperacion, total, metodo, observacion);

                if (!pagoOk)
                {
                    MessageBox.Show("No se pudo registrar el pago", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Paso 3: confirmar membresía con fechas y estado Activo
                bool membresiaOk = controladorClientes.ConfirmarPagoMembresia(
                    idClienteMembresia, DateTime.Today, membresiaActual.CantidadMsd);

                if (!membresiaOk)
                {
                    MessageBox.Show("No se pudo confirmar la membresía", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener folio y mostrar resultados
                string folio = controladorVentas.ObtenerFolio(idOperacion);

                // Mostrar total y vuelto si aplica
                lbl_Total_ClientesMembresiasPagos.Text = "$" + total.ToString("N2");
                lbl_Total_ClientesMembresiasPagos.Visible = true;
                label3.Visible = true;

                if (metodo == "Efectivo")
                {
                    // Si no hay vuelto muestra $0.00 en vez de ocultar o mostrar guión
                    lbl_Vuelto_ClientesMembresiasPagos.Text = "$" + vuelto.ToString("N2");
                    lbl_Vuelto_ClientesMembresiasPagos.Visible = true;
                    label5.Visible = true;
                }

                lbl_EstadoMembresia_ClientesMembresiasPagos.Text = "Pagado";
                lbl_EstadoMembresia_ClientesMembresiasPagos.ForeColor = System.Drawing.Color.ForestGreen;

                btn_Agregar__ClientesMembresiasPagos.Enabled = false;

                MessageBox.Show($"Pago registrado correctamente\nFolio: {folio}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarHistorialPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv__ClientesMembresiasPagos.SelectedRows.Count == 0 ||
                dgv__ClientesMembresiasPagos.SelectedRows[0].Cells["id_pago"].Value == null)
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

        private void btn_Reimprimir_Click(object sender, EventArgs e)
        {
            if (dgv__ClientesMembresiasPagos.SelectedRows.Count == 0 ||
                dgv__ClientesMembresiasPagos.SelectedRows[0].Cells["folio"].Value == null)
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

        private void CargarTiposDePago()
        {
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Efectivo");
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Tarjeta de débito");
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Tarjeta de crédito");
            cmb_TipoDePago_ClientesMembresiasPagos.Items.Add("Transferencia");
            cmb_TipoDePago_ClientesMembresiasPagos.SelectedIndex = -1;
        }

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

        private void txt_Importe_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números, una coma decimal y backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // bloquea cualquier otra tecla
        }

        private void txt_Importe_TextChanged(object sender, EventArgs e)
        {
            // Solo calcula pero NO muestra el vuelto todavía
            // El vuelto aparece recién después de confirmar el pago
            if (cmb_TipoDePago_ClientesMembresiasPagos.SelectedItem?.ToString() != "Efectivo")
                return;

            if (decimal.TryParse(txt_Importe_ClientesMembresiasPagos.Text, out decimal importe))
            {
                decimal vuelto = importe - membresiaActual.Precio;
                lbl_Vuelto_ClientesMembresiasPagos.Text = vuelto >= 0
                    ? "$" + vuelto.ToString("N2")
                    : "Importe insuficiente";
            }
        }

        private void cmb_TipoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TipoDePago_ClientesMembresiasPagos.SelectedItem?.ToString() != "Efectivo")
            {
                // Otros métodos: importe fijo, no editable
                txt_Importe_ClientesMembresiasPagos.Text = membresiaActual.Precio.ToString("N2");
                txt_Importe_ClientesMembresiasPagos.ReadOnly = true;

                // Ocultar vuelto porque no aplica
                lbl_Vuelto_ClientesMembresiasPagos.Visible = false;
                label5.Visible = false;
            }
            else
            {
                // Efectivo: importe editable para ingresar lo que entrega el cliente
                txt_Importe_ClientesMembresiasPagos.ReadOnly = false;
                txt_Importe_ClientesMembresiasPagos.Focus();
            }
        }

    }
}