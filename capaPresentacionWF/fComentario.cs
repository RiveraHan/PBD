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
    public partial class fComentario : Form
    {
        logicaNegocioComentarios logicaComentarios = new logicaNegocioComentarios();
        Comentarios comentarios = new Comentarios();
        public fComentario()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonComentar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonComentar.Text == "Guardar")
                {
                    comentarios.nombres= textBoxNombre.Text;
                    comentarios.correo = textBoxCorreo.Text;
                    comentarios.telefono = textBoxTelefono.Text;
                    comentarios.mensaje = textBoxMensaje.Text;

                    if (logicaComentarios.insertarComentario(comentarios) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewComentarios.DataSource = logicaComentarios.listarComentarios();
                        textBoxNombre.Text = "";
                        textBoxCorreo.Text = "";
                        textBoxTelefono.Text = "";
                        textBoxMensaje.Text = "";
                        tabComentarios.SelectedTab = tabPage2;
                        tabPage2.Show();
                    }
                    else { MessageBox.Show("Error al agregar el recurso"); }
                }

                if (buttonComentar.Text == "Actualizar")
                {
                    comentarios.id_comentario = Convert.ToInt32(textBoxId.Text);
                    comentarios.nombres = textBoxNombre.Text;
                    comentarios.correo = textBoxCorreo.Text;
                    comentarios.telefono = textBoxTelefono.Text;
                    comentarios.mensaje = textBoxMensaje.Text;

                    if (logicaComentarios.editarComentario(comentarios) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewComentarios.DataSource = logicaComentarios.listarComentarios();
                        textBoxNombre.Text = "";
                        textBoxCorreo.Text = "";
                        textBoxTelefono.Text = "";
                        textBoxMensaje.Text = "";
                        tabComentarios.SelectedTab = tabPage2;
                    }
                    else { MessageBox.Show("Error al actualizar"); }

                    buttonComentar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void textBoxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void fComentario_Load(object sender, EventArgs e)
        {
            labelId.Visible = false;
            textBoxId.Visible = false;
            dataGridViewComentarios.DataSource = logicaComentarios.listarComentarios();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            //Asignado datos seleccionados del dataGridView a las cajas de texto
            textBoxId.Text = dataGridViewComentarios.CurrentRow.Cells["id_comentario"].Value.ToString();
            textBoxNombre.Text = dataGridViewComentarios.CurrentRow.Cells["nombres"].Value.ToString();
            textBoxCorreo.Text = dataGridViewComentarios.CurrentRow.Cells["correo"].Value.ToString();
            textBoxTelefono.Text = dataGridViewComentarios.CurrentRow.Cells["telefono"].Value.ToString();
            textBoxMensaje.Text = dataGridViewComentarios.CurrentRow.Cells["mensaje"].Value.ToString();

            dataGridViewComentarios.DataSource = logicaComentarios.listarComentarios();

            tabComentarios.SelectedTab = tabPage1;
            buttonComentar.Text = "Actualizar";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int clave_comentario = Convert.ToInt32(dataGridViewComentarios.CurrentRow.Cells["id_comentario"].Value.ToString());

            try
            {
                if (logicaComentarios.eliminarComentario(clave_comentario) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewComentarios.DataSource = logicaComentarios.listarComentarios();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar el recurso");
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Comentarios> listaComentarios = logicaComentarios.buscarComentario(textBoxBuscar.Text);
            dataGridViewComentarios.DataSource = listaComentarios;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            List<Comentarios> listaComentarios = logicaComentarios.buscarComentario(textBoxBuscar.Text);
            dataGridViewComentarios.DataSource = listaComentarios;
        }
    }
}
