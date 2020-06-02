using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacionWF
{
    public partial class MDIRecursos : Form
    {
        private int childFormNumber = 0;

        public MDIRecursos()
        {
            InitializeComponent();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = respaldoStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void recursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["fRecursos"] != null)
            {
                Application.OpenForms["fRecursos"].Activate();
            }
            else
            {
                fRecursos ventana_recursos = new fRecursos();
                ventana_recursos.MdiParent = this;
                ventana_recursos.Show();
            }
        }

        private void salirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }

        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("Esta seguro de que quiere cerrar la aplicación?", "Cerrar la Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["fUsuarios"] != null)
            {
                Application.OpenForms["fUsuarios"].Activate();
            }
            else
            {
                fUsuarios ventana_usuarios = new fUsuarios();
                ventana_usuarios.MdiParent = this;
                ventana_usuarios.Show();
            }
        }

        private void solicitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms["fSolicitud"] != null)
            {
                Application.OpenForms["fSolicitud"].Activate();
            }
            else
            {
                fSolicitud ventana_solicitud = new fSolicitud();
                ventana_solicitud.MdiParent = this;
                ventana_solicitud.Show();
            }
        }
    }
}
