using Gym.C;
using Gym.M.Entidades;
using Gym.V.FuncionesV;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Compras
{
    public partial class frm_Compras : Form
    {
        private ControladoarCompras controlador = new ControladoarCompras();

        public frm_Compras()
        {
            InitializeComponent();
        }

        private void frm_Compras_Load(object sender, EventArgs e)
        {
            dtp_FechaInicial_Compras.Value = new DateTime(2000, 1, 1);
            dtp_FechaFinal_Compras.Value = DateTime.Now;
            CargarCompras();
        }

        private void btn_Nuevo_Compras_Click(object sender, EventArgs e)
        {
            frm_Compras_Nuevo frm = new frm_Compras_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
                CargarCompras();
        }

        private void btn_Detalle_Compras_Click(object sender, EventArgs e)
        {
            Compra compra = CargarCompraSeleccionada();

            if (compra == null)
            {
                MessageBox.Show("Seleccione una compra.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Compras_Detalle frm = new frm_Compras_Detalle(compra);
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Eliminar_Compras_Click(object sender, EventArgs e)
        {
            Compra compra = CargarCompraSeleccionada();

            if (compra == null)
            {
                MessageBox.Show("Seleccione una compra.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (compra.Estado == "Cancelada")
            {
                MessageBox.Show("La compra ya está cancelada.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea cancelar esta compra?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteCompra(compra.IdCompra);

                if (resultado)
                {
                    MessageBox.Show("Compra cancelada correctamente.");
                    CargarCompras();
                }
                else
                {
                    MessageBox.Show("No se pudo cancelar la compra.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Proveedores_Compras_Click(object sender, EventArgs e)
        {
            frm_Compras_Proveedores frm = new frm_Compras_Proveedores();
            Funciones.abrirFormModal(frm, this);
        }

        private void dtp_FechaInicial_Compras_ValueChanged_1(object sender, EventArgs e)
        {
            CargarCompras();
        }
        private void dtp_FechaFinal_Compras_ValueChanged(object sender, EventArgs e)
        {
            CargarCompras();
        }

        private Compra CargarCompraSeleccionada()
        {
            if (dgv_Compras.SelectedRows.Count == 0 ||
                dgv_Compras.SelectedRows[0].Cells["id_compra"].Value == null)
                return null;

            var fila = dgv_Compras.SelectedRows[0];

            return new Compra
            {
                IdCompra = Convert.ToInt32(fila.Cells["id_compra"].Value),
                NombreProveedor = fila.Cells["Proveedor"].Value.ToString(),
                NombreUsuario = fila.Cells["Usuario"].Value.ToString(),
                Fecha = Convert.ToDateTime(fila.Cells["fecha"].Value),
                Total = Convert.ToDecimal(fila.Cells["total"].Value),
                Estado = fila.Cells["estado"].Value.ToString()
            };
        }

        private void dgv_Compras_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Compras.ClearSelection();
        }

        private void CargarCompras()
        {
            controlador.ListarCompras(dgv_Compras,
                dtp_FechaInicial_Compras.Value,
                dtp_FechaFinal_Compras.Value);

            if (dgv_Compras.Columns.Contains("id_compra"))
                dgv_Compras.Columns["id_compra"].Visible = false;

            dgv_Compras.ClearSelection();
        }
    }
}