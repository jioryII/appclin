using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmModuloEspecialista : Form
    {
        public FrmModuloEspecialista()
        {
            InitializeComponent();
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Clinico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema Clinico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.textcmpespecialista.Text = string.Empty;
            this.textnombreespecilasta.Text = string.Empty;
            this.textapellidoespecialista.Text = string.Empty;
            this.textcodigoespecialista.Text = string.Empty;
        }

        private void CargarDatosEspecialista()
        {
            try
            {
                DataTable dtEspecialista = NEspecialista.ListarEspecialistas();
                if (dtEspecialista != null && dtEspecialista.Rows.Count > 0)
                {
                    this.dgvEspecialista.DataSource = dtEspecialista;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos de Especialistas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de Especialistas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmModuloEspecialista_Load(object sender, EventArgs e)
        {
            CargarDatosEspecialista();
        }

        private void InsertaEspecialista()
        {
            int cmpespecialista;
            string nombreespecilasta = textnombreespecilasta.Text.Trim();
            string apellidoespecialista = textapellidoespecialista.Text.Trim();
            int codigoespecialista;

            // Validación básica (puedes agregar más validaciones)
            if (string.IsNullOrEmpty(especialistacmp) ||
                string.IsNullOrEmpty(especialistanombre) ||
                string.IsNullOrEmpty(especialistacodigo))
            {
                MessageBox.Show("Los campos código, nombre y apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textcodigoespecialista.Text.Trim(), out especialistacodigo))
            {
                MessageBox.Show("El teléfono debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ModificarEspecialista()
        {
                int cmpespecialista;
                string nombreespecilasta = textnombreespecilasta.Text.Trim();
                string apellidoespecialista = textapellidoespecialista.Text.Trim();
                int codigoespecialista;

            if (string.IsNullOrEmpty(especialistacmp) ||
                string.IsNullOrEmpty(especialistanombre) ||
                string.IsNullOrEmpty(especialistacodigo))
            {
                MessageBox.Show("Los campos código, nombre y apellido son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textcodigoespecialista.Text.Trim(), out especialistacodigo))
            {
                MessageBox.Show("El teléfono debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertaEspecialista();
            CargarDatosEspecialista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificarEspecialista();
            CargarDatosEspecialista();
        }
        private void EliminaEspecialista()
        {
            // Obtener el ID del registro a eliminar
            string especialistacodigo = textcmpespecialista.Text;

            // Confirmar la eliminación
            if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Eliminar el registro
                string rpta = NEspecialista.Eliminar(cmpespecialista);

                // Mostrar mensaje de éxito o error
                if (rpta == "Ok")
                {
                    MessageBox.Show("Registro eliminado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar registro: " + rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EliminaEspecialista();
            CargarDatosEspecialista();
        }
    
    }
}
