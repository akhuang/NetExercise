using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackgroundWorker_Ex03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeMultiDelegate();
        }

        private void InitializeMultiDelegate()
        {
            multiBackgroundWorker1.DoWork += new Core.MultiDoWorkerEventHandler(multiBackgroundWorker1_DoWork);
            multiBackgroundWorker1.ProgressChanged += new Core.MultiProgressChangedEventHandler(multiBackgroundWorker1_ProgressChanged);
            multiBackgroundWorker1.RunWorkerCompleted += new Core.MultiRunWorkerCompletedEventHandler(multiBackgroundWorker1_RunWorkerCompleted);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
             Random rand = new Random();
            int testNumber = rand.Next(50,100);

            Guid guid=Guid.NewGuid();
           
            multiBackgroundWorker1.RunWorkerAsync(guid,
        }

        void multiBackgroundWorker1_DoWork(object sender, Core.MultiDoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        void multiBackgroundWorker1_ProgressChanged(object sender, Core.MultiProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        void multiBackgroundWorker1_RunWorkerCompleted(object sender, Core.MultiRunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
