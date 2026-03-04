using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.M;
using Gym.C;
using Gym.M.Entidades;
using Gym.V.Login;
using Gym.V.FuncionesV;

namespace Gym.V
{
    public partial class frm_Login : Form
    {
        ConDB conexion = new ConDB();
        ControladorLogin controlador = new ControladorLogin();
        private bool mostrarContraseña = false;
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            txt_Usuario_Login.Select();
        }

        private void btn_Acceder_Login_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txt_Usuario_Login.Text))
                {
                    MessageBox.Show(
                        "Por favor, asegúrese que el nombre esté completo y solo contenga letras y números.",
                        "Nombre Incorrecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Contraseña_Login.Text) || txt_Contraseña_Login.Text.Length >= 16)
                {
                    MessageBox.Show(
                        "Por favor, asegúrese que la contraseña esté completa y no sea mayor a 16 caracteres.",
                        "Contraseña Incorrecta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                string usuarioIngresado = txt_Usuario_Login.Text.Trim();
                string contraseñaIngresada = txt_Contraseña_Login.Text;
                byte [] contraseñaHasheada = controlador.GenerarHash(contraseñaIngresada);

                bool loginCorrecto = controlador.ConfirmarUsuarioContraseña(usuarioIngresado, contraseñaHasheada);

                if(loginCorrecto == true)
                {
                    MessageBox.Show("¡Accedió correctamente!", "Acceso Permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frm_Principal menu = new frm_Principal(usuarioIngresado, this);
                    menu.Show();
                    this.Hide();

                    txt_Usuario_Login.Clear();
                    txt_Contraseña_Login.Clear();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Usuario_Login.Clear();
                    txt_Contraseña_Login.Clear();
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

        private void lbl_OlvidarContraseña_Login_Click(object sender, EventArgs e)
        {
            frm_RecuperarPass frmNuevo = new frm_RecuperarPass();
            Funciones.abrirFormModal(frmNuevo,this);
            LimpiarCamposLogin();
        }

        private void btn_MostrarContraseña_Login_Click(object sender, EventArgs e)
        {
            mostrarContraseña = !mostrarContraseña;

            if (mostrarContraseña)
            {
                txt_Contraseña_Login.PasswordChar = '\0';
                btn_MostrarContraseña_Login.BackgroundImage = Gym.Properties.Resources.hide;
            }
            else
            {
                txt_Contraseña_Login.PasswordChar = '*';
                btn_MostrarContraseña_Login.BackgroundImage = Gym.Properties.Resources.show;
            }
        }

        private void LimpiarCamposLogin()
        {
            txt_Usuario_Login.Clear();
            txt_Contraseña_Login.Clear();
            txt_Usuario_Login.Focus();
        }
    }
}
