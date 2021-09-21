using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using UI_PrototypeMoviesDBv0._5.Properties;

namespace UI_PrototypeMoviesDBv0._5
{
    public partial class FormMain : Form
    {
        //new Thread(DoWork).Start();
        // TODO:String-Verarbeitung und DB-Work in getrennte Threads
        // TODO:Bestätigungen per ShowDialog
        // TODO:Konvertierung TSV zu XML und XML zu TSV (für movies.tsv)
        // TODO:Custom-Dialog für Settings
        // TODO:automatische Logs
        // TODO:Selenium-Downloader einfügen
        // TODO:Downloader prüft auf vollständige Datei
        // TODO:HTMLs von Imdb auswählen, Downloader soll dann erst alle HTMLs des Films laden, dann weitergehen

        private Worker worker;

        public FormMain()
        {
            InitializeComponent();

            var controls = new Dictionary<string, Object>();
            controls.Add("buttonStart", buttonStart);
            controls.Add("buttonSettings", buttonSettings);
            controls.Add("comboBox", comboBox);
            controls.Add("textBox", textBox);
            controls.Add("statusLabelStopWatch", statusLabelStopWatch);
            controls.Add("statusLabelTask", statusLabelTask);
            controls.Add("statusLabelPercentage", statusLabelPercentage);
            controls.Add("statusLabelInfo", statusLabelInfo);
            controls.Add("statusProgressBar", statusProgressBar);

            worker = new Worker(controls);
            worker.CreateControl();            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            statusProgressBar.Minimum = 0;
            statusProgressBar.Maximum = 100;
            statusProgressBar.Value = 0;

            textBox.Clear();

            statusLabelStopWatch.Text = "Ready";
            statusLabelTask.Text = "";
            statusLabelPercentage.Text = "";
            statusLabelInfo.Text = "";
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
            if (worker.run)
            {
                worker.run = false;
                statusLabelInfo.Text = "Stopped";
                buttonStart.Text = "Start";
                buttonStart.Image = Resources.play16;
                buttonSettings.Enabled = true;
                comboBox.Enabled = false;
            }
            else
            {
                textBox.Text = "";
                statusProgressBar.Value = 0;
                statusLabelPercentage.Text = "";

                worker.SetNumber(10400);
                var worker2Thread = new Thread(worker.DoWork);
                worker2Thread.Start();
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            // TODO:Settings-Dialog

            //using (var formSettings = new FormSettings())
            //{
            //    formSettings.ShowDialog(this);
            //}
        }
    }
}