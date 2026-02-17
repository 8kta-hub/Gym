using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gym.C;
using Gym.M.Entidades;


namespace Gym.V.frmHijos.Conceptos
{
    public partial class frm_Conceptos_Nuevo : Form
    {   
        ControladorConceptos controlador = new ControladorConceptos();
        private Concepto conceptoActual;
        private bool NuevoCon;
        
        public frm_Conceptos_Nuevo()
        {
            InitializeComponent();
            NuevoCon = true;
        }

        public frm_Conceptos_Nuevo(Concepto concepto)
        {
            InitializeComponent();
            NuevoCon = false;
            conceptoActual = concepto;

        }

        private void frm_Conceptos_Nuevo_Load(object sender, EventArgs e)
        {
            cmb_Tipo_ConceptosNuevo.Items.Add("Egreso");
            cmb_Tipo_ConceptosNuevo.Items.Add("Ingreso");
            cmb_Tipo_ConceptosNuevo.Items.Add("Mixto");

            if (NuevoCon)
            {
                chk_ConceptoActivo.Checked = true;
                chk_ConceptoActivo.Enabled = false;
            }
            else
            {
                chk_ConceptoActivo.Enabled = true;
                CargarDatosEnControles(conceptoActual);
            }
        }

        private void btn_Guardar_ConceptosNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // validaciones
                if (string.IsNullOrWhiteSpace(txt_Nombre_ConceptosNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre");
                    txt_Nombre_ConceptosNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmb_Tipo_ConceptosNuevo.Text))
                {
                    MessageBox.Show("Debe seleccionar un tipo");
                    cmb_Tipo_ConceptosNuevo.Focus();
                    return;
                }

                string nombre = txt_Nombre_ConceptosNuevo.Text.Trim();
                string tipo = cmb_Tipo_ConceptosNuevo.Text;
                bool activo = chk_ConceptoActivo.Checked;
                bool resultado;

                if (NuevoCon)
                {
                    // INSERT
                    resultado = controlador.InsertConceptos(nombre, tipo, activo);
                }
                else
                {
                    // UPDATE
                    resultado = controlador.UpdateConceptos(
                        conceptoActual.IdConcepto,
                        nombre, tipo, activo
                    );
                }

                if (resultado)
                {
                    MessageBox.Show("Concepto guardado correctamente"); 
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el concepto"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarDatosEnControles(Concepto concepto)
        {
            txt_Nombre_ConceptosNuevo.Text = concepto.Nombre;
            cmb_Tipo_ConceptosNuevo.Text = concepto.Tipo;
            chk_ConceptoActivo.Checked = concepto.Activo;
        }
    }
}
