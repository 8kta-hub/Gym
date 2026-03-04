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
using Gym.V.FuncionesV;

namespace Gym
{
    public partial class frm_Principal : Form
    {
        private string UsuarioIngresado;
        private Form Login;
        
        public frm_Principal(string usuarioIngresado, Form login)
        {
            InitializeComponent();
            frm_Inicio Inicio = new frm_Inicio();
            Funciones.abrirForm(Inicio, pnl_base);
            this.UsuarioIngresado = usuarioIngresado;
            this.Login = login;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1014, 489);
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            frm_Inicio Inicio = new frm_Inicio();
            Funciones.abrirForm(Inicio,pnl_base);
        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            frm_Usuarios Usuarios = new frm_Usuarios();
            Funciones.abrirForm(Usuarios,pnl_base);
        }

        private void btn_Roles_Click(object sender, EventArgs e)
        {
            frm_Roles Roles = new frm_Roles();
            Funciones.abrirForm(Roles,pnl_base);
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            frm_Clientes Clientes = new frm_Clientes();
            Funciones.abrirForm(Clientes,pnl_base);
        }

        private void btn_Membresia_Click(object sender, EventArgs e)
        {
            frm_membresias Membresias = new frm_membresias();
            Funciones.abrirForm(Membresias,pnl_base);
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            frm_Productos Productos = new frm_Productos();
            Funciones.abrirForm(Productos,pnl_base);
        }

        private void btn_Compras_Click(object sender, EventArgs e)
        {
            frm_Compras Compras = new frm_Compras();
            Funciones.abrirForm(Compras,pnl_base);
        }

        private void btn_Ventas_Click(object sender, EventArgs e)
        {
            frm_Ventas Ventas = new frm_Ventas();
            Funciones.abrirForm(Ventas,pnl_base);
        }

        private void btn_Corte_Click(object sender, EventArgs e)
        {
            frm_Corte Corte = new frm_Corte();
            Funciones.abrirForm(Corte,pnl_base);
        }

        private void btn_Movimientos_Click(object sender, EventArgs e)
        {
            frm_Movimientos Movimientos = new frm_Movimientos();
            Funciones.abrirForm(Movimientos,pnl_base);
        }

        private void btn_Conceptos_Click(object sender, EventArgs e)
        {
            frm_Conceptos Conceptos = new frm_Conceptos();
            Funciones.abrirForm(Conceptos,pnl_base);
        }

        private void btn_Registro_Click(object sender, EventArgs e)
        {
            frm_Registro Registro = new frm_Registro();
            Funciones.abrirForm(Registro,pnl_base);
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            frm_Reportes Reporte = new frm_Reportes();
            Funciones.abrirForm(Reporte,pnl_base);
        }

        private void btn_Congifuracion_Click(object sender, EventArgs e)
        {
            frm_Configuracion Config = new frm_Configuracion();
            Funciones.abrirForm(Config,pnl_base);
        }

        private void frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
