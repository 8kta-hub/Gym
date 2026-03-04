using Gym.C;
using Gym.M.Entidades;
using Gym.V.FuncionesV;
using Gym.V.frmHijos.Usuarios;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos
{
    public partial class frm_Usuarios : Form
    {
        private ControladorUsuarios controlador = new ControladorUsuarios();

        public frm_Usuarios()
        {
            InitializeComponent();
        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            CargarFiltro();
            CargarUsuarios();
        }

        private void btn_Nuevo_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios_Nuevo frm = new frm_Usuarios_Nuevo();
            DialogResult resultado = Funciones.abrirFormModal(frm, this);
            if (resultado == DialogResult.OK)
                CargarUsuarios();
        }

        private void btn_Modificiar_Usuarios_Click(object sender, EventArgs e)
        {
            Usuario usuario = CargarUsuarioSeleccionado();

            if (usuario == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Usuarios_Nuevo frm = new frm_Usuarios_Nuevo(usuario);
            DialogResult resultado = Funciones.abrirFormModal(frm, this);
            if (resultado == DialogResult.OK)
                CargarUsuarios();
        }

        private void btn_Eliminar_Usuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = CargarUsuarioSeleccionado();

            if (usuario == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea deshabilitar este usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteUsuario(usuario.IdUsuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario deshabilitado correctamente.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo deshabilitar el usuario.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Roles_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios_Roles frm = new frm_Usuarios_Roles();
            Funciones.abrirFormModal(frm, this);
        }

        private Usuario CargarUsuarioSeleccionado()
        {
            if (dgv_Usuarios.SelectedRows.Count == 0 ||
                dgv_Usuarios.SelectedRows[0].Cells["id_usuario"].Value == null)
                return null;

            DataGridViewRow fila = dgv_Usuarios.SelectedRows[0];

            return new Usuario
            {
                IdUsuario = Convert.ToInt32(fila.Cells["id_usuario"].Value),
                Nombre = fila.Cells["nombre"].Value.ToString(),
                Apellido = fila.Cells["apellido"].Value.ToString(),
                Dni = fila.Cells["dni"].Value.ToString(),
                Telefono = fila.Cells["telefono"].Value.ToString(),
                Email = fila.Cells["email"].Value.ToString(),
                NombreUsuario = fila.Cells["usuario"].Value.ToString(),
                Descripcion = fila.Cells["descripcion"].Value?.ToString(),
                Activo = Convert.ToBoolean(fila.Cells["activo"].Value),
                HorarioInicio = (TimeSpan)fila.Cells["horario_inicio"].Value,
                HorarioFin = (TimeSpan)fila.Cells["horario_fin"].Value
            };
        }

        private void CargarFiltro()
        {
            cmb_FiltroUsuarios.Items.Add("Todos");
            cmb_FiltroUsuarios.Items.Add("Activo");
            cmb_FiltroUsuarios.Items.Add("Inactivo");
            cmb_FiltroUsuarios.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            string busqueda = txt_Buscar_Usuarios.Text.Trim();
            string filtro = cmb_FiltroUsuarios.SelectedItem?.ToString() ?? "Todos";

            controlador.ListarUsuarios(dgv_Usuarios, busqueda, filtro);

            if (dgv_Usuarios.Columns.Contains("id_usuario"))
                dgv_Usuarios.Columns["id_usuario"].Visible = false;
        }

        private void dgv_Usuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Usuarios.ClearSelection();
        }

        private void txt_Buscar_Usuarios_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void cmb_FiltroUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
    }
}