using Gym.V.frmHijos.Usuarios;
using Gym.V.FuncionesV;
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

namespace Gym.V.frmHijos.Roles
{
    public partial class frm_Roles : Form
    {
        private ControladorRoles controlador = new ControladorRoles();

        public frm_Roles()
        {
            InitializeComponent();
        }

        private void frm_Roles_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void btn_Nuevo_Roles_Click(object sender, EventArgs e)
        {
            frm_Roles_Nuevo frmNuevo = new frm_Roles_Nuevo();
            if (Funciones.abrirFormModal(frmNuevo, this) == DialogResult.OK)
                CargarRoles();
        }

        private void btn_Modificar_Roles_Click(object sender, EventArgs e)
        {
            Rol seleccionado = CargarRolSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un rol para modificar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (seleccionado.Nombre == "Administrador")
            {
                MessageBox.Show("El rol Administrador no puede modificarse.", "Acción no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_Roles_Nuevo frmEdicion = new frm_Roles_Nuevo(seleccionado);
            if (Funciones.abrirFormModal(frmEdicion, this) == DialogResult.OK)
                CargarRoles();
        }

        private void btn_Eliminar_Roles_Click(object sender, EventArgs e)
        {
            Rol seleccionado = CargarRolSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un rol para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (seleccionado.Nombre == "Administrador")
            {
                MessageBox.Show("El rol Administrador no puede eliminarse.", "Acción no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Desea eliminar el rol \"{seleccionado.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool ok = controlador.DeleteRol(seleccionado.IdRol);
                MessageBox.Show(
                    ok ? "Rol eliminado correctamente." : "No se pudo eliminar el rol.",
                    ok ? "Éxito" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ok) CargarRoles();
            }
        }

        private Rol CargarRolSeleccionado()
        {
            if (dgv_Roles.CurrentRow == null) return null;
            if (dgv_Roles.SelectedRows.Count == 0) return null;

            DataGridViewRow fila = dgv_Roles.SelectedRows[0];

            return new Rol
            {
                IdRol = Convert.ToInt32(fila.Cells["id_rol"].Value),
                Nombre = fila.Cells["nombre"].Value?.ToString() ?? "",
                Permiso = fila.Cells["permiso"].Value?.ToString() ?? "",
                Descripcion = fila.Cells["descripcion"].Value?.ToString() ?? "",
                Activo = true
            };
        }

        private void CargarRoles()
        {
            controlador.ListarRoles(dgv_Roles);
            dgv_Roles.Columns["id_rol"].Visible = false;
        }

        private void dgv_Roles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Roles.ClearSelection();
        }


        //private void btn_ExportarExcel_Roles_Click(object sender, EventArgs e)
        //{
        //    if (dgv_Roles.Rows.Count == 0)
        //    {
        //        MessageBox.Show("No hay datos para exportar.", "Aviso",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        SaveFileDialog sfd = new SaveFileDialog();
        //        sfd.Filter = "Excel (*.xlsx)|*.xlsx";
        //        sfd.FileName = "Roles_" + DateTime.Now.ToString("yyyyMMdd");

        //        if (sfd.ShowDialog() != DialogResult.OK) return;

        //        // Construir CSV compatible con Excel si no hay librería externa,
        //        // o usar la exportación estándar del proyecto si ya existe un helper.
        //        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
        //        {
        //            // Encabezados
        //            for (int c = 0; c < dgv_Roles.Columns.Count; c++)
        //            {
        //                if (!dgv_Roles.Columns[c].Visible) continue;
        //                sw.Write(dgv_Roles.Columns[c].HeaderText);
        //                if (c < dgv_Roles.Columns.Count - 1) sw.Write("\t");
        //            }
        //            sw.WriteLine();

        //            // Filas
        //            foreach (DataGridViewRow fila in dgv_Roles.Rows)
        //            {
        //                for (int c = 0; c < dgv_Roles.Columns.Count; c++)
        //                {
        //                    if (!dgv_Roles.Columns[c].Visible) continue;
        //                    sw.Write(fila.Cells[c].Value?.ToString() ?? "");
        //                    if (c < dgv_Roles.Columns.Count - 1) sw.Write("\t");
        //                }
        //                sw.WriteLine();
        //            }
        //        }

        //        MessageBox.Show("Exportación completada.", "Éxito",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al exportar: " + ex.Message, "Error",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
