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
using Gym.V.frmHijos;


namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes_Nuevo : Form
    {
        ControladorClientes controlador = new ControladorClientes();
        public frm_Clientes_Nuevo()
        {
            InitializeComponent();
        }

        private void btn_Guardar_ClientesNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                int codCliente = Convert.ToInt32(txt_Codigo_ClientesNuevo.Text);
                string nombre = txt_Nombre_ClientesNuevo.Text;
                string apellido = txt_Apellido_ClientesNuevo.Text;
                string dni = txt_DNI_ClientesNuevo.Text;
                string telefono = txt_Telefono_ClientesNuevo.Text;
                string email = txt_Email_ClientesNuevo.Text;
                DateTime fechaNac = dtp_FechaNacimiento_ClientesNuevo.Value;

                bool resultado = controlador.InsertClientes(
                    codCliente, nombre, apellido,
                    dni, telefono, email, fechaNac
                );

                if (resultado)
                {
                    MessageBox.Show("Cliente guardado correctamente");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cliente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txt_Codigo_ClientesNuevo.Clear();
            txt_Nombre_ClientesNuevo.Clear();
            txt_Apellido_ClientesNuevo.Clear();
            txt_DNI_ClientesNuevo.Clear();
            txt_Telefono_ClientesNuevo.Clear();
            txt_Email_ClientesNuevo.Clear();
            chk_Activo.Checked = false;
            dtp_FechaNacimiento_ClientesNuevo.Value = DateTime.Now;
        }

    }
}
