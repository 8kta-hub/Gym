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

namespace Gym.V
{
    public partial class frm_Login : Form
    {
        ConDB conexion = new ConDB();
        ControladorLogin controlador = new ControladorLogin();
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            txt_Usuario_Login.Select();

            txt_Usuario_Login.Multiline = false;
            txt_Contraseña_Login.Multiline = false;
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

                if (string.IsNullOrWhiteSpace(txt_Contraseña_Login.Text) && txt_Contraseña_Login.Text.Length <= 16)
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
                string contraseñaHasheada = controlador.GenerarHash(contraseñaIngresada);
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
    }
}
