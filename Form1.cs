using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDITextEditor
{
    public partial class MDIContainer : Form
    {
        public MDIContainer()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForm childform = new MyForm();
            childform.MdiParent = this;  // Book gives "parentForm"
            childform.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt| Rich Text Format (*.rtf)|*.rtf|" + "All Files (*.*)|*.*|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                if (fileName.Length != 0)
                {
                    try
                    {
                        MyForm childform = new MyForm();
                        childform.OpenFile(openFileDialog1.FileName);
                        childform.MdiParent = this;
                        childform.Show();
                    }
                    catch
                    {
                        MessageBox.Show(String.Format("{0} is not a valid file", fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
