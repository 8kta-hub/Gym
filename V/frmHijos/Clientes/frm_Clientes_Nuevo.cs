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
        private Cliente ClienteActual;
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
                int codCliente = Convert.ToInt32(txt_Codigo_ClientesNuevo.Text);
                string nombre = txt_Nombre_ClientesNuevo.Text;
                string apellido = txt_Apellido_ClientesNuevo.Text;
                string dni = txt_DNI_ClientesNuevo.Text;
                string telefono = txt_Telefono_ClientesNuevo.Text;
                string email = txt_Email_ClientesNuevo.Text;
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
                    resultado = controlador.UpdateClientes(
                        ClienteActual.IdCliente,
                        codCliente, nombre, apellido,
                        dni, telefono, email, activo, fechaNac
                    );
                }

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
