using Gym.C;
using Gym.M.Entidades;
using Gym.V.FuncionesV;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Compras
{
    public partial class frm_Compras_Proveedores : Form
    {
        private ControladorProveedores controlador = new ControladorProveedores();

        public frm_Compras_Proveedores()
        {
            InitializeComponent();
        }

        private void frm_Compras_Proveedores_Load(object sender, EventArgs e)
        {
            CargarFiltro();
            CargarProveedores();
        }

        private void btn_Agregar_Proveedor_Click(object sender, EventArgs e)
        {
            frm_Compras_Proveedores_Nuevo frm = new frm_Compras_Proveedores_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
                CargarProveedores();
        }

        private void btn_Modificar_Proveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = CargarProveedorSeleccionado();

            if (proveedor == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Compras_Proveedores_Nuevo frm = new frm_Compras_Proveedores_Nuevo(proveedor);

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
                CargarProveedores();
        }

        private void btn_Eliminar_Proveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = CargarProveedorSeleccionado();

            if (proveedor == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea eliminar este proveedor?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteProveedor(proveedor.IdProveedor);

                if (resultado)
                {
                    MessageBox.Show("Proveedor eliminado correctamente.");
                    CargarProveedores();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el proveedor.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbm_Filtro_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private Proveedor CargarProveedorSeleccionado()
        {
            if (dvg_Proveedores.SelectedRows.Count == 0 ||
                dvg_Proveedores.SelectedRows[0].Cells["id_proveedor"].Value == null)
                return null;

            var fila = dvg_Proveedores.SelectedRows[0];

            return new Proveedor
            {
                IdProveedor = Convert.ToInt32(fila.Cells["id_proveedor"].Value),
                Nombre = fila.Cells["nombre"].Value.ToString(),
                Cuit = fila.Cells["cuit"].Value.ToString(),
                Telefono = fila.Cells["telefono"].Value.ToString(),
                Email = fila.Cells["email"].Value.ToString(),
                Activo = Convert.ToBoolean(fila.Cells["activo"].Value)
            };
        }

        private void CargarFiltro()
        {
            cbm_Filtro_Proveedor.Items.Add("Activo");
            cbm_Filtro_Proveedor.Items.Add("Inactivo");
            cbm_Filtro_Proveedor.Items.Add("Todos");
            cbm_Filtro_Proveedor.SelectedIndex = 0;
        }

        private void CargarProveedores()
        {
            string filtro = cbm_Filtro_Proveedor.SelectedItem?.ToString() ?? "Activo";

            controlador.ListarProveedores(dvg_Proveedores, filtro);

            if (dvg_Proveedores.Columns.Contains("id_proveedor"))
                dvg_Proveedores.Columns["id_proveedor"].Visible = false;
            if (dvg_Proveedores.Columns.Contains("activo"))
                dvg_Proveedores.Columns["activo"].Visible = false;
            if (dvg_Proveedores.Columns.Contains("fecha_creacion"))
                dvg_Proveedores.Columns["fecha_creacion"].Visible = false;

            dvg_Proveedores.ClearSelection();
        }
    }
}