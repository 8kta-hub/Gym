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
using Gym.M.Entidades;

namespace Gym.V.frmHijos.Movimientos
{
    public partial class frm_Movimientos : Form
    {
        ControladorMovimientos controlador = new ControladorMovimientos();
        private Usuario usuarioActual;
        public frm_Movimientos(Usuario usuarioIngresado)
        {
            InitializeComponent();
            this.usuarioActual = usuarioIngresado;
        }

        private void frm_Movimientos_Load(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void btn_Nuevo_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos_Nuevos frmNuevo = new frm_Movimientos_Nuevos(usuarioActual);
            if (Funciones.abrirFormModal(frmNuevo, this) == DialogResult.OK)
                CargarMovimientos();
        }

        private void btn_Modificar_Movimientos_Click(object sender, EventArgs e)
        {
            MovimientoCaja seleccionado = CargarMovimientoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un movimiento para modificar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Movimientos_Nuevos frmEdicion = new frm_Movimientos_Nuevos(seleccionado);
            if (Funciones.abrirFormModal(frmEdicion, this) == DialogResult.OK)
                CargarMovimientos();
        }

        private MovimientoCaja CargarMovimientoSeleccionado()
        {
            if (dgv_Movimientos.CurrentRow == null) return null;
            if (dgv_Movimientos.SelectedRows.Count == 0) return null;

            DataGridViewRow fila = dgv_Movimientos.SelectedRows[0];

            return new MovimientoCaja
            {
                IdMovimientoCaja = Convert.ToInt32(fila.Cells["id_movimiento_caja"].Value),
                IdConcepto = Convert.ToInt32(fila.Cells["id_concepto"].Value),
                IdUsuario = Convert.ToInt32(fila.Cells["id_usuario"].Value),
                NombreConcepto = fila.Cells["nombre"].Value?.ToString() ?? "",
                Monto = Convert.ToDecimal(fila.Cells["monto"].Value),
                TipoMovimiento = fila.Cells["tipo_movimiento"].Value?.ToString() ?? "",
                Observaciones = fila.Cells["descripcion"].Value?.ToString() ?? ""
            };
        }

        private void CargarMovimientos()
        {
            controlador.ListarMovimientos(dgv_Movimientos);
            dgv_Movimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Movimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Movimientos.MultiSelect = false;
            dgv_Movimientos.ReadOnly = true;
        }

        private void dgv_Movimientos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Movimientos.ClearSelection();
        }

        
    }
}
