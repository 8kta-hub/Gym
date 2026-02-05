using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.V.Configuracion;
using Gym.V.frmHijos;
using Gym.V.frmHijos.Roles;
using Gym.V.frmHijos.Clientes;
using Gym.V.frmHijos.Productos;
using Gym.V.frmHijos.Compras;
using Gym.V.frmHijos.Ventas;
using Gym.V.frmHijos.Corte;
using Gym.V.frmHijos.Movimientos;
using Gym.V.frmHijos.Conceptos;
using Gym.V.frmHijos.Registro;
using Gym.V.frmHijos.Reporte;

namespace Gym
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
            frm_Inicio Inicio = new frm_Inicio();
            abrirForm(Inicio);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1014, 489);
        }

        //Abrir form hijo
        void abrirForm(Form form)
        {
            while (pnl_base.Controls.Count > 0)
            {
                pnl_base.Controls.RemoveAt(0);
            }
            Form formHijo = form;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnl_base.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            frm_Inicio Inicio = new frm_Inicio();
            abrirForm(Inicio);
        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios Usuarios = new frm_Usuarios();
            abrirForm(Usuarios);
        }

        private void btn_Roles_Click(object sender, EventArgs e)
        {
            frm_Roles Roles = new frm_Roles();
            abrirForm(Roles);
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes Clientes = new frm_Clientes();
            abrirForm(Clientes);
        }

        private void btn_Membresia_Click(object sender, EventArgs e)
        {
            frm_membresias Membresias = new frm_membresias();
            abrirForm(Membresias);
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos Productos = new frm_Productos();
            abrirForm(Productos);
        }

        private void btn_Compras_Click(object sender, EventArgs e)
        {
            frm_Compras Compras = new frm_Compras();
            abrirForm(Compras);
        }

        private void btn_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas Ventas = new frm_Ventas();
            abrirForm(Ventas);
        }

        private void btn_Corte_Click(object sender, EventArgs e)
        {
            frm_Corte Corte = new frm_Corte();
            abrirForm(Corte);
        }

        private void btn_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos Movimientos = new frm_Movimientos();
            abrirForm(Movimientos);
        }

        private void btn_Conceptos_Click(object sender, EventArgs e)
        {
            frm_Conceptos Conceptos = new frm_Conceptos();
            abrirForm(Conceptos);
        }

        private void btn_Registro_Click(object sender, EventArgs e)
        {
            frm_Registro Registro = new frm_Registro();
            abrirForm(Registro);
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            frm_Reportes Reporte = new frm_Reportes();
            abrirForm(Reporte);
        }

        private void btn_Congifuracion_Click(object sender, EventArgs e)
        {
            frm_Configuracion Config = new frm_Configuracion();
            abrirForm(Config);
        }
    }
}
