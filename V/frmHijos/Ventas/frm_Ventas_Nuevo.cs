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

namespace Gym.V.frmHijos.Ventas
{
    public partial class frm_Ventas_Nuevo : Form
    {
        private ControladorVentas controladorVentas = new ControladorVentas();
        private ControladorProductos controladorProductos = new ControladorProductos();
        private ControladorClientes controladorClientes = new ControladorClientes();

        private DataTable tablaItems = new DataTable();
        private List<Producto> productos = new List<Producto>();
        public frm_Ventas_Nuevo()
        {
            InitializeComponent();
        }

        private void frm_Ventas_Nuevo_Load(object sender, EventArgs e)
        {
            InicializarTablaItems();
            CargarClientes();
            CargarProductos();
            CargarTiposPago();
            ActualizarTotal();
        }

        private void btn_Agregar_VentasNuevo_Click(object sender, EventArgs e)
        {
            if (cmb_Producto_VentasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Producto_VentasNuevo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Cantidad_VentasNuevo.Text) ||
                !decimal.TryParse(txt_Cantidad_VentasNuevo.Text, out decimal cantidad) ||
                cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Cantidad_VentasNuevo.Focus();
                return;
            }

            if (cmb_Cliente_VentasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente antes de agregar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Cliente_VentasNuevo.Focus();
                return;
            }

            var producto = (Producto)cmb_Producto_VentasNuevo.SelectedItem;

            decimal cantidadYaEnTabla = 0;

            foreach (DataRow fila in tablaItems.Rows)
            {
                if (Convert.ToInt32(fila["IdProducto"]) == producto.IdProducto)
                {
                    cantidadYaEnTabla = Convert.ToDecimal(fila["Cantidad"]);
                    break;
                }
            }

            if (cantidad + cantidadYaEnTabla > producto.Stock)
            {
                MessageBox.Show("No hay stock suficiente para esa cantidad.",
                    "Stock insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = cantidad * producto.PrecioVenta;

            foreach (DataRow fila in tablaItems.Rows)
            {
                if (Convert.ToInt32(fila["IdProducto"]) == producto.IdProducto)
                {
                    decimal nuevaCantidad = Convert.ToDecimal(fila["Cantidad"]) + cantidad;

                    fila["Cantidad"] = nuevaCantidad;
                    fila["Subtotal"] = nuevaCantidad * producto.PrecioVenta;

                    ActualizarTotal();
                    LimpiarCamposProducto();
                    return;
                }
            }

            tablaItems.Rows.Add(
                producto.IdProducto,
                producto.Nombre,
                cantidad,
                producto.PrecioVenta,
                subtotal
            );

            ActualizarTotal();
            LimpiarCamposProducto();
        }

        private void btn_Eliminar_VentasNuevo_Click(object sender, EventArgs e)
        {
            if (dgv_VentasNuevo.SelectedRows.Count == 0 ||
                dgv_VentasNuevo.SelectedRows[0].Cells["IdProducto"].Value == null)
            {
                MessageBox.Show("Seleccione un producto de la lista para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea eliminar el producto seleccionado de la venta?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            // Buscar y eliminar la fila en la DataTable
            int idProducto = Convert.ToInt32(dgv_VentasNuevo.SelectedRows[0].Cells["IdProducto"].Value);

            foreach (DataRow fila in tablaItems.Rows)
            {
                if (Convert.ToInt32(fila["IdProducto"]) == idProducto)
                {
                    tablaItems.Rows.Remove(fila);
                    break;
                }
            }

            ActualizarTotal();
        }

        private void btn_Limpiar_VentasNuevo_Click(object sender, EventArgs e)
        {
            if (tablaItems.Rows.Count == 0)
            {
                MessageBox.Show("La lista ya está vacía.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea limpiar todos los productos de la venta?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            tablaItems.Rows.Clear();
            ActualizarTotal();
        }

        private void btn_RealizarVentas_VentasNuevo_Click(object sender, EventArgs e)
        {
            if (cmb_Cliente_VentasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Cliente_VentasNuevo.Focus();
                return;
            }

            if (tablaItems.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmb_TipoPago_VentasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el tipo de pago.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_TipoPago_VentasNuevo.Focus();
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Confirmar la venta por $" + lbl_Total_VentasNuevo.Text + "?",
                "Confirmar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            var cliente = (Cliente)cmb_Cliente_VentasNuevo.SelectedItem;

            var items = new List<DetalleVentaItem>();
            foreach (DataRow fila in tablaItems.Rows)
            {
                items.Add(new DetalleVentaItem
                {
                    IdProducto = Convert.ToInt32(fila["IdProducto"]),
                    Cantidad = Convert.ToDecimal(fila["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(fila["CostoUnitario"]),
                    Subtotal = Convert.ToDecimal(fila["Subtotal"])
                });
            }

            // TODO: reemplazar 1 por el id del usuario de sesión
            bool resultado = controladorVentas.InsertVentaCompleta(
                cliente.IdCliente, 1, items);

            if (resultado)
            {
                MessageBox.Show("Venta registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la venta.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_Producto_ComprasNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Producto_VentasNuevo.SelectedItem is Producto p)
            {
                txt_Codigo_VentasNuevo.Text = p.Codigo.ToString();
                lbl_Costo_VentasNuevo.Text = "$" + p.Costo.ToString("N2");
                lbl_Precio_VentasNuevo.Text = "$" + p.PrecioVenta.ToString("N2");
            }
            else
            {
                txt_Codigo_VentasNuevo.Text = string.Empty;
                lbl_Costo_VentasNuevo.Text = "####";
                lbl_Precio_VentasNuevo.Text = "####";
            }
        }

        private void InicializarTablaItems()
        {
            tablaItems.Columns.Add("IdProducto", typeof(int));
            tablaItems.Columns.Add("Producto", typeof(string));
            tablaItems.Columns.Add("Cantidad", typeof(decimal));
            tablaItems.Columns.Add("CostoUnitario", typeof(decimal));
            tablaItems.Columns.Add("Subtotal", typeof(decimal));

            dgv_VentasNuevo.DataSource = tablaItems;
            dgv_VentasNuevo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_VentasNuevo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_VentasNuevo.MultiSelect = false;
            dgv_VentasNuevo.ReadOnly = true;
            dgv_VentasNuevo.Columns["IdProducto"].Visible = false;
        }

        private void CargarClientes()
        {
            var lista = controladorClientes.ObtenerClientesActivos();

            cmb_Cliente_VentasNuevo.DisplayMember = "NombreCompleto";
            cmb_Cliente_VentasNuevo.ValueMember = "IdCliente";
            cmb_Cliente_VentasNuevo.DataSource = lista;
            cmb_Cliente_VentasNuevo.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            productos = controladorProductos.ObtenerProductosActivos();

            cmb_Producto_VentasNuevo.SelectedIndexChanged -= cmb_Producto_ComprasNuevo_SelectedIndexChanged;

            cmb_Producto_VentasNuevo.DisplayMember = "Nombre";
            cmb_Producto_VentasNuevo.ValueMember = "IdProducto";
            cmb_Producto_VentasNuevo.DataSource = productos;
            cmb_Producto_VentasNuevo.SelectedIndex = -1;

            cmb_Producto_VentasNuevo.SelectedIndexChanged += cmb_Producto_ComprasNuevo_SelectedIndexChanged;
        }

        private void CargarTiposPago()
        {
            cmb_TipoPago_VentasNuevo.Items.Add("Efectivo");
            cmb_TipoPago_VentasNuevo.Items.Add("Transferencia");
            cmb_TipoPago_VentasNuevo.Items.Add("Cheque");
            cmb_TipoPago_VentasNuevo.SelectedIndex = -1;
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataRow fila in tablaItems.Rows)
                total += Convert.ToDecimal(fila["Subtotal"]);
            lbl_Total_VentasNuevo.Text = total.ToString("N2");
        }

        private void LimpiarCamposProducto()
        {
            txt_Codigo_VentasNuevo.Clear();
            txt_Cantidad_VentasNuevo.Clear();
            cmb_Producto_VentasNuevo.SelectedIndex = -1;
            lbl_Costo_VentasNuevo.Text = "####";
            lbl_Precio_VentasNuevo.Text = "####";
            txt_Cantidad_VentasNuevo.Focus();
        }

        
    }
}
