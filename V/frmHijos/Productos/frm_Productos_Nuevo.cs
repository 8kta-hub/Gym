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

namespace Gym.V.frmHijos.Productos
{
    public partial class frm_Productos_Nuevo : Form
    {
        private ControladorProductos controlador = new ControladorProductos();
        private Producto productoActual;
        private bool _esAlta;

        public frm_Productos_Nuevo()
        {
            InitializeComponent();
            _esAlta = true;
        }

        public frm_Productos_Nuevo(Producto producto)
        {
            InitializeComponent();
            productoActual = producto;
            _esAlta = false;
        }

        private void frm_Productos_Nuevo_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                this.Text = "Nuevo Producto";
            }
            else
            {
                this.Text = "Modificar Producto";
                CargarDatosEnControles(productoActual);
            }
        }

        private void btn_Guardar_ProductosNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Codigo_ProductosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un codigo para el producto");
                    txt_Codigo_ProductosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Nombre_ProductosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre para el producto");
                    txt_Nombre_ProductosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Stock_ProductosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar el stock del producto");
                    txt_Stock_ProductosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Costo_ProductosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar el costo del producto");
                    txt_Costo_ProductosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Precio_ProductosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar el precio del producto");
                    txt_Costo_ProductosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Descripcion_ProductosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar una descripcion para el producto");
                    txt_Costo_ProductosNuevo.Focus();
                    return;
                }

                int codigo = Convert.ToInt32(txt_Codigo_ProductosNuevo.Text.Trim());
                string nombre = txt_Nombre_ProductosNuevo.Text.Trim();
                int stock = Convert.ToInt32(txt_Stock_ProductosNuevo.Text.Trim());
                decimal costo = Convert.ToDecimal(txt_Costo_ProductosNuevo.Text.Trim());
                decimal precioVenta = Convert.ToDecimal(txt_Precio_ProductosNuevo.Text.Trim());
                string descripcion = txt_Descripcion_ProductosNuevo.Text.Trim();
                bool activo = true;
                bool resultado;

                if (_esAlta)
                {
                    resultado = controlador.InsertProducto(codigo, nombre, stock, costo, precioVenta, descripcion, activo);
                }
                else
                {
                    // UPDATE
                    resultado = controlador.UpdateProducto(productoActual.IdProducto, codigo, nombre, stock, costo, precioVenta, descripcion);
                }

                if (resultado)
                {
                    MessageBox.Show("Producto guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CargarDatosEnControles(Producto producto)
        {
            txt_Codigo_ProductosNuevo.Text = producto.Codigo.ToString();
            txt_Nombre_ProductosNuevo.Text = producto.Nombre;
            txt_Stock_ProductosNuevo.Text = producto.Stock.ToString();
            txt_Costo_ProductosNuevo.Text = producto.Costo.ToString();
            txt_Precio_ProductosNuevo.Text = producto.PrecioVenta.ToString();
            txt_Descripcion_ProductosNuevo.Text = producto.Descripcion;
        }
    }
}
