using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.C;

namespace Gym.V.frmHijos.Reporte
{
    public partial class frm_Reportes : Form
    {
        ControladorReportes controlador = new ControladorReportes();

        public frm_Reportes()
        {
            InitializeComponent();
        }

        private void frm_Reportes_Load(object sender, EventArgs e)
        {
            ConfigurarRangoFechas(dtp_FechaInicial_ReportesMembresias, dtp_FechaFinal_ReportesMembresias);
            ConfigurarRangoFechas(dtp_FechaInicial_ReportesRegistro, dtp_FechaFinal_ReportesRegistro);
            ConfigurarRangoFechas(dtp_FechaInicial_ReportesVisitas, dtp_FechaFinal_ReportesVisitas);
            ConfigurarRangoFechas(dtp_FechaInicial_ReportesVentas, dtp_FechaFinal_ReportesVentas);
            ConfigurarRangoFechas(dtp_FechaInicial_ReportesMovimientos, dtp_FechaFinal_ReportesMovimientos);

            CargarReportesInventario();
            CargarReportesMembresias();
            CargarTotalMembresias();
            CargarReportesClientes();
            CargarReportesRegistros();
            CargarReportesVentas();
            CargarReportesMovimientos();
            CargarReportesVisitas();
        }

        private void btn_Buscar_ReportesMembresias_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = dtp_FechaInicial_ReportesMembresias.Value.Date;
                DateTime fechaFinal = dtp_FechaFinal_ReportesMembresias.Value.Date.AddDays(1);

                controlador.BuscarMembresiasPorFechas(fechaInicial, fechaFinal, dgv_ReportesMembresias);

                CargarTotalMembresiasPorFecha(fechaInicial, fechaFinal); 
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


        private void CargarReportesInventario()
        {
            controlador.ListarReportesInventario(dgv_ReportesInventario);

            dgv_ReportesInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesInventario.MultiSelect = false;
            dgv_ReportesInventario.ReadOnly = true;
        }

        private void CargarReportesMembresias()
        {
            controlador.ListarReportesMembresias(dgv_ReportesMembresias);

            dgv_ReportesMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesMembresias.MultiSelect = false;
            dgv_ReportesMembresias.ReadOnly = true;
        }

        private void CargarReportesClientes()
        {
            controlador.ListarReportesClientes(dgv_ReportesClientes);

            dgv_ReportesClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesClientes.MultiSelect = false;
            dgv_ReportesClientes.ReadOnly = true;
        }

        private void CargarReportesRegistros()
        {
            controlador.ListarReportesRegistros(dgv_ReportesRegistro);

            dgv_ReportesRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesRegistro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesRegistro.MultiSelect = false;
            dgv_ReportesRegistro.ReadOnly = true;
        }

        private void CargarReportesVentas()
        {
            controlador.ListarReportesVentas(dgv_ReportesVentas);

            dgv_ReportesVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesVentas.MultiSelect = false;
            dgv_ReportesVentas.ReadOnly = true;
        }

        private void CargarReportesMovimientos()
        {
            controlador.ListarReportesMovimientos(dgv_ReportesMovimientos);

            dgv_ReportesMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesMovimientos.MultiSelect = false;
            dgv_ReportesMovimientos.ReadOnly = true;
        }

        private void CargarReportesVisitas()
        {
            controlador.ListarReportesVisitas(dgv_ReportesVisitas);

            dgv_ReportesVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ReportesVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ReportesVisitas.MultiSelect = false;
            dgv_ReportesVisitas.ReadOnly = true;
        }

        private void ConfigurarRangoFechas(DateTimePicker dtpInicial, DateTimePicker dtpFinal)
        {
            dtpInicial.Format = DateTimePickerFormat.Short;
            dtpFinal.Format = DateTimePickerFormat.Short;

            dtpInicial.MaxDate = DateTime.Today;
            dtpFinal.MaxDate = DateTime.Today;

            dtpFinal.Value = DateTime.Today;
            dtpInicial.Value = DateTime.Today.AddDays(-7);
        }

        private void CargarTotalMembresias()
        {
            decimal total = controlador.CargarTotalPrecioMembresias();

            lbl_Total_ReportesMembresias.Text = total.ToString("N2");
        }
        private void CargarTotalMembresiasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            decimal total = controlador.CargarTotalPrecioMembresiasPorFecha(fechaInicial, fechaFinal);

            lbl_Total_ReportesMembresias.Text = total.ToString("N2");
        }

        private void dtp_FechaInicial_ReportesMembresias_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaFinal_ReportesMembresias.MinDate = dtp_FechaInicial_ReportesMembresias.Value;
        }
    }
}
