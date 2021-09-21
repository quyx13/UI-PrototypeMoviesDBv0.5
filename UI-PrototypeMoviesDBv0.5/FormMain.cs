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
            controls.Add("buttonStart", buttonStart);
            controls.Add("buttonSettings", buttonSettings);
            controls.Add("comboBoxModule", comboBoxModule);
            controls.Add("textBox", textBox);
            controls.Add("statusLabelStopWatch", statusLabelStopWatch);
            controls.Add("statusLabelTask", statusLabelTask);
            controls.Add("statusProgressBar", statusProgressBar);
            controls.Add("statusLabelPercent", statusLabelPercent);
            controls.Add("statusLabelInfo", statusLabelInfo);

            worker = new Worker(controls);
            worker.CreateControl();

            //new Thread(DoWork).Start();
            // TODO:String-Verarbeitung und DB-Work in getrennte Threads
            // TODO:Bestätigungen per ShowDialog
            // TODO:Konvertierung TSV zu XML und XML zu TSV (für movies.tsv)
            // TODO:Custom-Dialog für Settings
            // TODO:automatische Logs
            // TODO:Selenium-Downloader einfügen
            // TODO:Downloader prüft auf vollständige Datei
            // TODO:HTMLs von Imdb auswählen, Downloader soll dann erst alle HTMLs des Films laden, dann weitergehen
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            statusProgressBar.Minimum = 0;
            statusProgressBar.Maximum = 100;
            statusProgressBar.Value = 0;

            textBox.Clear();

            statusLabelStopWatch.Text = "Ready";
            statusLabelTask.Text = "";
            statusLabelPercent.Text = "";
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

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

        }
    }
}