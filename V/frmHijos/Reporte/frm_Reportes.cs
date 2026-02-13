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
            CargarReportesInventario();
            CargarReportesMembresias();
            CargarReportesClientes();
            CargarReportesRegistros();
            CargarReportesVentas();
            CargarReportesMovimientos();
            CargarReportesVisitas();
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
    }
}
