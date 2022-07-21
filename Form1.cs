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
        int counter = 1;

        public MDIContainer()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new MyForm();
            childform.MdiParent = this;  // Book gives "parentForm"
            childform.Text = $"MyForm {counter}";
            childform.Show();
            counter++;
            //this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);  // Alternative code the creates new rich text doc
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form activeChildForm = ActiveMdiChild;
                if (activeChildForm != null)
                {
                    RichTextBox RichtxtEditor = activeChildForm.ActiveControl as RichTextBox;
                    if (RichtxtEditor != null)
                    {
                        string extension = System.IO.Path.GetExtension(saveFileDialog1.FileName);
                        if (extension.ToLower() == ".txt") /*saveFileDialog.FilterIndex==1*/
                            RichtxtEditor.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        else if (extension.ToLower() == ".rtf")
                            RichtxtEditor.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    }
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 12 point font
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Font = new Font(ActiveMdiChild.Font.Name, 12);
        }

        // 16 point font
        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Font = new Font(ActiveMdiChild.Font.Name, 16);
        }

        // 20 point font
        private void pointToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Font = new Font(ActiveMdiChild.Font.Name, 20);
        }

        private void algerianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Font = new Font("ALGERIAN", 12);
        }

        private void comicSansMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ActiveMdiChild.Font = new Font("Comic Sans MS", 12);
        }

        private void segoeUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ActiveMdiChild.Font = new Font("Seoe UI", 12);
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Controls["richTextBox1"].ForeColor = Color.Black;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Controls["richTextBox1"].ForeColor = Color.Red;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Controls["richTextBox1"].ForeColor = Color.Green;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Controls["richTextBox1"].ForeColor = Color.Blue;
        }
    }
}
