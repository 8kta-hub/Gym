using Gym.C;
using Gym.M.Entidades;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Compras
{
    public partial class frm_Compras_Detalle : Form
    {
        private ControladoarCompras controlador = new ControladoarCompras();
        private Compra compraActual;

        public frm_Compras_Detalle(Compra compra)
        {
            InitializeComponent();
            compraActual = compra;
        }

        private void frm_Compras_Detalle_Load(object sender, EventArgs e)
        {
            CargarDatosCompra();
            CargarDetalle();
        }

        private void CargarDatosCompra()
        {
            lbl_Proveedor_ComprasDetalle.Text = compraActual.NombreProveedor;
            lbl_Fecha_ComprasDetalle.Text = compraActual.Fecha.ToShortDateString();
            lbl_Usuario_ComprasDetalle.Text = compraActual.NombreUsuario;
            lbl_Total_ComprasDetalle.Text = "$" + compraActual.Total.ToString("N2");
        }

        private void CargarDetalle()
        {
            controlador.ObtenerDetalleCompra(compraActual.IdCompra, dgv_ComprasDetalle);

            dgv_ComprasDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_ComprasDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_ComprasDetalle.MultiSelect = false;
            dgv_ComprasDetalle.ReadOnly = true;
            dgv_ComprasDetalle.ClearSelection();
        }
    }
}