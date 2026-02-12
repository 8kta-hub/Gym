using Gym.V.frmHijos.Productos;
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

namespace Gym.V.frmHijos.Movimientos
{
    public partial class frm_Movimientos : Form
    {
        string query = "Select m.fecha_creacion, c.tipo, c.nombre, m.monto, m.tipo_movimiento, u.usuario, m.observaciones From Movimiento_Caja m Join Conceptos c on m.id_concepto = c.id_concepto Join Usuarios u on m.id_usuario = u.id_usuario;";
        ConDB consultaSql = new ConDB();
        public frm_Movimientos()
        {
            InitializeComponent();
        }

        private void frm_Movimientos_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Movimientos);
        }

        private void btn_Nuevo_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos_Nuevos frm = new frm_Movimientos_Nuevos();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos_Nuevos frm = new frm_Movimientos_Nuevos();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
