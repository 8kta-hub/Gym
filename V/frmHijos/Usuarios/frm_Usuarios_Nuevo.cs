using Gym.C;
using Gym.M.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Usuarios
{
    public partial class frm_Usuarios_Nuevo : Form
    {
        ControladorUsuarios controlador = new ControladorUsuarios();
        ControladorRoles controladorRoles = new ControladorRoles();
        private Usuario usuarioActual;
        private bool nuevoUs;

        public frm_Usuarios_Nuevo()
        {
            InitializeComponent();
            nuevoUs = true;
        }

        public frm_Usuarios_Nuevo(Usuario usuario)
        {
            InitializeComponent();
            nuevoUs = false;
            usuarioActual = usuario;
        }

        private void frm_Usuarios_Nuevo_Load(object sender, EventArgs e)
        {
            // Cargar horas en combos de horario (00:00 a 23:00)
            for (int h = 0; h <= 23; h++)
            {
                string hora = h.ToString("D2") + ":00";
                cmb_HorarioInicio_UsuariosNuevo.Items.Add(hora);
                cmb_HorarioFin_UsuariosNuevo.Items.Add(hora);
            }
            cmb_HorarioInicio_UsuariosNuevo.SelectedIndex = 0;
            cmb_HorarioFin_UsuariosNuevo.SelectedIndex = 0;

            // Cargar roles en el combo
            DataTable roles = controladorRoles.ObtenerRolesParaCombo();
            cmb_Rol_UsuariosNuevo.DataSource = roles;
            cmb_Rol_UsuariosNuevo.DisplayMember = "nombre";
            cmb_Rol_UsuariosNuevo.ValueMember = "id_rol";
            cmb_Rol_UsuariosNuevo.SelectedIndex = 0;

            if (nuevoUs)
            {
                // Alta: activo por defecto, no se puede cambiar
                chk_Activo_UsuariosNuevo.Checked = true;
                chk_Activo_UsuariosNuevo.Enabled = false;
                txt_Contrasena_UsuariosNuevo.Enabled = true;
                cmb_Rol_UsuariosNuevo.Visible = true;
            }
            else
            {
                // Edición: se puede cambiar activo, contraseña no se muestra
                chk_Activo_UsuariosNuevo.Enabled = true;
                txt_Contrasena_UsuariosNuevo.Enabled = false;
                txt_Contrasena_UsuariosNuevo.Text = string.Empty;
                cmb_Rol_UsuariosNuevo.Visible = false;
                CargarDatosEnControles(usuarioActual);
            }
        }

        private void btn_Guardar_UsuariosNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txt_Nombre_UsuariosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre");
                    txt_Nombre_UsuariosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Apellido_UsuariosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un apellido");
                    txt_Apellido_UsuariosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_DNI_UsuariosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un DNI");
                    txt_DNI_UsuariosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Email_UsuariosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un email");
                    txt_Email_UsuariosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Usuario_UsuariosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre de usuario");
                    txt_Usuario_UsuariosNuevo.Focus();
                    return;
                }

                if (nuevoUs && string.IsNullOrWhiteSpace(txt_Contrasena_UsuariosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar una contraseña");
                    txt_Contrasena_UsuariosNuevo.Focus();
                    return;
                }

                int horaInicio = cmb_HorarioInicio_UsuariosNuevo.SelectedIndex;
                int horaFin = cmb_HorarioFin_UsuariosNuevo.SelectedIndex;

                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("El horario de fin debe ser mayor al horario de inicio");
                    cmb_HorarioFin_UsuariosNuevo.Focus();
                    return;
                }

                string nombre = txt_Nombre_UsuariosNuevo.Text.Trim();
                string apellido = txt_Apellido_UsuariosNuevo.Text.Trim();
                string dni = txt_DNI_UsuariosNuevo.Text.Trim();
                string telefono = txt_Telefono_UsuariosNuevo.Text.Trim();
                string email = txt_Email_UsuariosNuevo.Text.Trim();
                string usuario = txt_Usuario_UsuariosNuevo.Text.Trim();
                string descripcion = txt_Descripcion_UsuariosNuevo.Text.Trim();
                TimeSpan tsInicio = TimeSpan.FromHours(horaInicio);
                TimeSpan tsFin = TimeSpan.FromHours(horaFin);
                bool resultado;

                if (nuevoUs)
                {
                    string contrasena = txt_Contrasena_UsuariosNuevo.Text;
                    int idRol = (int)cmb_Rol_UsuariosNuevo.SelectedValue;

                    resultado = controlador.InsertarUsuario(
                        nombre, apellido, dni, telefono, email,
                        usuario, contrasena, idRol, tsInicio, tsFin, descripcion
                    );
                }
                else
                {
                    resultado = controlador.UpdateUsuario(
                        usuarioActual.IdUsuario,
                        nombre, apellido, dni, telefono, email,
                        usuario, tsInicio, tsFin, descripcion,
                        chk_Activo_UsuariosNuevo.Checked
                    );
                }

                if (resultado)
                {
                    MessageBox.Show("Usuario guardado correctamente");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el usuario");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarDatosEnControles(Usuario usuario)
        {
            txt_Nombre_UsuariosNuevo.Text = usuario.Nombre;
            txt_Apellido_UsuariosNuevo.Text = usuario.Apellido;
            txt_DNI_UsuariosNuevo.Text = usuario.Dni;
            txt_Telefono_UsuariosNuevo.Text = usuario.Telefono;
            txt_Email_UsuariosNuevo.Text = usuario.Email;
            txt_Usuario_UsuariosNuevo.Text = usuario.NombreUsuario;
            txt_Descripcion_UsuariosNuevo.Text = usuario.Descripcion;
            chk_Activo_UsuariosNuevo.Checked = usuario.Activo;

            cmb_HorarioInicio_UsuariosNuevo.SelectedIndex = (int)usuario.HorarioInicio.TotalHours;
            cmb_HorarioFin_UsuariosNuevo.SelectedIndex = (int)usuario.HorarioFin.TotalHours;
        }
    }
}