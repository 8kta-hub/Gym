using Gym.C;
using Gym.M.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Compras
{
    public partial class frm_Compras_Nuevo : Form
    {
        private ControladoarCompras controladorCompras = new ControladoarCompras();
        private ControladorProductos controladorProductos = new ControladorProductos();
        private ControladorProveedores controladorProveedores = new ControladorProveedores();

        private DataTable tablaItems = new DataTable();
        private List<Producto> productos = new List<Producto>();

        public frm_Compras_Nuevo()
        {
            InitializeComponent();
        }

        private void frm_Compras_Nuevo_Load(object sender, EventArgs e)
        {
            InicializarTablaItems();
            CargarProveedores();
            CargarProductos();
            CargarTiposPago();
            ActualizarTotal();
        }

        private void btn_Agregar_ComprasNuevo_Click(object sender, EventArgs e)
        {
            if (cmb_Producto_ComprasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Producto_ComprasNuevo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Cantidad_ComprasNuevo.Text) ||
                !decimal.TryParse(txt_Cantidad_ComprasNuevo.Text, out decimal cantidad) ||
                cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Cantidad_ComprasNuevo.Focus();
                return;
            }

            var producto = (Producto)cmb_Producto_ComprasNuevo.SelectedItem;

            // PUNTO 3: el producto debe corresponder al proveedor seleccionado
            if (cmb_Proveedor_ComprasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor antes de agregar productos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Proveedor_ComprasNuevo.Focus();
                return;
            }

            var proveedor = (Proveedor)cmb_Proveedor_ComprasNuevo.SelectedItem;

            if (producto.IdProveedor != proveedor.IdProveedor)
            {
                MessageBox.Show(
                    $"El producto '{producto.Nombre}' no pertenece al proveedor seleccionado.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = cantidad * producto.Costo;

            // Si ya está en la tabla, suma la cantidad
            foreach (DataRow fila in tablaItems.Rows)
            {
                if (Convert.ToInt32(fila["IdProducto"]) == producto.IdProducto)
                {
                    decimal cantAnterior = Convert.ToDecimal(fila["Cantidad"]);
                    fila["Cantidad"] = cantAnterior + cantidad;
                    fila["Subtotal"] = (cantAnterior + cantidad) * producto.Costo;
                    ActualizarTotal();
                    LimpiarCamposProducto();
                    return;
                }
            }

            tablaItems.Rows.Add(
                producto.IdProducto,
                producto.Nombre,
                cantidad,
                producto.Costo,
                subtotal
            );

            ActualizarTotal();
            LimpiarCamposProducto();
        }

        private void btn_Eliminar_ComprasNuevo_Click(object sender, EventArgs e)
        {
            if (dgv_ComprasNuevo.SelectedRows.Count == 0 ||
                dgv_ComprasNuevo.SelectedRows[0].Cells["IdProducto"].Value == null)
            {
                MessageBox.Show("Seleccione un producto de la lista para eliminar.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea eliminar el producto seleccionado de la compra?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            // Buscar y eliminar la fila en la DataTable
            int idProducto = Convert.ToInt32(dgv_ComprasNuevo.SelectedRows[0].Cells["IdProducto"].Value);

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

        private void btn_Limpiar_ComprasNuevo_Click(object sender, EventArgs e)
        {
            if (tablaItems.Rows.Count == 0)
            {
                MessageBox.Show("La lista ya está vacía.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea limpiar todos los productos de la compra?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            tablaItems.Rows.Clear();
            ActualizarTotal();
        }

        private void btn_RealizarCompra_ComprasNuevo_Click(object sender, EventArgs e)
        {
            if (cmb_Proveedor_ComprasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_Proveedor_ComprasNuevo.Focus();
                return;
            }

            if (tablaItems.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // PUNTO 2 y 4: tipo de pago obligatorio
            if (cmb_TipoPago_ComprasNuevo.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar el tipo de pago.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_TipoPago_ComprasNuevo.Focus();
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Confirmar la compra por $" + lbl_Total_ComprasNuevo.Text + "?",
                "Confirmar compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            var proveedor = (Proveedor)cmb_Proveedor_ComprasNuevo.SelectedItem;

            var items = new List<DetalleCompraItem>();
            foreach (DataRow fila in tablaItems.Rows)
            {
                items.Add(new DetalleCompraItem
                {
                    IdProducto = Convert.ToInt32(fila["IdProducto"]),
                    Cantidad = Convert.ToDecimal(fila["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(fila["CostoUnitario"]),
                    Subtotal = Convert.ToDecimal(fila["Subtotal"])
                });
            }

            // TODO: reemplazar 1 por el id del usuario de sesión
            bool resultado = controladorCompras.InsertCompraCompleta(
                proveedor.IdProveedor, 1, items);

            if (resultado)
            {
                MessageBox.Show("Compra registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la compra.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_Producto_ComprasNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Producto_ComprasNuevo.SelectedItem is Producto p)
            {
                txt_Codigo_ComprasNuevo.Text = p.Codigo.ToString();
                lbl_Costo_ComprasNuevo.Text = "$" + p.Costo.ToString("N2");
                lbl_Precio_ComprasNuevo.Text = "$" + p.PrecioVenta.ToString("N2");

                // Filtrar el combo de proveedores al proveedor del producto
                var listaProveedores = cmb_Proveedor_ComprasNuevo.DataSource as List<Proveedor>;
                if (listaProveedores != null)
                {
                    cmb_Proveedor_ComprasNuevo.SelectedIndexChanged -= cmb_Proveedor_ComprasNuevo_SelectedIndexChanged;
                    var proveedorDelProducto = listaProveedores.Find(x => x.IdProveedor == p.IdProveedor);
                    if (proveedorDelProducto != null)
                        cmb_Proveedor_ComprasNuevo.SelectedItem = proveedorDelProducto;
                    cmb_Proveedor_ComprasNuevo.SelectedIndexChanged += cmb_Proveedor_ComprasNuevo_SelectedIndexChanged;
                }
            }
            else
            {
                txt_Codigo_ComprasNuevo.Text = string.Empty;
                lbl_Costo_ComprasNuevo.Text = "####";
                lbl_Precio_ComprasNuevo.Text = "####";
            }
        }

        private void cmb_Proveedor_ComprasNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Proveedor_ComprasNuevo.SelectedItem is Proveedor p)
            {
                var filtrados = productos.FindAll(x => x.IdProveedor == p.IdProveedor);
                cmb_Producto_ComprasNuevo.SelectedIndexChanged -= cmb_Producto_ComprasNuevo_SelectedIndexChanged;
                cmb_Producto_ComprasNuevo.DataSource = filtrados;
                cmb_Producto_ComprasNuevo.DisplayMember = "Nombre";
                cmb_Producto_ComprasNuevo.ValueMember = "IdProducto";
                cmb_Producto_ComprasNuevo.SelectedIndex = -1;
                cmb_Producto_ComprasNuevo.SelectedIndexChanged += cmb_Producto_ComprasNuevo_SelectedIndexChanged;
            }
            else
            {
                // Sin proveedor seleccionado → muestra todos los productos
                cmb_Producto_ComprasNuevo.SelectedIndexChanged -= cmb_Producto_ComprasNuevo_SelectedIndexChanged;
                cmb_Producto_ComprasNuevo.DataSource = productos;
                cmb_Producto_ComprasNuevo.DisplayMember = "Nombre";
                cmb_Producto_ComprasNuevo.ValueMember = "IdProducto";
                cmb_Producto_ComprasNuevo.SelectedIndex = -1;
                cmb_Producto_ComprasNuevo.SelectedIndexChanged += cmb_Producto_ComprasNuevo_SelectedIndexChanged;
            }

            LimpiarCamposProducto();
        }

        private void InicializarTablaItems()
        {
            tablaItems.Columns.Add("IdProducto", typeof(int));
            tablaItems.Columns.Add("Producto", typeof(string));
            tablaItems.Columns.Add("Cantidad", typeof(decimal));
            tablaItems.Columns.Add("CostoUnitario", typeof(decimal));
            tablaItems.Columns.Add("Subtotal", typeof(decimal));

            dgv_ComprasNuevo.DataSource = tablaItems;
            dgv_ComprasNuevo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ComprasNuevo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ComprasNuevo.MultiSelect = false;
            dgv_ComprasNuevo.ReadOnly = true;
            dgv_ComprasNuevo.Columns["IdProducto"].Visible = false;
        }

        private void CargarProveedores()
        {
            var lista = controladorProveedores.ObtenerProveedoresActivos();

            // Desuscribir para que asignar DataSource no dispare el evento
            cmb_Proveedor_ComprasNuevo.SelectedIndexChanged -= cmb_Proveedor_ComprasNuevo_SelectedIndexChanged;

            cmb_Proveedor_ComprasNuevo.DisplayMember = "Nombre";
            cmb_Proveedor_ComprasNuevo.ValueMember = "IdProveedor";
            cmb_Proveedor_ComprasNuevo.DataSource = lista;
            cmb_Proveedor_ComprasNuevo.SelectedIndex = -1;

            // Volver a suscribir
            cmb_Proveedor_ComprasNuevo.SelectedIndexChanged += cmb_Proveedor_ComprasNuevo_SelectedIndexChanged;
        }

        private void CargarProductos()
        {
            productos = controladorProductos.ObtenerProductosActivos();

            cmb_Producto_ComprasNuevo.SelectedIndexChanged -= cmb_Producto_ComprasNuevo_SelectedIndexChanged;

            cmb_Producto_ComprasNuevo.DisplayMember = "Nombre";
            cmb_Producto_ComprasNuevo.ValueMember = "IdProducto";
            cmb_Producto_ComprasNuevo.DataSource = productos;
            cmb_Producto_ComprasNuevo.SelectedIndex = -1;

            cmb_Producto_ComprasNuevo.SelectedIndexChanged += cmb_Producto_ComprasNuevo_SelectedIndexChanged;
        }

        private void CargarTiposPago()
        {
            cmb_TipoPago_ComprasNuevo.Items.Add("Efectivo");
            cmb_TipoPago_ComprasNuevo.Items.Add("Transferencia");
            cmb_TipoPago_ComprasNuevo.Items.Add("Cheque");
            cmb_TipoPago_ComprasNuevo.SelectedIndex = -1;
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataRow fila in tablaItems.Rows)
                total += Convert.ToDecimal(fila["Subtotal"]);
            lbl_Total_ComprasNuevo.Text = total.ToString("N2");
        }

        private void LimpiarCamposProducto()
        {
            txt_Codigo_ComprasNuevo.Clear();
            txt_Cantidad_ComprasNuevo.Clear();
            cmb_Producto_ComprasNuevo.SelectedIndex = -1;
            lbl_Costo_ComprasNuevo.Text = "####";
            lbl_Precio_ComprasNuevo.Text = "####";
            txt_Cantidad_ComprasNuevo.Focus();
        }

        
    }
}