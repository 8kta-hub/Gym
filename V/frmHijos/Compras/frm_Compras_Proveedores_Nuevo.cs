using Gym.C;
using Gym.M.Entidades;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Compras
{
    public partial class frm_Compras_Proveedores_Nuevo : Form
    {
        private ControladorProveedores controlador = new ControladorProveedores();
        private Proveedor proveedorActual;
        private bool NuevoProv;

        public frm_Compras_Proveedores_Nuevo()
        {
            InitializeComponent();
            NuevoProv = true;
        }

        public frm_Compras_Proveedores_Nuevo(Proveedor proveedor)
        {
            InitializeComponent();
            NuevoProv = false;
            proveedorActual = proveedor;
        }

        private void frm_Compras_Proveedores_Nuevo_Load(object sender, EventArgs e)
        {
            if (NuevoProv)
            {
                chk_Activo_ProveedorNuevo.Checked = true;
                chk_Activo_ProveedorNuevo.Enabled = false;
            }
            else
            {
                chk_Activo_ProveedorNuevo.Enabled = true;
                CargarDatosEnControles(proveedorActual);
            }
        }

        private void btn_Guardar_ProveedorNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Nombre_ProveedorNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Nombre_ProveedorNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_CUIT_ProveedorNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar el CUIT.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_CUIT_ProveedorNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Telefono_ProveedorNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un teléfono.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Telefono_ProveedorNuevo.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txt_Email_ProveedorNuevo.Text))
                {
                    if (!txt_Email_ProveedorNuevo.Text.Contains("@") ||
                        !txt_Email_ProveedorNuevo.Text.Contains("."))
                    {
                        MessageBox.Show("Debe ingresar un email válido.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Email_ProveedorNuevo.Focus();
                        return;
                    }
                }

                string nombre = txt_Nombre_ProveedorNuevo.Text.Trim();
                string cuit = txt_CUIT_ProveedorNuevo.Text.Trim();
                string telefono = txt_Telefono_ProveedorNuevo.Text.Trim();
                string email = txt_Email_ProveedorNuevo.Text.Trim();
                bool resultado;

                if (NuevoProv)
                {
                    resultado = controlador.InsertProveedor(nombre, cuit, telefono, email);
                }
                else
                {
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Desea guardar los cambios en el proveedor?",
                        "Confirmar modificación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion != DialogResult.Yes) return;

                    resultado = controlador.UpdateProveedor(
                        proveedorActual.IdProveedor,
                        nombre, cuit, telefono, email,
                        chk_Activo_ProveedorNuevo.Checked);
                }

                if (resultado)
                {
                    MessageBox.Show("Proveedor guardado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el proveedor.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosEnControles(Proveedor proveedor)
        {
            txt_Nombre_ProveedorNuevo.Text = proveedor.Nombre;
            txt_CUIT_ProveedorNuevo.Text = proveedor.Cuit;
            txt_Telefono_ProveedorNuevo.Text = proveedor.Telefono;
            txt_Email_ProveedorNuevo.Text = proveedor.Email;
            chk_Activo_ProveedorNuevo.Checked = proveedor.Activo;
        }
    }
}