using Gym.C;
using Gym.M;
using Gym.M.Entidades;
using Gym.V.frmHijos.Clientes;
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


namespace Gym.V.frmHijos.Conceptos
{
    public partial class frm_Conceptos : Form
    {
        ControladorConceptos controlador = new ControladorConceptos();
        public frm_Conceptos()
        {
            InitializeComponent();
            this.Load += frm_Conceptos_Load;
        }

        private void frm_Conceptos_Load(object sender, EventArgs e)
        {
            CargarConceptos();
        }

        private void btn_Nuevo_Conceptos_Click(object sender, EventArgs e)
        {
            frm_Conceptos_Nuevo frm = new frm_Conceptos_Nuevo();

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarConceptos();
            }
        }

        private void btn_Modificar_Conceptos_Click(object sender, EventArgs e)
        {
            Concepto concepto = CargarConceptoSeleccionado();

            if (concepto == null) 
            {
                MessageBox.Show("Seleccione un concepto");
                return;
            }

            frm_Conceptos_Nuevo frm = new frm_Conceptos_Nuevo(concepto);

            DialogResult resultado = Funciones.abrirFormModal(frm, this);

            if (resultado == DialogResult.OK)
            {
                CargarConceptos();
            }
        }

        private void btn_Eliminar_Conceptos_Click(object sender, EventArgs e)
        {
            Concepto concepto = CargarConceptoSeleccionado();

            if (concepto == null)
            {
                MessageBox.Show("Seleccione un concepto");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Desea Eliminar este concepto?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = controlador.DeleteConceptos(concepto.IdConcepto);

                if (resultado)
                {
                    MessageBox.Show("Concepto Eliminado correctamente");
                    CargarConceptos();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el concepto");
                }
            }
        }

        private Concepto CargarConceptoSeleccionado()
        {
            if (dgv_Conceptos.SelectedRows.Count == 0)
                return null;

            DataGridViewRow fila = dgv_Conceptos.SelectedRows[0];

            Concepto concepto = new Concepto
            {
                IdConcepto = Convert.ToInt32(fila.Cells["id_concepto"].Value),
                Nombre = fila.Cells["nombre"].Value.ToString(),
                Tipo = fila.Cells["tipo"].Value.ToString(),
                Activo = Convert.ToBoolean(fila.Cells["activo"].Value),
                FechaCreacion = Convert.ToDateTime(fila.Cells["fecha_creacion"].Value),
                Modificable = Convert.ToBoolean(fila.Cells["modificable"].Value)
            };

            return concepto;
        }
        // PROBLEMA CON CMB TIPO
        private void CargarConceptos()
        {
            controlador.ListarConceptos(dgv_Conceptos);

            dgv_Conceptos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Conceptos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Conceptos.MultiSelect = false;
            dgv_Conceptos.ReadOnly = true;

            dgv_Conceptos.Columns["id_concepto"].Visible = false;
        }

        private void dgv_Conceptos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgv_Conceptos.ClearSelection();
        }
    }
}
