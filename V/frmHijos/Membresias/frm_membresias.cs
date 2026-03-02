using Gym.C;
using Gym.M.Entidades;
using Gym.V.FuncionesV;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos
{
    public partial class frm_membresias : Form
    {
        ControladorMembresias controlador = new ControladorMembresias();

        public frm_membresias()
        {
            InitializeComponent();
        }

        private void frm_membresias_Load(object sender, EventArgs e)
        {
            CargarMembresias();
        }

        private void btn_Nuevo_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Nuevo frm = new frm_Membresias_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarMembresias();
            }
        }

        private void btn_Modificar_Membresias_Click(object sender, EventArgs e)
        {
            Membresia membresia = CargarMembresiaSeleccionada();

            if (membresia == null)
            {
                MessageBox.Show("Seleccione una membresía");
                return;
            }

            frm_Membresias_Nuevo frm = new frm_Membresias_Nuevo(membresia);

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarMembresias();
            }
        }

        private void btn_Eliminar_Membresias_Click(object sender, EventArgs e)
        {
            Membresia membresia = CargarMembresiaSeleccionada();

            if (membresia == null)
            {
                MessageBox.Show("Seleccione una membresía");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea eliminar esta membresía?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteMembresia(membresia.IdMembresia);

                if (resultado)
                {
                    MessageBox.Show("Membresía eliminada correctamente");
                    CargarMembresias();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la membresía");
                }
            }
        }

        private void btn_Horarios_Membresias_Click(object sender, EventArgs e)
        {
            Membresia membresia = CargarMembresiaSeleccionada();

            if (membresia == null)
            {
                MessageBox.Show("Seleccione una membresía para ver sus horarios");
                return;
            }

            frm_Membresias_Horarios frm = new frm_Membresias_Horarios(membresia);

            Funciones.abrirFormModal(frm, this);
        }

        private Membresia CargarMembresiaSeleccionada()
        {
            if (dgv_Membresias.SelectedRows.Count == 0)
                return null;

            DataGridViewRow fila = dgv_Membresias.SelectedRows[0];

            Membresia membresia = new Membresia
            {
                IdMembresia = Convert.ToInt32(fila.Cells["id_membresias"].Value),
                Nombre = fila.Cells["nombre"].Value.ToString(),
                Precio = Convert.ToDecimal(fila.Cells["precio"].Value),
                Tipo = fila.Cells["tipo"].Value.ToString(),
                CantidadMsd = Convert.ToInt32(fila.Cells["cantidad_msd"].Value),
                Activo = Convert.ToBoolean(fila.Cells["activo"].Value)
            };

            return membresia;
        }

        private void CargarMembresias()
        {
            controlador.ListarMembresias(dgv_Membresias);

            dgv_Membresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Membresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Membresias.MultiSelect = false;
            dgv_Membresias.ReadOnly = true;

            dgv_Membresias.Columns["id_membresias"].Visible = false;
        }

        private void dgv_Membresias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Membresias.ClearSelection();
        }
    }
}