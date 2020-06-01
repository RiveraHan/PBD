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
    public partial class fSolicitud : Form
    {
        logicaNegocioSolicitud logicaSolicitud = new logicaNegocioSolicitud();
        logicaNegocioRecursos logicaRecursos = new logicaNegocioRecursos();
        logicaNegocioUsuario logicaUsuario = new logicaNegocioUsuario();
        Solicitud solicitud = new Solicitud();
        public fSolicitud()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonGuardar.Text == "Guardar")
                {
                    solicitud.aula = textBoxAula.Text;
                    solicitud.nivel = textBoxNivel.Text;
                    solicitud.fecha_solicitud = Convert.ToDateTime(dateTimePickerFechaSolicitud.Text);
                    solicitud.fecha_uso = Convert.ToDateTime(dateTimePickerUso.Text);                    
                    solicitud.hora_inicio = Convert.ToDateTime(dateTimePickerHoraInicio.Text);
                    solicitud.hora_final = Convert.ToDateTime(dateTimePickerHoraFinal.Text);
                    solicitud.carrera = textBoxCarrera.Text;
                    solicitud.asignatura = textBoxAsignatura.Text;
                    solicitud.id_recursos = Convert.ToInt32(dataGridViewRecurso.CurrentRow.Cells["id_recursos"].Value.ToString());
                    solicitud.id_usuario = Convert.ToInt32(dataGridViewUsuario.CurrentRow.Cells["id_usuario"].Value.ToString());
                    solicitud.nombres = "";

                    if (logicaSolicitud.insertarSolicitud(solicitud) > 0)
                    {
                        MessageBox.Show("Agregado con éxito");
                        dataGridViewSolicitudes.DataSource = logicaSolicitud.listarSolicitudes();
                        textBoxAula.Text = "";
                        textBoxNivel.Text = "";
                        dateTimePickerFechaSolicitud.Text = "";
                        dateTimePickerUso.Text = "";
                        dateTimePickerHoraInicio.Text = "";
                        dateTimePickerHoraFinal.Text = "";
                        textBoxCarrera.Text = "";
                        textBoxAsignatura.Text = "";
                        tabSolicitud.SelectedTab = tabPage2;
                        tabPage2.Show();
                    }
                    else { MessageBox.Show("Error al agregar la solicitud"); }
                }

                if (buttonGuardar.Text == "Actualizar")
                {
                    solicitud.id_solicitud = Convert.ToInt32(textBoxId.Text);
                    solicitud.aula = textBoxAula.Text;
                    solicitud.nivel = textBoxNivel.Text;
                    solicitud.fecha_solicitud = Convert.ToDateTime(dateTimePickerFechaSolicitud.Text);
                    solicitud.fecha_uso = Convert.ToDateTime(dateTimePickerUso.Text);
                    solicitud.hora_inicio = Convert.ToDateTime(dateTimePickerHoraInicio.Text);
                    solicitud.hora_final = Convert.ToDateTime(dateTimePickerHoraFinal.Text);
                    solicitud.carrera = textBoxCarrera.Text;
                    solicitud.asignatura = textBoxAsignatura.Text;
                    solicitud.id_recursos = Convert.ToInt32(dataGridViewRecurso.CurrentRow.Cells["id_recursos"].Value.ToString());
                    solicitud.id_usuario = Convert.ToInt32(dataGridViewUsuario.CurrentRow.Cells["id_usuario"].Value.ToString());
                    solicitud.nombres = ""; 

                    if (logicaSolicitud.editarSolicitud(solicitud) > 0)
                    {
                        MessageBox.Show("Actualizado con éxito");
                        dataGridViewSolicitudes.DataSource = logicaSolicitud.listarSolicitudes();
                        textBoxAula.Text = "";
                        textBoxNivel.Text = "";
                        dateTimePickerFechaSolicitud.Text = "";                       
                        dateTimePickerUso.Text = "";
                        dateTimePickerHoraInicio.Text = "";
                        dateTimePickerHoraFinal.Text = "";
                        textBoxCarrera.Text = "";
                        textBoxAsignatura.Text = "";
                        tabSolicitud.SelectedTab = tabPage2;
                        tabPage2.Show();
                    }
                    else { MessageBox.Show("Error al actualizar"); }

                    buttonGuardar.Text = "Guardar";
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void textBoxRecurso_TextChanged(object sender, EventArgs e)
        {
            List<Solicitud> listaSolicitud = logicaSolicitud.buscarSolicitud(textBoxBuscar.Text);
            dataGridViewRecurso.DataSource = listaSolicitud;
        }

        private void fSolicitud_Load(object sender, EventArgs e)
        {
            labelId.Visible = false;
            textBoxId.Visible = false;
            dataGridViewSolicitudes.DataSource = logicaSolicitud.listarSolicitudes();
            dataGridViewRecurso.Visible = false;
            dataGridViewUsuario.Visible = false;
             
        }

        private void buttonSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSelecionarRecurso_Click_1(object sender, EventArgs e)
        {
            if(buttonSelecionarRecurso.Text == "Mostrar")
            {
                dataGridViewRecurso.Visible = true;
                dataGridViewRecurso.DataSource = logicaRecursos.listarRecursos();// Listar en el datagrid los recursos para selecionarlo al hacer la solicitud
            }
            else
            {
                dataGridViewRecurso.DataSource = logicaRecursos.listarRecursos();
            }

            buttonSelecionarRecurso.Text = "Refrescar";
        }

        private void buttonSeleccionarUsuario_Click_1(object sender, EventArgs e)
        {
            

            if(buttonSeleccionarUsuario.Text == "Mostrar")
            {
                dataGridViewUsuario.Visible = true;
                dataGridViewUsuario.DataSource = logicaUsuario.listarUsuario();
            }
            else
            {
                dataGridViewUsuario.DataSource = logicaUsuario.listarUsuario();
            }

            buttonSeleccionarUsuario.Text = "Refrescar";

        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Solicitud> listaSolicitud = logicaSolicitud.buscarSolicitud(textBoxBuscar.Text);
            dataGridViewSolicitudes.DataSource = listaSolicitud;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            textBoxId.Visible = true;
            textBoxId.Enabled = false;
            labelId.Visible = true;

            dataGridViewRecurso.Visible = true;
            dataGridViewUsuario.Visible = true;            

            //Asignado datos seleccionados del dataGridView a las cajas de texto
            textBoxId.Text = dataGridViewSolicitudes.CurrentRow.Cells["id_solicitud"].Value.ToString();
            textBoxAula.Text = dataGridViewSolicitudes.CurrentRow.Cells["aula"].Value.ToString();
            textBoxNivel.Text = dataGridViewSolicitudes.CurrentRow.Cells["nivel"].Value.ToString();
            dateTimePickerFechaSolicitud.Text = dataGridViewSolicitudes.CurrentRow.Cells["fecha_solicitud"].Value.ToString();
            dateTimePickerUso.Text = dataGridViewSolicitudes.CurrentRow.Cells["fecha_uso"].Value.ToString();
            dateTimePickerHoraInicio.Text = dataGridViewSolicitudes.CurrentRow.Cells["hora_inicio"].Value.ToString();
            dateTimePickerHoraFinal.Text = dataGridViewSolicitudes.CurrentRow.Cells["hora_final"].Value.ToString();
            textBoxCarrera.Text = dataGridViewSolicitudes.CurrentRow.Cells["carrera"].Value.ToString();
            textBoxAsignatura.Text = dataGridViewSolicitudes.CurrentRow.Cells["asignatura"].Value.ToString();
            dataGridViewRecurso.DataSource = dataGridViewSolicitudes.CurrentRow.Cells["id_recursos"].Value.ToString();
            dataGridViewUsuario.DataSource = dataGridViewSolicitudes.CurrentRow.Cells["id_usuario"].Value.ToString();           

            tabSolicitud.SelectedTab = tabPage1;
            dataGridViewRecurso.DataSource = logicaRecursos.listarRecursos();
            dataGridViewUsuario.DataSource = logicaUsuario.listarUsuario();
            buttonGuardar.Text = "Actualizar";

            buttonSelecionarRecurso.Text = "Refrescar";
            buttonSeleccionarUsuario.Text = "Refrescar";

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int clave_solicitud = Convert.ToInt32(dataGridViewSolicitudes.CurrentRow.Cells["id_solicitud"].Value.ToString());

            try
            {
                if (logicaSolicitud.eliminarSolicitud(clave_solicitud) > 0)
                {
                    MessageBox.Show("Eliminado con éxito");
                    dataGridViewSolicitudes.DataSource = logicaSolicitud.listarSolicitudes();
                }
            }
            catch
            {
                MessageBox.Show("ERROR al eliminar el recurso");
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
