using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
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
            formHijo.Controls.Add(formHijo);
            formHijo.Show();
        }

    }
}
