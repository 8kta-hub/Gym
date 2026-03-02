using Gym.C;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Usuarios
{
    public partial class frm_Usuarios_Roles : Form
    {
        ControladorRoles controlador = new ControladorRoles();

        public frm_Usuarios_Roles()
        {
            InitializeComponent();
        }

        private void frm_Usuarios_Roles_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataTable roles = controlador.ObtenerRolesParaCombo();

            cmb_Nombre_UsuariosRoles.DataSource = roles;
            cmb_Nombre_UsuariosRoles.DisplayMember = "nombre";
            cmb_Nombre_UsuariosRoles.ValueMember = "id_rol";
            cmb_Nombre_UsuariosRoles.SelectedIndex = -1;
        }

        private void cmb_Nombre_UsuariosRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Nombre_UsuariosRoles.SelectedItem == null)
                return;

            flp_Permisos_UsuariosRoles.Controls.Clear();

            // El permiso ya está en la fila seleccionada del combo, no hace falta otra consulta
            DataRowView fila = (DataRowView)cmb_Nombre_UsuariosRoles.SelectedItem;
            string permisos = fila["permiso"].ToString();

            foreach (string permiso in permisos.Split(','))
            {
                CheckBox chk = new CheckBox
                {
                    Text = permiso.Trim(),
                    Checked = true,
                    Width = 240,
                    Margin = new System.Windows.Forms.Padding(5)
                };
                flp_Permisos_UsuariosRoles.Controls.Add(chk);
            }
        }

        private void btn_Guardar_UsuariosRoles_Click(object sender, EventArgs e)
        {
            if (cmb_Nombre_UsuariosRoles.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un rol");
                cmb_Nombre_UsuariosRoles.Focus();
                return;
            }

            string permisosSeleccionados = string.Empty;

            foreach (Control ctrl in flp_Permisos_UsuariosRoles.Controls)
            {
                if (ctrl is CheckBox chk && chk.Checked)
                {
                    if (!string.IsNullOrEmpty(permisosSeleccionados))
                        permisosSeleccionados += ",";
                    permisosSeleccionados += chk.Text;
                }
            }

            if (string.IsNullOrEmpty(permisosSeleccionados))
            {
                MessageBox.Show("Debe seleccionar al menos un permiso");
                return;
            }

            int idRol = (int)cmb_Nombre_UsuariosRoles.SelectedValue;
            bool resultado = controlador.UpdatePermisosRol(idRol, permisosSeleccionados);

            if (resultado)
            {
                MessageBox.Show("Permisos guardados correctamente");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se pudieron guardar los permisos");
            }
        }
    }
}