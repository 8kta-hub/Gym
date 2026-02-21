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
        ControladorUsuarios controlador = new ControladorUsuarios();

        public frm_Usuarios()
        {
            InitializeComponent();
        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show("Seleccione un usuario");
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
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea deshabilitar este usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteUsuario(usuario.IdUsuario);

                if (resultado)
                {
                    MessageBox.Show("Usuario deshabilitado correctamente");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo deshabilitar el usuario");
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
            if (dgv_Usuarios.SelectedRows.Count == 0)
                return null;

            DataGridViewRow fila = dgv_Usuarios.SelectedRows[0];

            Usuario usuario = new Usuario
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

            return usuario;
        }

        private void CargarUsuarios()
        {
            controlador.ListarUsuarios(dgv_Usuarios);

            dgv_Usuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Usuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Usuarios.MultiSelect = false;
            dgv_Usuarios.ReadOnly = true;

            dgv_Usuarios.Columns["id_usuario"].Visible = false;
        }

        private void dgv_Usuarios_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Usuarios.ClearSelection();
        }
    }
}