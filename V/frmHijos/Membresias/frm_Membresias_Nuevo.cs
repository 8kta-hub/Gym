using Gym.C;
using Gym.M.Entidades;
using System;
using System.Windows.Forms;

namespace Gym.V.frmHijos
{
    public partial class frm_Membresias_Nuevo : Form
    {
        ControladorMembresias controlador = new ControladorMembresias();
        private Membresia membresiaActual;
        private bool NuevoMem;

        public frm_Membresias_Nuevo()
        {
            InitializeComponent();
            NuevoMem = true;
        }

        public frm_Membresias_Nuevo(Membresia membresia)
        {
            InitializeComponent();
            NuevoMem = false;
            membresiaActual = membresia;
        }

        private void frm_Membresias_Nuevo_Load(object sender, EventArgs e)
        {
            // Tipos de membresía
            cmb_Tipo_MembresiasNuevo.Items.Add("Mensual");
            cmb_Tipo_MembresiasNuevo.Items.Add("Semanal");
            cmb_Tipo_MembresiasNuevo.Items.Add("Diario");

            // Meses (1 a 12)
            for (int i = 1; i <= 12; i++)
                cmb_Meses_MembresiasNuevo.Items.Add(i);

            // Semanas (1 a 52)
            for (int i = 1; i <= 52; i++)
                cmb_Semanas_MembresiasNuevo.Items.Add(i);

            // Días (1 a 30)
            for (int i = 1; i <= 30; i++)
                cmb_Dias_MembresiasNuevo.Items.Add(i);

            // Arrancar con todos deshabilitados hasta que se elija un tipo
            DesactivarTodosLosControlesDuracion();

            if (NuevoMem)
            {
                // Alta: activo por defecto y no se puede cambiar
                chk_MembresiaActivo.Checked = true;
                chk_MembresiaActivo.Enabled = false;
            }
            else
            {
                // Modificación: se puede cambiar el estado
                chk_MembresiaActivo.Enabled = true;
                CargarDatosEnControles(membresiaActual);
            }
        }

        // Se dispara cada vez que el usuario cambia el tipo
        private void cmb_Tipo_MembresiasNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resetear TODOS los controles de duración
            cmb_Meses_MembresiasNuevo.SelectedIndex = -1;
            cmb_Semanas_MembresiasNuevo.SelectedIndex = -1;
            cmb_Dias_MembresiasNuevo.SelectedIndex = -1;

            // Habilitar solo el control correspondiente al tipo elegido
            AplicarEstadoSegunTipo(cmb_Tipo_MembresiasNuevo.Text);
        }

        private void AplicarEstadoSegunTipo(string tipo)
        {
            DesactivarTodosLosControlesDuracion();

            switch (tipo)
            {
                case "Mensual":
                    cmb_Meses_MembresiasNuevo.Enabled = true;
                    cmb_Meses_MembresiasNuevo.SelectedIndex = 0;
                    break;

                case "Semanal":
                    cmb_Semanas_MembresiasNuevo.Enabled = true;
                    cmb_Semanas_MembresiasNuevo.SelectedIndex = 0;
                    break;

                case "Diario":
                    cmb_Dias_MembresiasNuevo.Enabled = true;
                    cmb_Dias_MembresiasNuevo.SelectedIndex = 0;
                    break;
            }
        }

        private void DesactivarTodosLosControlesDuracion()
        {
            cmb_Meses_MembresiasNuevo.Enabled = false;
            cmb_Meses_MembresiasNuevo.SelectedIndex = -1;
            cmb_Semanas_MembresiasNuevo.Enabled = false;
            cmb_Semanas_MembresiasNuevo.SelectedIndex = -1;
            cmb_Dias_MembresiasNuevo.Enabled = false;
            cmb_Dias_MembresiasNuevo.SelectedIndex = -1;
        }

        private void btn_Guardar_MembresiasNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txt_Nombre_MembresiasNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre");
                    txt_Nombre_MembresiasNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_Precio_MembresiasNuevo.Text))
                {
                    MessageBox.Show("Debe ingresar un precio");
                    txt_Precio_MembresiasNuevo.Focus();
                    return;
                }

                if (!decimal.TryParse(txt_Precio_MembresiasNuevo.Text, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número válido mayor a 0");
                    txt_Precio_MembresiasNuevo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmb_Tipo_MembresiasNuevo.Text))
                {
                    MessageBox.Show("Debe seleccionar un tipo");
                    cmb_Tipo_MembresiasNuevo.Focus();
                    return;
                }

                // Calcular cantidad_msd según el tipo activo
                int cantidadMsd = 0;
                string tipo = cmb_Tipo_MembresiasNuevo.Text;

                switch (tipo)
                {
                    case "Mensual":
                        if (cmb_Meses_MembresiasNuevo.SelectedItem == null)
                        {
                            MessageBox.Show("Debe seleccionar la cantidad de meses");
                            cmb_Meses_MembresiasNuevo.Focus();
                            return;
                        }
                        cantidadMsd = (int)cmb_Meses_MembresiasNuevo.SelectedItem * 30;
                        break;

                    case "Semanal":
                        if (cmb_Semanas_MembresiasNuevo.SelectedItem == null)
                        {
                            MessageBox.Show("Debe seleccionar la cantidad de semanas");
                            cmb_Semanas_MembresiasNuevo.Focus();
                            return;
                        }
                        cantidadMsd = (int)cmb_Semanas_MembresiasNuevo.SelectedItem * 7;
                        break;

                    case "Diario":
                        if (cmb_Dias_MembresiasNuevo.SelectedItem == null)
                        {
                            MessageBox.Show("Debe seleccionar la cantidad de días");
                            cmb_Dias_MembresiasNuevo.Focus();
                            return;
                        }
                        cantidadMsd = (int)cmb_Dias_MembresiasNuevo.SelectedItem;
                        break;
                }

                string nombre = txt_Nombre_MembresiasNuevo.Text.Trim();
                DateTime fechaVec = DateTime.Now.AddDays(cantidadMsd);
                bool resultado;

                if (NuevoMem)
                {
                    resultado = controlador.InsertMembresia(nombre, precio, tipo, cantidadMsd,  true);
                }
                else
                {
                    resultado = controlador.UpdateMembresia(
                        membresiaActual.IdMembresia,
                        nombre, precio, tipo, cantidadMsd,chk_MembresiaActivo.Checked
                    );
                }

                if (resultado)
                {
                    MessageBox.Show("Membresía guardada correctamente");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la membresía");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarDatosEnControles(Membresia membresia)
        {
            txt_Nombre_MembresiasNuevo.Text = membresia.Nombre;
            txt_Precio_MembresiasNuevo.Text = membresia.Precio.ToString();

            // Setear el tipo sin disparar el evento para no resetear los valores
            cmb_Tipo_MembresiasNuevo.SelectedIndexChanged -= cmb_Tipo_MembresiasNuevo_SelectedIndexChanged;
            cmb_Tipo_MembresiasNuevo.Text = membresia.Tipo;
            cmb_Tipo_MembresiasNuevo.SelectedIndexChanged += cmb_Tipo_MembresiasNuevo_SelectedIndexChanged;

            // Habilitar solo el control del tipo correspondiente
            AplicarEstadoSegunTipo(membresia.Tipo);

            // Cargar el valor ya convertido al control habilitado
            switch (membresia.Tipo)
            {
                case "Mensual":
                    int meses = membresia.CantidadMsd / 30;
                    if (cmb_Meses_MembresiasNuevo.Items.Contains(meses))
                        cmb_Meses_MembresiasNuevo.SelectedItem = meses;
                    break;

                case "Semanal":
                    int semanas = membresia.CantidadMsd / 7;
                    if (cmb_Semanas_MembresiasNuevo.Items.Contains(semanas))
                        cmb_Semanas_MembresiasNuevo.SelectedItem = semanas;
                    break;

                case "Diario":
                    int dias = membresia.CantidadMsd;
                    if (cmb_Dias_MembresiasNuevo.Items.Contains(dias))
                        cmb_Dias_MembresiasNuevo.SelectedItem = dias;
                    break;
            }

            chk_MembresiaActivo.Checked = membresia.Activo;
        }
    }
}