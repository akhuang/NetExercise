using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AD101CNET.FileData;
using Core;
using System.Threading;
using System.Diagnostics;

namespace BackgroundWorker_Ex03
{
    public partial class Form2 : Form
    {
        FileDataCollection listData = new FileDataCollection();
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = listData;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int testNumber = rand.Next(50, 100);

            Guid guid = Guid.NewGuid();
            AddToListView(guid.ToString());

            this.multiBackgroundWorker1.RunWorkerAsync(guid.ToString(), testNumber);
        }

        private void AddToListView(string taskId)
        {
            FileData data = new FileData();
            data.TaskId = taskId;
            data.Tag = taskId;
            //data.ProgressPercentage;
            data.ThreadId = "--";
            data.Result = "--";
            listData.Add(data);

        }

        void multiBackgroundWorker1_DoWork(object sender, Core.MultiDoWorkEventArgs e)
        {
            //e.ta
            string taskId = e.TaskID.ToString();
            e.Result = Compute(taskId, (MultiBackgroundWorker)sender, e);
        }

        void multiBackgroundWorker1_ProgressChanged(object sender, Core.MultiProgressChangedEventArgs e)
        {
            UpdateListView((string)e.TaskID, e.ProgressPercentage, e.UserState);
        }

        private object Compute(string taskId, MultiBackgroundWorker multiBackgroundWorker, MultiDoWorkEventArgs e)
        {
            long result = 0;
            int n = 200;
            for (int i = 1; i <= n; i++)
            {
                //应该判断任务是否已被移除或取消
                if (multiBackgroundWorker.WhetherTaskCancelledOrNot(taskId))
                {
                    e.Cancel = true;
                    break;
                }
                result += i;
                Thread.Sleep(500);
                int progressPercentage = (int)((float)i / (float)n * 100);
                multiBackgroundWorker.ReportProgress(taskId, progressPercentage, Thread.CurrentThread.ManagedThreadId);
            }

            return result;
        }



        private void UpdateListView(string taskId, int progressPercentage, object threadId)
        {
            //listView1.BeginUpdate();
            //foreach (ListViewItem lvi in listView1.Items)
            //{
            //    if (lvi.Tag != null && lvi.Tag.ToString() == taskId)
            //    {
            //        lvi.SubItems[1].Text = progressPercentage.ToString(CultureInfo.CurrentCulture.NumberFormat) + "%";
            //        lvi.SubItems[2].Text = threadId.ToString();

            //        break;
            //    }
            //}
            //listView1.EndUpdate();

            foreach (FileData item in listData)
            {
                if (item.Tag != null && item.Tag == taskId)
                {
                    item.ProgressPercentage = progressPercentage;
                    item.ThreadId = threadId.ToString();
                    break;
                }
            }
        }


        void multiBackgroundWorker1_RunWorkerCompleted(object sender, Core.MultiRunWorkerCompletedEventArgs e)
        {
            //3步
            //1.判断是否出现错误
            //2.判断是否被取消
            //3.已成功.
            FileData model = null;
            string taskId = e.TaskId.ToString();
            if (e.Error != null)
            {
                model = UpdateListView(taskId, "Error");
            }
            else if (e.Cancelled)
            {
                model = UpdateListView(taskId, "Cancelled");
            }
            else
            {
                model = UpdateListView(taskId, e.Result.ToString());
            }
            Debug.WriteLine(model == null);
            if (model != null)
                model.Tag = null;
        }

        private FileData UpdateListView(string taskId, string result)
        {
            //listView1.BeginUpdate();
            //ListViewItem lvi = null;
            //foreach (ListViewItem item in this.listView1.Items)
            //{
            //    if (item.Tag != null && item.Tag.ToString() == taskId)
            //    {
            //        item.SubItems[3].Text = result;

            //        lvi = item;
            //        break;
            //    }
            //}


            //listView1.EndUpdate();

            //return lvi;

            FileData model = null;
            for (int i = 0; i < listData.Count; i++)
            {
                FileData item = listData[i];
                if (item.Tag != null && item.Tag == taskId)
                {
                    item.Result = result;
                    model = item;
                    break;
                }
            }

            return model;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in listView1.SelectedItems)
            //{
            //    if (item != null && item.Tag != null)
            //    {
            //        multiBackgroundWorker1.CancelAsync(item.Tag);
            //    }
            //    item.Selected = false;
            //}
            foreach (DataGridViewRow dgv in dataGridView1.SelectedRows)
            {
                string taskId = dgv.Cells[4].Value.ToString();
                if (!string.IsNullOrEmpty(taskId))
                {
                    multiBackgroundWorker1.CancelAsync(taskId);
                }

                //for (int i = 0; i < listData.Count; i++)
                //{
                //    FileData item = listData[i];
                //    if (item != null && item.Tag == taskId)
                //    {
                //        item.Tag = null;
                //        break;
                //    }
                //}

            }
        }





    }
}
