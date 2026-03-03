using Gym.C;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Gym.V.frmHijos.Registro
{
    public partial class frm_Registro : Form
    {
        private ControladorRegistro controlador = new ControladorRegistro();

        public frm_Registro()
        {
            InitializeComponent();
        }

        private void frm_Registro_Load(object sender, EventArgs e)
        {
            lbl_Fecha_Registro.Text = DateTime.Now.ToString("dd / MM / yyyy");
            LimpiarDatos();
            txt_Clave_Registro.KeyPress += txt_Clave_Registro_KeyPress;
        }

        private void txt_Clave_Registro_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;

            // Al presionar Enter busca el cliente
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                BuscarYRegistrar();
            }
        }

        private void BuscarYRegistrar()
        {
            // Si está vacío, no hacer nada (sin MessageBox)
            if (string.IsNullOrWhiteSpace(txt_Clave_Registro.Text))
                return;

            if (!int.TryParse(txt_Clave_Registro.Text, out int codCliente))
            {
                MessageBox.Show("Código inválido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Clave_Registro.Clear();
                return;
            }

            DataTable dt = controlador.BuscarClientePorCodigo(codCliente);

            txt_Clave_Registro.Clear();
            LimpiarDatos();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Cliente no encontrado", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow fila = dt.Rows[0];

            if (!Convert.ToBoolean(fila["activo"]))
            {
                MessageBox.Show("Cliente inactivo", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(fila["id_cliente"]);
            int pendientes = Convert.ToInt32(fila["membresias_pendientes"]);
            string estadoMem = fila["estado_membresia"] == DBNull.Value
                ? "" : fila["estado_membresia"].ToString();

            lbl_Nombre_Registro.Text = fila["nombre"] + " " + fila["apellido"];
            lbl_DNI_Registro.Text = fila["dni"].ToString();
            lbl_Adeudo_Registro.Text = pendientes > 0 ? pendientes.ToString() : "0";
            panel2.BackColor = pendientes > 0 ? Color.OrangeRed : Color.LightGreen;

            if (estadoMem == "Activo")
            {
                DateTime vencimiento = Convert.ToDateTime(fila["fecha_vencimiento"]);
                int diasRestantes = Convert.ToInt32(fila["dias_restantes"]);

                lbl_Vencimiento.Text = vencimiento.ToString("dd/MM/yyyy");
                lbl_Clases_Registro.Text = diasRestantes > 0
                    ? diasRestantes + " días" : "Vencida";
                lbl_Vencimiento.ForeColor = Color.Black;
                lbl_Clases_Registro.ForeColor = diasRestantes > 0
                    ? Color.Black : Color.OrangeRed;

                controlador.RegistrarIngreso(idCliente);
            }
            else
            {
                lbl_Vencimiento.Text = "Sin membresía activa";
                lbl_Clases_Registro.Text = "-";
                lbl_Vencimiento.ForeColor = Color.OrangeRed;
                lbl_Clases_Registro.ForeColor = Color.OrangeRed;
            }
        }

        private void LimpiarDatos()
        {
            lbl_Nombre_Registro.Text = "-";
            lbl_DNI_Registro.Text = "-";
            lbl_Vencimiento.Text = "-";
            lbl_Clases_Registro.Text = "-";
            lbl_Adeudo_Registro.Text = "0";

            lbl_Vencimiento.ForeColor = Color.Black;
            lbl_Clases_Registro.ForeColor = Color.Black;
            panel2.BackColor = Color.LightGreen;
        }
    }
}