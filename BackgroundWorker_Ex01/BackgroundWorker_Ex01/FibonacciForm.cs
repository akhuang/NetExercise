using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackgroundWorker_Ex01
{
    public partial class FibonacciForm : Form
    {
        private int numberToCompute = 0;
        private int highestPercentageReached = 0;

        public FibonacciForm()
        {
            InitializeComponent();

            InitializeBackgroundWorker();

        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }


        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = ComputeFibonacci((int)e.Argument, worker, e);

        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultLabel.Text = "Canceled";
            }
            else
            {
                resultLabel.Text = e.Result.ToString();
            }

            startAsyncButton.Enabled = true;
            numericUpDown1.Enabled = true;
            cancelAsyncButton.Enabled = false;

        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }


        private void startAsyncButton_Click(System.Object sender,
          System.EventArgs e)
        {
            resultLabel.Text = string.Empty;
            numericUpDown1.Enabled = false;
            startAsyncButton.Enabled = false;
            cancelAsyncButton.Enabled = true;

            numberToCompute = (int)numericUpDown1.Value;
            highestPercentageReached = 0;

            backgroundWorker1.RunWorkerAsync(numberToCompute);
        }

        private void cancelAsyncButton_Click(System.Object sender,
           System.EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            cancelAsyncButton.Enabled = false;

        }


        private long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if ((n < 0) || (n > 91))
            {
                throw new ArgumentOutOfRangeException("value must be >=0 and <=91", "n");
            }

            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (n < 2)
                {
                    result = 1;
                }
                else
                {
                    result = ComputeFibonacci(n - 1, worker, e) + ComputeFibonacci(n - 2, worker, e);
                }

                int percentComplete = (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }

            return result;

        }
    }
}
