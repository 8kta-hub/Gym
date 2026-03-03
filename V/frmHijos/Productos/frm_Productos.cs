using Gym.V.frmHijos.Ventas;
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
using Gym.V.frmHijos.Roles;
using Gym.M.Entidades;

namespace Gym.V.frmHijos.Productos
{
    public partial class frm_Productos : Form
    {
        private ControladorProductos controlador = new ControladorProductos();
        public frm_Productos()
        {
            InitializeComponent();
        }

        private void frm_Productos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btn_Nuevo_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos_Nuevo frmNuevo = new frm_Productos_Nuevo();
            if (Funciones.abrirFormModal(frmNuevo, this) == DialogResult.OK)
                CargarProductos();
        }

        private void btn_Modificar_Productos_Click(object sender, EventArgs e)
        {
            Producto seleccionado = CargarProductoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para modificar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Productos_Nuevo frmEdicion = new frm_Productos_Nuevo(seleccionado);
            if (Funciones.abrirFormModal(frmEdicion, this) == DialogResult.OK)
                CargarProductos();
        }

        private void btn_Eliminar_Productos_Click(object sender, EventArgs e)
        {
            Producto seleccionado = CargarProductoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Desea eliminar el producto \"{seleccionado.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool ok = controlador.DeleteProducto(seleccionado.IdProducto);
                MessageBox.Show(
                    ok ? "Producto eliminado correctamente." : "No se pudo eliminar el producto.",
                    ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ok) CargarProductos();
            }
        }

        private void btn_ExportarExcel_Roles_Click(object sender, EventArgs e)
        {
            if (dgv_Productos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = "Productos_" + DateTime.Now.ToString("yyyyMMdd");

                if (sfd.ShowDialog() != DialogResult.OK) return;

                // Construir CSV compatible con Excel si no hay librería externa,
                // o usar la exportación estándar del proyecto si ya existe un helper.
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                {
                    // Encabezados
                    for (int c = 0; c < dgv_Productos.Columns.Count; c++)
                    {
                        if (!dgv_Productos.Columns[c].Visible) continue;
                        sw.Write(dgv_Productos.Columns[c].HeaderText);
                        if (c < dgv_Productos.Columns.Count - 1) sw.Write("\t");
                    }
                    sw.WriteLine();

                    // Filas
                    foreach (DataGridViewRow fila in dgv_Productos.Rows)
                    {
                        for (int c = 0; c < dgv_Productos.Columns.Count; c++)
                        {
                            if (!dgv_Productos.Columns[c].Visible) continue;
                            sw.Write(fila.Cells[c].Value?.ToString() ?? "");
                            if (c < dgv_Productos.Columns.Count - 1) sw.Write("\t");
                        }
                        sw.WriteLine();
                    }
                }

                MessageBox.Show("Exportación completada.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Producto CargarProductoSeleccionado()
        {
            if (dgv_Productos.CurrentRow == null) return null;
            if (dgv_Productos.SelectedRows.Count == 0) return null;

            DataGridViewRow fila = dgv_Productos.SelectedRows[0];

            return new Producto
            {
                IdProveedor = Convert.ToInt32(fila.Cells["id_proveedor"].Value),
                IdProducto = Convert.ToInt32(fila.Cells["id_producto"].Value),
                Codigo = Convert.ToInt32(fila.Cells["codigo"].Value),
                Nombre = fila.Cells["ProductoNombre"].Value?.ToString() ?? "",
                Stock = Convert.ToInt32(fila.Cells["stock"].Value),
                Costo = Convert.ToDecimal(fila.Cells["costo"].Value),
                PrecioVenta = Convert.ToDecimal(fila.Cells["precio_venta"].Value),
                Descripcion = fila.Cells["descripcion"].Value?.ToString() ?? "",
                Estado = fila.Cells["estado"].Value?.ToString() ?? ""
            };
        }

        private void CargarProductos()
        {
            controlador.ListarProductos(dgv_Productos);
            dgv_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Productos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Productos.MultiSelect = false;
            dgv_Productos.ReadOnly = true;
        }

        private void dgv_Productos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Productos.ClearSelection();
        }
    }
}
