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
using Gym.M.Entidades;

namespace Gym.V.frmHijos.Movimientos
{
    public partial class frm_Movimientos_Nuevos : Form
    {
        private ControladorMovimientos controlador = new ControladorMovimientos();
        private MovimientoCaja movimientoActual;
        private Usuario usuarioActual;
        private bool _esAlta;

        public frm_Movimientos_Nuevos(Usuario usuarioIngresado)
        {
            InitializeComponent();
            _esAlta = true;
            this.usuarioActual = usuarioIngresado;
        }

        public frm_Movimientos_Nuevos(MovimientoCaja movimiento)
        {
            InitializeComponent();
            movimientoActual = movimiento;
            _esAlta = false;
        }

        private void frm_Movimientos_Nuevos_Load(object sender, EventArgs e)
        {
            CargarTiposPago();
            CargarTipo();
            if (_esAlta)
            {
                this.Text = "Nuevo Movimiento";
                controlador.CargarConceptosEnCombo(cmb_Concepto_MovimientosNuevo);
            }
            else
            {
                this.Text = "Modificar Movimiento";
                controlador.CargarConceptosEnCombo(cmb_Concepto_MovimientosNuevo);
                CargarDatosEnControles(movimientoActual);
            }
        }

        private void btn_Guardar_MovimientosNuevos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_Tipo_MovimientosNuevo.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de movimiento");
                    cmb_Tipo_MovimientosNuevo.Focus();
                    return;
                }

                if (cmb_Concepto_MovimientosNuevo.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un concepto");
                    cmb_Concepto_MovimientosNuevo.Focus();
                    return;
                }

                if (cmb_TipoPago_MovimientosNuevos.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de pago");
                    cmb_TipoPago_MovimientosNuevos.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Total_MovimientosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar el monto del movimiento");
                    txt_Total_MovimientosNuevo.Focus();
                    return;
                }




                int idUsuario = usuarioActual.IdUsuario;
                int idConcepto = Convert.ToInt32(cmb_Concepto_MovimientosNuevo.SelectedValue);
                string tipoMovimiento = cmb_Tipo_MovimientosNuevo.Text.Trim();
                string tipoPago = cmb_TipoPago_MovimientosNuevos.Text.Trim();
                decimal monto = Convert.ToDecimal(txt_Total_MovimientosNuevo.Text.Trim());
                string observaciones = txt_Observacion_MovimientosNuevos.Text.Trim();

                bool resultado;

                if (_esAlta)
                {
                    resultado = controlador.InsertMovimiento(idUsuario, idConcepto, tipoMovimiento, tipoPago, monto, observaciones);
                }
                else
                {
                    // UPDATE
                    resultado = controlador.UpdateMovimiento(movimientoActual.IdMovimientoCaja, idUsuario, idConcepto, tipoMovimiento, tipoPago, monto, observaciones);
                }

                if (resultado)
                {
                    MessageBox.Show("Movimiento guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error en el formato de los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnControles(MovimientoCaja movimiento)
        {
            cmb_Tipo_MovimientosNuevo.SelectedValue = movimiento.TipoMovimiento.ToString();
            cmb_Concepto_MovimientosNuevo.SelectedValue = movimiento.NombreConcepto.ToString();
            cmb_TipoPago_MovimientosNuevos.Text = movimiento.TipoPago.ToString();
            txt_Total_MovimientosNuevo.Text = movimiento.Monto.ToString();
            txt_Observacion_MovimientosNuevos.Text = movimiento.Observaciones.ToString();
        }

        private void CargarTipo()
        {
            cmb_TipoPago_MovimientosNuevos.Items.Add("Egreso");
            cmb_TipoPago_MovimientosNuevos.Items.Add("Ingreso");
            cmb_TipoPago_MovimientosNuevos.SelectedIndex = -1;
        }
        
        private void CargarTiposPago()
        {
            cmb_TipoPago_MovimientosNuevos.Items.Add("Efectivo");
            cmb_TipoPago_MovimientosNuevos.Items.Add("Transferencia");
            cmb_TipoPago_MovimientosNuevos.Items.Add("Tarjeta");
            cmb_TipoPago_MovimientosNuevos.SelectedIndex = -1;
        }

        
    }
}
