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


namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes_Nuevo : Form
    {
        ControladorClientes controlador = new ControladorClientes();
        private Cliente ClienteActual; //variable que guarda el "cliente" proveniente de la dvg 
        private bool NuevoCl;
        
        // 2 constructores para usar el mismo frm modal tanto para agregar o editar clientes
        public frm_Clientes_Nuevo()
        {
            InitializeComponent();
            NuevoCl = true;
        }

        public frm_Clientes_Nuevo(Cliente cliente)
        {
            InitializeComponent();
            NuevoCl = false;
            ClienteActual = cliente;
        }

        private void frm_Clientes_Nuevo_Load(object sender, EventArgs e)
        {
            if (NuevoCl)
            {
                chk_Activo.Checked = true;
                chk_Activo.Enabled = false;
            }
            else 
            {
                chk_Activo.Enabled = true;
                CargarDatosEnControles(ClienteActual);
            }
        }

        private void btn_Guardar_ClientesNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txt_Codigo_ClientesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un código de cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Codigo_ClientesNuevo.Focus();
                    return;
                }

                if (!int.TryParse(txt_Codigo_ClientesNuevo.Text, out int codCliente))
                {
                    MessageBox.Show("El código de cliente debe ser un número válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Codigo_ClientesNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Nombre_ClientesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Nombre_ClientesNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Apellido_ClientesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un apellido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Apellido_ClientesNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_DNI_ClientesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un DNI", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_DNI_ClientesNuevo.Focus();
                    return;
                }

                if (txt_DNI_ClientesNuevo.Text.Length < 7 || txt_DNI_ClientesNuevo.Text.Length > 8)
                {
                    MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_DNI_ClientesNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Telefono_ClientesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un teléfono", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Telefono_ClientesNuevo.Focus();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txt_Email_ClientesNuevo.Text))
                {
                    if (!txt_Email_ClientesNuevo.Text.Contains("@") || !txt_Email_ClientesNuevo.Text.Contains("."))
                    {
                        MessageBox.Show("Debe ingresar un email válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Email_ClientesNuevo.Focus();
                        return;
                    }
                }

                if (dtp_FechaNacimiento_ClientesNuevo.Value.Date >= DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de nacimiento debe ser anterior a hoy", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_FechaNacimiento_ClientesNuevo.Focus();
                    return;
                }

                // Calcular edad
                int edad = DateTime.Now.Year - dtp_FechaNacimiento_ClientesNuevo.Value.Year;
                if (dtp_FechaNacimiento_ClientesNuevo.Value.Date > DateTime.Now.AddYears(-edad)) edad--;

                if (edad < 13)
                {
                    MessageBox.Show("El cliente debe tener al menos 13 años", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_FechaNacimiento_ClientesNuevo.Focus();
                    return;
                }

                string nombre = txt_Nombre_ClientesNuevo.Text.Trim();
                string apellido = txt_Apellido_ClientesNuevo.Text.Trim();
                string dni = txt_DNI_ClientesNuevo.Text.Trim();
                string telefono = txt_Telefono_ClientesNuevo.Text.Trim();
                string email = txt_Email_ClientesNuevo.Text.Trim();
                bool activo = chk_Activo.Checked;
                DateTime fechaNac = dtp_FechaNacimiento_ClientesNuevo.Value;
                bool resultado;

                if (NuevoCl)
                {
                    // INSERT
                    resultado = controlador.InsertClientes(
                        codCliente, nombre, apellido,
                        dni, telefono, email, activo, fechaNac
                    );
                }
                else
                {
                    // UPDATE
                    DialogResult confirmacion = MessageBox.Show(
                        "¿Desea guardar los cambios en el cliente?",
                        "Confirmar modificación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmacion != DialogResult.Yes) return;

                    resultado = controlador.UpdateClientes(
                        ClienteActual.IdCliente,
                        codCliente, nombre, apellido,
                        dni, telefono, email, activo, fechaNac
                    );
                }

                if (resultado)
                {
                    MessageBox.Show("Cliente guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void CargarDatosEnControles(Cliente cliente)
        {
            txt_Codigo_ClientesNuevo.Text = cliente.CodCliente.ToString();
            txt_Nombre_ClientesNuevo.Text = cliente.Nombre;
            txt_Apellido_ClientesNuevo.Text = cliente.Apellido;
            txt_DNI_ClientesNuevo.Text = cliente.Dni;
            txt_Telefono_ClientesNuevo.Text = cliente.Telefono;
            txt_Email_ClientesNuevo.Text = cliente.Email;
            chk_Activo.Checked = cliente.Activo;
            dtp_FechaNacimiento_ClientesNuevo.Value = cliente.FechaNac;
        }

    }
}
