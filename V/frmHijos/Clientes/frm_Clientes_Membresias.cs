using Gym.V.frmHijos.Compras;
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
using Gym.M.Entidades;
using Gym.C;

namespace Gym.V.frmHijos.Clientes
{
    public partial class frm_Clientes_Membresias : Form
    {
        private ControladorClientes controlCliente = new ControladorClientes();
        private ControladorMembresias controlMembresia = new ControladorMembresias();
        private Cliente clienteActual;
        public frm_Clientes_Membresias(Cliente cliente)
        {
            InitializeComponent();
            clienteActual = cliente;
        }
        private void frm_Clientes_Membresias_Load(object sender, EventArgs e)
        {
            CargarDatosCliente(clienteActual);
            CargarComboMembreisas();
            CargarMembresiasDelCliente();
        }
       
        private void CargarDatosCliente(Cliente cliente)
        {
            lbl_Nombre_ClientesMembresias.Text = cliente.Nombre;
            lbl_Apellido_ClientesMembresias.Text = cliente.Apellido;
            lbl_DNI_ClientesMembresias.Text = cliente.Dni;
            lbl_Telefono_ClientesMembresias.Text = cliente.Telefono;
        }

        private void CargarComboMembreisas()
        {
            var lista = controlMembresia.ObtenerMembresiasActivas();

            cmb_Membresia_ClientesMembresias.DisplayMember = "Nombre"; //propiedad que muestra el combo al usuario

            cmb_Membresia_ClientesMembresias.ValueMember = "IdMembresia"; //propiedad usa el código internamente como valor

            cmb_Membresia_ClientesMembresias.DataSource = lista; //conecta la lista al combo

            cmb_Membresia_ClientesMembresias.SelectedIndex = -1;

            LimpiarLabelMembresia();
        }

        private void CargarMembresiasDelCliente()
        {
            controlCliente.ListarMembresiasDeCliente(
                clienteActual.IdCliente, dgv_ClientesMembresias);

            //oculta columnas sensibles pero importantes para identificar 
            if (dgv_ClientesMembresias.Columns.Contains("id_cliente_membresias"))
                dgv_ClientesMembresias.Columns["id_cliente_membresias"].Visible = false;
            if (dgv_ClientesMembresias.Columns.Contains("id_cliente"))
                dgv_ClientesMembresias.Columns["id_cliente"].Visible = false;
            if (dgv_ClientesMembresias.Columns.Contains("id_membresias"))
                dgv_ClientesMembresias.Columns["id_membresias"].Visible = false;
        }

        private void btn_Agregar_ClientesMembresias_Click(object sender, EventArgs e)
        {

            if (cmb_Membresia_ClientesMembresias.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una membresía", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            // SelectedItem es object, se convierte a Membresia
            var membresia = (Membresia)cmb_Membresia_ClientesMembresias.SelectedItem;

            DateTime inicio = dtp_FechaInicio_ClientesMembresias.Value.Date;

            bool resultado = controlCliente.InsertClienteMembresia(
                clienteActual.IdCliente, // A quién asignar
                membresia.IdMembresia,   // Qué membresía
                membresia.Precio,        // Precio congelado al momento de contratar
                inicio                   // Fecha de inicio elegida por el usuario
            );

            if (resultado)
            {
                MessageBox.Show("Membresía agregada correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMembresiasDelCliente(); 
            }
            else
            {
                MessageBox.Show("No se pudo agregar la membresía", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Pagar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            frm_Clientes_Membresias_Pago frm = new frm_Clientes_Membresias_Pago();
            Funciones.abrirFormModal(frm, this);
        }

        private void btn_Eliminar_ClientesMembresias_Click(object sender, EventArgs e)
        {
            // Validación: debe haber una fila seleccionada en el grid
            if (dgv_ClientesMembresias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una membresía a eliminar");
                return;
            }

            // Confirmación para evitar eliminaciones accidentales
            var confirmacion = MessageBox.Show(
                "¿Desea eliminar esta membresía del cliente?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // Obtiene el ID de la fila en Cliente_Membresias
                // La columna está oculta en el grid pero sigue siendo accesible desde el código
                int idClienteMembresia = Convert.ToInt32(
                    dgv_ClientesMembresias.SelectedRows[0].Cells["id_cliente_membresias"].Value);

                bool resultado = controlCliente.DeleteClienteMembresia(idClienteMembresia);

                if (resultado)
                {
                    MessageBox.Show("Membresía eliminada correctamente");
                    CargarMembresiasDelCliente(); // Refresca el grid
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la membresía");
                }
            }
        }

        private void cmb_Membresia_ClientesMembresias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Membresia_ClientesMembresias.SelectedItem is Membresia m) // "is Membresia m" verifica que haya algo seleccionado y lo convierte a Membresia
            {
                // Muestra el precio con formato de dos decimales
                lbl_Precio_ClientesMembresias.Text = "$" + m.Precio.ToString("N2");

                // Convierte cantidad_msd a unidad correcta según el tipo
                int meses = 0,
                    semanas = 0,
                    dias = 0;

                switch (m.Tipo)
                {
                    case "Mensual": meses = m.CantidadMsd / 30; break;
                    case "Semanal": semanas = m.CantidadMsd / 7; break;
                    case "Diario": dias = m.CantidadMsd; break;
                }

                // Muestra el valor correspondiente o "-" si no aplica a ese tipo
                lbl_Meses_ClientesMembresias.Text = meses > 0 ? meses.ToString() : "-";
                lbl_Semanas_ClientesMembresias.Text = semanas > 0 ? semanas.ToString() : "-";
                lbl_Dias_ClientesMembresias.Text = dias > 0 ? dias.ToString() : "-";
            }

            else 
            {
                LimpiarLabelMembresia();
            }
        }

        private void LimpiarLabelMembresia()
        {
            lbl_Precio_ClientesMembresias.Text = "$$$$$$";
            lbl_Meses_ClientesMembresias.Text = "######";
            lbl_Semanas_ClientesMembresias.Text = "######";
            lbl_Dias_ClientesMembresias.Text = "######";
        }
    }
}
