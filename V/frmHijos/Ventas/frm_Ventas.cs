using Gym.V.frmHijos.Roles;
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
using Gym.V.frmHijos.Compras;

namespace Gym.V.frmHijos.Ventas
{
    public partial class frm_Ventas : Form
    {
        ControladorVentas controlador = new ControladorVentas();
        public frm_Ventas()
        {
            InitializeComponent();
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            ConfigurarRangoFechas(dtp_FechaInicial_Ventas, dtp_FechaFinal_Ventas);
            CargarVentas();
        }

        private void btn_Nuevo_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas_Nuevo frm = new frm_Ventas_Nuevo();
            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
                CargarVentas();
        }

        private void btn_Detalle_Ventas_Click(object sender, EventArgs e)
        {
            Operacion seleccionado = CargarVentaSeleccionada();

            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione una venta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Ventas_Detalle frm = new frm_Ventas_Detalle(seleccionado);
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Eliminar_Ventas_Click(object sender, EventArgs e)
        {
            Operacion seleccionado = CargarVentaSeleccionada();

            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione una venta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (seleccionado.Estado == "Cancelada")
            {
                MessageBox.Show("La venta ya está cancelada.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea cancelar esta venta?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteVenta(seleccionado.IdOperacion);

                if (resultado)
                {
                    MessageBox.Show("Venta cancelada correctamente.");
                    CargarVentas();
                }
                else
                {
                    MessageBox.Show("No se pudo cancelar la venta.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Operacion CargarVentaSeleccionada()
        {
            if (dgv_Ventas.SelectedRows.Count == 0 ||
                dgv_Ventas.SelectedRows[0].Cells["id_operacion"].Value == null)
                return null;

            var fila = dgv_Ventas.SelectedRows[0];

            return new Operacion
            {
                IdOperacion = Convert.ToInt32(fila.Cells["id_operacion"].Value),
                NombreCliente = fila.Cells["Cliente"].Value.ToString(),
                NombreUsuario = fila.Cells["Usuario"].Value.ToString(),
                Fecha = Convert.ToDateTime(fila.Cells["fecha"].Value),
                Total = Convert.ToDecimal(fila.Cells["total"].Value),
                Estado = fila.Cells["estado"].Value.ToString()
            };
        }

        private void CargarVentas()
        {
            controlador.ListarVentas(dgv_Ventas);
            dgv_Ventas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Ventas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Ventas.MultiSelect = false;
            dgv_Ventas.ReadOnly = true;
        }

        private void dgv_Ventas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Ventas.ClearSelection();
        }

        private void ConfigurarRangoFechas(DateTimePicker dtpInicial, DateTimePicker dtpFinal)
        {
            dtpInicial.MaxDate = DateTime.Today;
            dtpFinal.MaxDate = DateTime.Today;

            dtpFinal.Value = DateTime.Today;
            dtpInicial.Value = DateTime.Today.AddDays(-7);
        }

        
    }
}
