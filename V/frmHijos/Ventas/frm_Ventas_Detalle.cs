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

namespace Gym.V.frmHijos.Ventas
{
    public partial class frm_Ventas_Detalle : Form
    {
        private ControladorVentas controlador = new ControladorVentas();
        private Operacion ventaActual;
        public frm_Ventas_Detalle(Operacion venta)
        {
            InitializeComponent();
            ventaActual = venta;
        }

        private void frm_Ventas_Detalle_Load(object sender, EventArgs e)
        {
            CargarDatosVentas();
            CargarDetalle();
        }

        private void CargarDatosVentas()
        {
            lbl_Cliente_VentasDetalle.Text = ventaActual.NombreCliente;
            lbl_Fecha_VentasDetalle.Text = ventaActual.Fecha.ToShortDateString();
            lbl_Usuario_VentasDetalle.Text = ventaActual.NombreUsuario;
            lbl_Total_VentasDetalle.Text = "$" + ventaActual.Total.ToString("N2");
        }

        private void CargarDetalle()
        {
            controlador.ObtenerDetalleVenta(ventaActual.IdOperacion, dgv_VentasDetalle);

            dgv_VentasDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_VentasDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_VentasDetalle.MultiSelect = false;
            dgv_VentasDetalle.ReadOnly = true;
            dgv_VentasDetalle.ClearSelection();
        }
    }
}
