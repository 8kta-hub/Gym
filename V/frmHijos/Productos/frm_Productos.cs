using Gym.V.frmHijos.Ventas;
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

namespace Gym.V.frmHijos.Productos
{
    public partial class frm_Productos : Form
    {
        string query = "Select codigo, nombre, descripcion, costo, precio_venta, fecha_creacion, estado From Productos";
        ConDB consultaSql = new ConDB();
        public frm_Productos()
        {
            InitializeComponent();
        }

        private void frm_Productos_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Productos);
        }

        private void btn_Nuevo_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos_Nuevo frm = new frm_Productos_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos_Nuevo frm = new frm_Productos_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
