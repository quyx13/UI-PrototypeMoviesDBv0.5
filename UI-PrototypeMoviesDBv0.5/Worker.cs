using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace UI_PrototypeMoviesDBv0._5
{
    public class Worker : Control
    {
        private Button buttonStart;
        private Button buttonSettings;
        private ComboBox comboBox;
        private TextBox textBox;
        private ToolStripStatusLabel statusLabelStopWatch;
        private ToolStripStatusLabel statusLabelTask;
        private ToolStripStatusLabel statusLabelPercentage;
        private ToolStripStatusLabel statusLabelInfo;
        private ToolStripProgressBar statusProgressBar;

        private int number = 0;
        private double numberDouble = (double)0;

        public bool run = false;

        public Worker(Dictionary<string, Object> controls)
        {
            this.buttonStart = (Button)controls["buttonStart"];
            this.buttonSettings = (Button)controls["buttonSettings"];
            this.comboBox = (ComboBox)controls["comboBox"];
            this.textBox = (TextBox)controls["textBox"];
            this.statusLabelStopWatch = (ToolStripStatusLabel)controls["statusLabelStopWatch"];
            this.statusLabelTask = (ToolStripStatusLabel)controls["statusLabelTask"];
            this.statusLabelPercentage = (ToolStripStatusLabel)controls["statusLabelPercentage"];
            this.statusLabelInfo = (ToolStripStatusLabel)controls["statusLabelInfo"];
            this.statusProgressBar = (ToolStripProgressBar)controls["statusProgressBar"];
        }

        public void SetNumber(int number)
        {
            this.number = number;
            this.numberDouble = (double)number;
            statusProgressBar.Maximum = number;
        }

        private void UpdateButtons(string text, bool isEnabled)
        {
            this.Invoke(new Action(() => buttonStart.Text = text));
            this.Invoke(new Action(() => buttonSettings.Enabled = isEnabled));
        }

        private void UpdateComboBox(bool isEnabled)
        {
            this.Invoke(new Action(() => comboBox.Enabled = isEnabled));
        }

        private void UpdateTextBox(string text)
        {
            this.Invoke(new Action(() => textBox.AppendText(text + Environment.NewLine)));
            this.Invoke(new Action(() => ScrollToEnd()));
        }

        private void ScrollToEnd()
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }

        private void UpdateLabelInfo(string text)
        {
            this.Invoke(new Action(() => statusLabelInfo.Text = text));
        }

        private void UpdateLabelTask(string text)
        {
            this.Invoke(new Action(() => statusLabelTask.Text = text));
        }

        private void UpdateProgressbar()
        {
            this.Invoke(new Action(() => statusProgressBar.Value++));
        }

        private void UpdateLabelPercentage(string text)
        {
            this.Invoke(new Action(() => statusLabelPercentage.Text = text));
        }

        private void UpdateLabelStopWatch(int i, TimeSpan timeSpan)
        {
            if (i > 0)
            {
                var timeLeft = TimeSpan.FromMilliseconds((number - i) * ((int)timeSpan.TotalMilliseconds / i));
                this.Invoke(new Action(() => statusLabelStopWatch.Text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:" +
                $"{timeSpan.Seconds:D2} (left: {timeLeft.Hours:D2}:{timeLeft.Minutes:D2}:{timeLeft.Seconds:D2})"));
            }
            else
            {
                this.Invoke(new Action(() => statusLabelStopWatch.Text = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:" +
                $"{timeSpan.Seconds:D2} (left: ZZ:ZZ:ZZ)"));
            }
        }

        public void DoWork()
        {
            var timer = new Stopwatch();
            timer.Start();

            UpdateButtons("Stop", false);
            UpdateComboBox(false);
            UpdateLabelInfo("Running");
            run = true;

            for (int i = 0; i < number;)
            {
                if (run)
                {
                    #region eigentliche Arbeit
                    if ((i + 1) % 100 == 0)
                        UpdateTextBox((i + 1).ToString());
                    UpdateLabelTask($"{string.Format("{0:0,0}", (i + 1))} of {string.Format("{0:0,0}", (number))}");
                    UpdateProgressbar();
                    UpdateLabelPercentage($"{(i / numberDouble * 100):F1}" + "%");
                    UpdateLabelStopWatch(i, timer.Elapsed);

                    i++;
                    #endregion
                }
                else
                {
                    break;
                }
            }

            UpdateButtons("Start", true);
            UpdateComboBox(true);
            UpdateLabelInfo("Done");
            run = false;

            timer.Reset();
        }
    }
}