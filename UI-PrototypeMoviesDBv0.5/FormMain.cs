using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UI_PrototypeMoviesDBv0._5
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }        

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Trace.WriteLine("Shown");
        }        

        private void FormMain_Load(object sender, EventArgs e)
        {
            Trace.WriteLine("Load");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }
    }
}