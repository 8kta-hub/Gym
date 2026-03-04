using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.V.FuncionesV;
using Gym.C;

namespace Gym.V.Login
{
    public partial class frm_RecuperarPass : Form
    {
        ControladorLogin controlador = new ControladorLogin();
        public frm_RecuperarPass()
        {
            InitializeComponent();
        }

        private void btn_Guardar_RecuperarPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Usuario_RecuperarPass.Text))
            {
                MessageBox.Show("Por favor, asegurese que el nombre este completo y solo contenga letras y numeros.", "Nombre Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Documento_RecuperarPass.Text) || txt_Documento_RecuperarPass.Text.Length < 7 || txt_Documento_RecuperarPass.Text.Length > 8)
            {
                MessageBox.Show(
                    "Por favor, asegúrese que el DNI esté completo y no sea menor a 7 ni mayor a 8 caracteres.",
                    "Contraseña Incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_NuevaContraseña_RecuperarPass.Text) || txt_NuevaContraseña_RecuperarPass.Text.Length <= 16)
            {
                MessageBox.Show(
                    "Por favor, asegúrese que la contraseña esté completa y no sea mayor a 16 caracteres.",
                    "Contraseña Incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_ConfirmarContraseña_RecuperarPass.Text) || txt_ConfirmarContraseña_RecuperarPass.Text.Length <= 16)
            {
                MessageBox.Show(
                    "Por favor, asegúrese que la contraseña esté completa y no sea mayor a 16 caracteres.",
                    "Contraseña Incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string usuarioIngresado = txt_Usuario_RecuperarPass.Text;
            string dniIngresado = txt_Documento_RecuperarPass.Text;
            string nuevaContraseñaIngresada = txt_NuevaContraseña_RecuperarPass.Text;
            string nuevaContraseñaHasheada = controlador.GenerarHash(nuevaContraseñaIngresada);
            string confirmarContraseñaIngresada = txt_ConfirmarContraseña_RecuperarPass.Text;

            DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar la contraseña?", "Confirmar contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    string dniDB = controlador.TraerDNI(usuarioIngresado);

                    if (nuevaContraseñaIngresada == confirmarContraseñaIngresada && dniDB == dniIngresado)
                    {
                        MessageBox.Show("Restablecio su contraseña correctamente!!", "Contraseña cambiada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                       controlador.CambiarContraseñas(usuarioIngresado, nuevaContraseñaHasheada);
                       this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Las Contraseñas son distintas y/o la respuesta esta mal!!", "Recuperacion negada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
