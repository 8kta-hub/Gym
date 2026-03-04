using Gym.C;
using Gym.M.Entidades;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gym.V.frmHijos
{
    public partial class frm_Inicio : Form
    {
        private ControladorInicio controlador = new ControladorInicio();
        private Usuario usuarioActual;
        private System.Windows.Forms.Timer timerReloj;

        public frm_Inicio(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frm_Inicio_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            CargarFechaHora();
            IniciarReloj();
            CargarEntradasDia();
        }

        private void btn_informacion_inicio_Click(object sender, EventArgs e)
        {
            int entradas = controlador.ContarEntradasHoy();
            MessageBox.Show(
                $"Entradas registradas hoy: {entradas}",
                "Información del día",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ── HELPERS ──────────────────────────────────────────

        private void CargarDatosUsuario()
        {
            if (usuarioActual == null) return;

            lbl_nombreUsuairo.Text = usuarioActual.Nombre;
            lbl_apellidUsuairo.Text = usuarioActual.Apellido;
            lbl_rolUsuairo.Text = usuarioActual.Rol ?? "-";

            // Foto: si tiene, mostrarla; si no, mantener la imagen por defecto del Designer
            if (usuarioActual.Foto != null && usuarioActual.Foto.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(usuarioActual.Foto))
                    {
                        pic_Usuario_Inicio.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    // Si la foto está corrupta, deja la imagen por defecto
                }
            }
        }

        private void CargarFechaHora()
        {
            lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void IniciarReloj()
        {
            timerReloj = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick += (s, ev) =>
            {
                lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
                lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            };
            timerReloj.Start();
        }

        private void CargarEntradasDia()
        {
            controlador.ListarEntradasDia(dvg_EntradasDia);

            dvg_EntradasDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvg_EntradasDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvg_EntradasDia.MultiSelect = false;
            dvg_EntradasDia.ReadOnly = true;
            dvg_EntradasDia.ClearSelection();
        }
    }
}