using Gym.V.frmHijos.Movimientos;
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

namespace Gym.V.frmHijos
{
    public partial class frm_membresias : Form
    {
        string query = "Select m.nombre, m.precio, m.tipo, m.cantidad_msd, mh.hora_inicio, mh.hora_fin, m.fecha_creacion, m.activo From Membresias m Join Membresias_Horario mh on m.id_membresias = mh.id_membresias;";
        ConDB consultaSql = new ConDB();
        public frm_membresias()
        {
            InitializeComponent();
        }

        private void frm_membresias_Load(object sender, EventArgs e)
        {
            consultaSql.CargarTabla(query, dgv_Membresias);
        }

        private void btn_Nuevo_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Nuevo frm = new frm_Membresias_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Modificar_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Nuevo frm = new frm_Membresias_Nuevo();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Horarios_Membresias_Click(object sender, EventArgs e)
        {
            frm_Membresias_Horarios frm = new frm_Membresias_Horarios();
            Funciones.abrirFormModal(frm, this);
        }
    }
}
