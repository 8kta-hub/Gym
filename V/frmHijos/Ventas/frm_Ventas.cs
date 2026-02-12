using Gym.V.frmHijos.Roles;
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
using Gym.M;

namespace Gym.V.frmHijos.Ventas
{
    public partial class frm_Ventas : Form
    {
        string query = "Select total, fecha, estado From Operaciones";
        ConDB consultaSql = new ConDB();
        public frm_Ventas()
        {
            InitializeComponent();
        }

        private void frm_Ventas_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Ventas);
        }

        private void btn_Nuevo_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas_Nuevo frm = new frm_Ventas_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Detalle_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas_Detalle VentasDetalle = new frm_Ventas_Detalle();
            Funciones.abrirFormModal(VentasDetalle, this);
        }

    }
}
