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
            CargarComboTipoMovimientos();
            CargarComboInventario();

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
            CargarTotalVentas();
            CargarReportesMovimientos();
            CargarReportesVisitas();
            CargarTotalVisitas();
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

        private void btn_Buscar_ReportesRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = dtp_FechaInicial_ReportesRegistro.Value.Date;
                DateTime fechaFinal = dtp_FechaFinal_ReportesRegistro.Value.Date.AddDays(1);

                controlador.BuscarRegistrosPorFechas(fechaInicial, fechaFinal, dgv_ReportesRegistro);
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

        private void btn_Buscar_ReportesVisitas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = dtp_FechaInicial_ReportesVisitas.Value.Date;
                DateTime fechaFinal = dtp_FechaFinal_ReportesVisitas.Value.Date.AddDays(1);

                controlador.BuscarVisitasPorFechas(fechaInicial, fechaFinal, dgv_ReportesVisitas);

                CargarTotalVisitasPorFecha(fechaInicial, fechaFinal);
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

        private void btn_Buscar_ReportesVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = dtp_FechaInicial_ReportesVentas.Value.Date;
                DateTime fechaFinal = dtp_FechaFinal_ReportesVentas.Value.Date.AddDays(1);

                controlador.BuscarVentasPorFechas(fechaInicial, fechaFinal, dgv_ReportesVentas);

                CargarTotalVentasPorFecha(fechaInicial, fechaFinal);
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

        private void btn_Buscar_ReportesMovimientos_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicial = dtp_FechaInicial_ReportesMovimientos.Value.Date;
                DateTime fechaFinal = dtp_FechaFinal_ReportesMovimientos.Value.Date.AddDays(1);

                controlador.BuscarMovimientosPorFechas(fechaInicial, fechaFinal, dgv_ReportesMovimientos);
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

        private void CargarTotalVisitas()
        {
            decimal total = controlador.CargarTotalPrecioVisitas();

            lbl_Total_ReportesVisitas.Text = total.ToString("N2");
        }
        private void CargarTotalVisitasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            decimal total = controlador.CargarTotalPrecioVisitasPorFecha(fechaInicial, fechaFinal);

            lbl_Total_ReportesVisitas.Text = total.ToString("N2");
        }

        private void CargarTotalVentas()
        {
            decimal total = controlador.CargarTotalPrecioVentas();

            lbl_Total_ReportesVentas.Text = total.ToString("N2");
        }
        private void CargarTotalVentasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            decimal total = controlador.CargarTotalPrecioVentasPorFecha(fechaInicial, fechaFinal);

            lbl_Total_ReportesVentas.Text = total.ToString("N2");
        }

        private void CargarComboTipoMovimientos()
        {
            cmb_Tipo_ReportesMovimientos.Items.Add("Todos");
            cmb_Tipo_ReportesMovimientos.Items.Add("Ingreso");
            cmb_Tipo_ReportesMovimientos.Items.Add("Egreso");
            cmb_Tipo_ReportesMovimientos.SelectedIndex = 0;
        }

        private void cmb_Tipo_ReportesMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = cmb_Tipo_ReportesMovimientos.SelectedItem.ToString();
            controlador.CargarMovimientosFiltrados(tipoSeleccionado, dgv_ReportesMovimientos);
        }

        private void CargarComboInventario()
        {
            cmb_Filtro_ReportesInventario.Items.Add("Todos");
            cmb_Filtro_ReportesInventario.Items.Add("Activo");
            cmb_Filtro_ReportesInventario.Items.Add("Inactivo");
            cmb_Filtro_ReportesInventario.SelectedIndex = 0;
        }

        private void cmb_Filtro_ReportesInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = cmb_Filtro_ReportesInventario.SelectedItem.ToString();
            controlador.CargarInventarioFiltrado(tipoSeleccionado, dgv_ReportesInventario);
        }

        private void dtp_FechaInicial_ReportesMembresias_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaFinal_ReportesMembresias.MinDate = dtp_FechaInicial_ReportesMembresias.Value;
        }

        private void dtp_FechaInicial_ReportesRegistro_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaFinal_ReportesRegistro.MinDate = dtp_FechaInicial_ReportesRegistro.Value;
        }

        private void dtp_FechaInicial_ReportesVisitas_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaFinal_ReportesVisitas.MinDate = dtp_FechaInicial_ReportesVisitas.Value;
        }

        private void dtp_FechaInicial_ReportesVentas_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaFinal_ReportesVentas.MinDate = dtp_FechaInicial_ReportesVentas.Value;
        }

        private void dtp_FechaInicial_ReportesMovimientos_ValueChanged(object sender, EventArgs e)
        {
            dtp_FechaFinal_ReportesMovimientos.MinDate = dtp_FechaInicial_ReportesMovimientos.Value;
        }

        
    }
}
