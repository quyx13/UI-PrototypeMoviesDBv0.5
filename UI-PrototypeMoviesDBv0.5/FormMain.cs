using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace UI_PrototypeMoviesDBv0._5
{
    public partial class FormMain : Form
    {
        private Worker worker;

        public FormMain()
        {
            InitializeComponent();

            var controls = new Dictionary<string, Object>();
            controls.Add("", buttonStart);
            controls.Add("", buttonSettings);
            controls.Add("", comboBoxModule);
            controls.Add("", textBox);
            controls.Add("", statusLabelStopWatch);
            controls.Add("", statusLabelTask);
            controls.Add("", statusProgressBar);
            controls.Add("", statusLabelPercent);
            controls.Add("", statusLabelInfo);

            worker = new Worker(controls);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO:Info-Dialog
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }
    }
}