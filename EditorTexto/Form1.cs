using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        string archivo;

        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Texto (*.txt)|*.txt|All files(*.*)|*.*";


            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                archivo = OpenFile.FileName;

                using (StreamReader sr = new StreamReader(OpenFile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
                Form1.ActiveForm.Text = archivo + " | EDITEX |";

            }
                   

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Texto (*.txt)|*.txt|All files(*.*)|*.*";

            if (archivo != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(richTextBox1.Text);
                }
            }

            else
            {
                if(SaveFile.ShowDialog() == DialogResult.OK)
                    archivo=SaveFile.FileName;
                    
                    using(StreamWriter sw = new StreamWriter(SaveFile.FileName))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            archivo = null;
            Form1.ActiveForm.Text = archivo + "  EDITEX ";
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }
    }
}
