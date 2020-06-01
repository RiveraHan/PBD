using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidades;
using capaNegocio;

namespace capaPresentacionWF
{
    public partial class fRecursos : Form
    {
        logicaNegocioRecursos logicaRecursos = new logicaNegocioRecursos();
        Recursos recursos = new Recursos();
        public fRecursos()
        {
            InitializeComponent();
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    recursos.nombre_recursos = textBoxNombre.Text;
                    recursos.codigo = textBoxCodigo.Text;
                    recursos.descripcion = textBoxDescripcion.Text;

                    if (logicaRecursos.insertarRecurso(recursos) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRecursos.DataSource = logicaRecursos.listarRecursos();
                        textBoxNombre.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescripcion.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                        tabPage2.Show();
                    } else { MessageBox.Show("Error al agregar el recurso"); }
                }

                if (buttonGuardar.Text == "Actualizar")
                {
                    recursos.id_recursos = Convert.ToInt32(textBoxId.Text);
                    recursos.nombre_recursos = textBoxNombre.Text;
                    recursos.codigo = textBoxCodigo.Text;
                    recursos.descripcion = textBoxDescripcion.Text;
                    if (logicaRecursos.editarRecurso(recursos) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewRecursos.DataSource = logicaRecursos.listarRecursos();
                        textBoxNombre.Text = "";
                        textBoxCodigo.Text = "";
                        textBoxDescripcion.Text = "";
                        tabRecursos.SelectedTab = tabPage2;
                    }
                    else { MessageBox.Show("Error al actualizar"); }

                    buttonGuardar.Text = "Guardar";
                }
            } catch
            {
                MessageBox.Show("ERROR");
            }

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            //Asignado datos seleccionados del dataGridView a las cajas de texto
            textBoxId.Text = dataGridViewRecursos.CurrentRow.Cells["id_recursos"].Value.ToString();
            textBoxNombre.Text = dataGridViewRecursos.CurrentRow.Cells["nombre_recursos"].Value.ToString();
            textBoxCodigo.Text = dataGridViewRecursos.CurrentRow.Cells["codigo"].Value.ToString();
            textBoxDescripcion.Text = dataGridViewRecursos.CurrentRow.Cells["descripcion"].Value.ToString();

            dataGridViewRecursos.DataSource = logicaRecursos.listarRecursos();

            tabRecursos.SelectedTab = tabPage1;
            buttonGuardar.Text = "Actualizar";
        }

        private void fRecursos_Load(object sender, EventArgs e)
        {
            labelId.Visible = false;
            textBoxId.Visible = false;
            dataGridViewRecursos.DataSource = logicaRecursos.listarRecursos();

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int clave_recuso = Convert.ToInt32(dataGridViewRecursos.CurrentRow.Cells["id_recursos"].Value.ToString());

            try
            {
                if(logicaRecursos.eliminarRecurso(clave_recuso) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewRecursos.DataSource = logicaRecursos.listarRecursos();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar el recurso");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Recursos> listaRecursos = logicaRecursos.buscarRecurso(textBoxBuscar.Text);
            dataGridViewRecursos.DataSource = listaRecursos;
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Recursos> listaRecursos = logicaRecursos.buscarRecurso(textBoxBuscar.Text);
            dataGridViewRecursos.DataSource = listaRecursos;
        }

        private void dataGridViewRecursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
