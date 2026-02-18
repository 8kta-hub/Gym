using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.M.Entidades;
using Gym.C;

namespace Gym.V.frmHijos.Usuarios
{
    public partial class frm_Usuarios_Nuevo : Form
    {
        ControladorUsuarios controlador = new ControladorUsuarios();
        private EntUsuario usuarioAct;
        private bool nuevoUs;
        public frm_Usuarios_Nuevo()
        {
            InitializeComponent();
            nuevoUs = true;
        }

        public frm_Usuarios_Nuevo(EntUsuario usuario)
        {
            InitializeComponent();
            nuevoUs = false;
            usuarioAct = usuario;
        }

        private void frm_Usuarios_Nuevo_Load(object sender, EventArgs e)
        {
            if(nuevoUs =! true)
            {
                CargarDatosEnControles(usuarioAct);
            }
        }

        private void btn_Guardar_UsuariosNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txt_Nombre_ClientesNuevo.Text;
                string apellido = txt_Apellido_ClientesNuevo.Text;
                string dni = txt_DNI_ClientesNuevo.Text;
                string telefono = txt_Telefono_ClientesNuevo.Text;
                string email = txt_Email_ClientesNuevo.Text;
                

                bool resultado;

                if (nuevoUs)
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

        private void CargarDatosEnControles(EntUsuario usuario)
        {
            txt_Nombre_UsuariosNuevo.Text = usuario.Nombre;
            txt_Apellido_UsuariosNuevo.Text = usuario.Apellido;
            txt_DNI_UsuariosNuevo.Text = usuario.DNI;
            txt_Telefono_UsuariosNuevo.Text = usuario.Telefono;
            txt_Email_UsuariosNuevo.Text = usuario.Email;
            txt_Usuario_UsuariosNuevo.Text = usuario.NomUsuario;
            txt_Contraseña_UsuariosNuevo.Text = usuario.Contraseña.ToString();
            txt_Descripcion_UsuariosNuevo.Text = usuario.Descripcion;
        }
    }
}
