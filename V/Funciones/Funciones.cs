using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym.V.Funciones
{
    public class Funciones
    {
        //Abrir form hijo
        void abrirForm(Form form, Panel panel)
        {
            while (panel.Controls.Count > 0)
            {
                panel.Controls.RemoveAt(0);
            }
            Form formHijo = form;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panel.Controls.Add(formHijo);
            formHijo.Show();
        }
    }
}
