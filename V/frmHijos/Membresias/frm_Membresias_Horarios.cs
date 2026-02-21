using Gym.C;
using Gym.M.Entidades;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos
{
    public partial class frm_Membresias_Horarios : Form
    {
        ControladorMembresias controlador = new ControladorMembresias();
        private Membresia membresiaActual;

        public frm_Membresias_Horarios(Membresia membresia)
        {
            InitializeComponent();
            membresiaActual = membresia;
        }

        private void frm_Membresias_Horarios_Load(object sender, EventArgs e)
        {
            // Cargar días de la semana
            cmb_Dia_MembresiasHorario.Items.Add("Lunes");
            cmb_Dia_MembresiasHorario.Items.Add("Martes");
            cmb_Dia_MembresiasHorario.Items.Add("Miércoles");
            cmb_Dia_MembresiasHorario.Items.Add("Jueves");
            cmb_Dia_MembresiasHorario.Items.Add("Viernes");
            cmb_Dia_MembresiasHorario.Items.Add("Sábado");
            cmb_Dia_MembresiasHorario.Items.Add("Domingo");
            cmb_Dia_MembresiasHorario.SelectedIndex = 0;

            // Cargar horas de 00:00 a 23:00 en ambos combos
            for (int h = 0; h <= 23; h++)
            {
                string hora = h.ToString("D2") + ":00";
                cmb_HorarioInicial_MembresiasHorario.Items.Add(hora);
                cmb_HorarioFinal_MembresiasHorario.Items.Add(hora);
            }

            cmb_HorarioInicial_MembresiasHorario.SelectedIndex = 0;
            cmb_HorarioFinal_MembresiasHorario.SelectedIndex = 0;

            this.Text = $"Horarios - {membresiaActual.Nombre}";

            CargarHorarios();
        }

        private void btn_Agregar_MembresiasHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmb_Dia_MembresiasHorario.Text))
                {
                    MessageBox.Show("Debe seleccionar un día");
                    cmb_Dia_MembresiasHorario.Focus();
                    return;
                }

                if (cmb_HorarioInicial_MembresiasHorario.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un horario inicial");
                    cmb_HorarioInicial_MembresiasHorario.Focus();
                    return;
                }

                if (cmb_HorarioFinal_MembresiasHorario.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un horario final");
                    cmb_HorarioFinal_MembresiasHorario.Focus();
                    return;
                }

                // El índice del combo equivale directamente a la hora (índice 0 = 00:00, índice 8 = 08:00, etc.)
                int horaInicio = cmb_HorarioInicial_MembresiasHorario.SelectedIndex;
                int horaFin = cmb_HorarioFinal_MembresiasHorario.SelectedIndex;

                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("El horario final debe ser mayor al horario inicial");
                    cmb_HorarioFinal_MembresiasHorario.Focus();
                    return;
                }

                string dia = cmb_Dia_MembresiasHorario.Text;
                TimeSpan tsInicio = TimeSpan.FromHours(horaInicio);
                TimeSpan tsFin = TimeSpan.FromHours(horaFin);

                bool resultado = controlador.InsertHorarioMembresia(
                    membresiaActual.IdMembresia, tsInicio, tsFin, dia
                );

                if (resultado)
                {
                    MessageBox.Show("Horario agregado correctamente");
                    CargarHorarios();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el horario");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Eliminar_MembresiasHorario_Click(object sender, EventArgs e)
        {
            if (dgv_MembresiasHorario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un horario a eliminar");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea eliminar este horario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                int idHorario = Convert.ToInt32(dgv_MembresiasHorario.SelectedRows[0].Cells["id_horario"].Value);

                bool resultado = controlador.DeleteHorarioMembresia(idHorario);

                if (resultado)
                {
                    MessageBox.Show("Horario eliminado correctamente");
                    CargarHorarios();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el horario");
                }
            }
        }

        private void CargarHorarios()
        {
            controlador.ListarHorariosMembresia(membresiaActual.IdMembresia, dgv_MembresiasHorario);

            dgv_MembresiasHorario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_MembresiasHorario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_MembresiasHorario.MultiSelect = false;
            dgv_MembresiasHorario.ReadOnly = true;

            if (dgv_MembresiasHorario.Columns.Contains("id_horario"))
                dgv_MembresiasHorario.Columns["id_horario"].Visible = false;
        }

        private void dgv_MembresiasHorario_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_MembresiasHorario.ClearSelection();
        }
    }
}