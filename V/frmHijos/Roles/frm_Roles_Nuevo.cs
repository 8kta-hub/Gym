using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.C;
using Gym.M.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gym.V.frmHijos.Roles
{
    public partial class frm_Roles_Nuevo : Form
    {
        private ControladorRoles controlador = new ControladorRoles();
        private Rol rolActual;
        private bool _esAlta;

        // Lista fija de permisos disponibles en el sistema
        private static readonly string[] PERMISOS_DISPONIBLES = new[]
        {
            "Clientes",
            "Membresías",
            "Productos",
            "Proveedores",
            "Operaciones",
            "Compras",
            "Caja",
            "Corte de Caja",
            "Usuarios",
            "Roles",
            "Reportes"
        };

        // ── Constructor alta ──────────────────────────────────────
        public frm_Roles_Nuevo()
        {
            InitializeComponent();
            _esAlta = true;
        }

        // ── Constructor edición ───────────────────────────────────
        public frm_Roles_Nuevo(Rol rol)
        {
            InitializeComponent();
            rolActual = rol;
            _esAlta = false;
        }

        // ─────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────
        private void frm_Roles_Nuevo_Load(object sender, EventArgs e)
        {
            CargarPermisos();

            if (_esAlta)
            {
                this.Text = "Nuevo rol";
                chk_RolActivo.Checked = true;
                chk_RolActivo.Enabled = false;   // en alta siempre activo, no se puede cambiar
            }
            else
            {
                this.Text = "Modificar rol";
                chk_RolActivo.Enabled = true;
                CargarDatosEnControles(rolActual);
            }
        }

        // ─────────────────────────────────────────
        // CARGAR CHECKBOXES DE PERMISOS
        // ─────────────────────────────────────────
        private void CargarPermisos()
        {
            foreach (string permiso in PERMISOS_DISPONIBLES)
            {
                clb_Permisos_RolesNuevo.Items.Add(permiso);
            }
        }

        // ─────────────────────────────────────────
        // GUARDAR
        // ─────────────────────────────────────────
        private void btn_Guardar_RolesNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Nombre_RolesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre para el rol");
                    txt_Nombre_RolesNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Descripcion_RolesNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar una descripcion para el rol");
                    txt_Descripcion_RolesNuevo.Focus();
                    return;
                }

                string nombre = txt_Nombre_RolesNuevo.Text.Trim();
                var permisos = ObtenerPermisosSeleccionados();
                string permisosSeleccionados = string.Join(",", permisos);
                string descripcion = txt_Descripcion_RolesNuevo.Text.Trim();
                bool activo = true;
                bool resultado;

                if (_esAlta)
                {
                    resultado = controlador.InsertRol(nombre, permisosSeleccionados, descripcion, activo);
                }
                else
                {
                    // UPDATE
                    resultado = controlador.UpdateRol(rolActual.IdRol, nombre, permisosSeleccionados, descripcion,activo);
                }

                if (resultado)
                {
                    MessageBox.Show("Rol guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ─────────────────────────────────────────
        // OBTENER PERMISOS SELECCIONADOS
        // ─────────────────────────────────────────
        private List<string> ObtenerPermisosSeleccionados()
        {
            List<string> seleccionados = new List<string>();

            foreach (var item in clb_Permisos_RolesNuevo.CheckedItems)
            {
                seleccionados.Add(item.ToString());
            }

            return seleccionados;
        }

        // ─────────────────────────────────────────
        // CARGAR DATOS EN CONTROLES (edición)
        // ─────────────────────────────────────────
        private void CargarDatosEnControles(Rol rol)
        {
            txt_Nombre_RolesNuevo.Text = rol.Nombre;
            chk_RolActivo.Checked = rol.Activo;

            if (!string.IsNullOrEmpty(rol.Permiso))
            {
                string[] permisosGuardados = rol.Permiso
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim())
                    .ToArray();

                // Primero desmarcamos todo (por seguridad)
                for (int i = 0; i < clb_Permisos_RolesNuevo.Items.Count; i++)
                {
                    clb_Permisos_RolesNuevo.SetItemChecked(i, false);
                }

                // Ahora marcamos los que estén guardados
                for (int i = 0; i < clb_Permisos_RolesNuevo.Items.Count; i++)
                {
                    string item = clb_Permisos_RolesNuevo.Items[i].ToString();

                    if (permisosGuardados.Contains(item))
                    {
                        clb_Permisos_RolesNuevo.SetItemChecked(i, true);
                    }
                }
            }
        }
    }
}
