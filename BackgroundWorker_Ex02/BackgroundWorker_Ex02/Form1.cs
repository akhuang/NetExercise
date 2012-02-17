using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace BackgroundWorker_Ex02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Hook up event handlers.
            this.primeNumberCalculator1.CalculatePrimeCompleted +=
                new CalculatePrimeCompletedEventHandler(
                primeNumberCalculator1_CalculatePrimeCompleted);

            this.primeNumberCalculator1.ProgressChanged +=
                new ProgressChangedEventHandler(
                primeNumberCalculator1_ProgressChanged);

            this.listView1.SelectedIndexChanged +=
                new EventHandler(listView1_SelectedIndexChanged);
        }

        /////////////////////////////////////////////////////////////
        //
        #region Implementation
        // This event handler selects a number randomly to test
        // for primality. It then starts the asynchronous 
        // calculation by calling the PrimeNumberCalculator
        // component's CalculatePrimeAsync method.
        private void startAsyncButton_Click(
            System.Object sender, System.EventArgs e)
        {
            // Randomly choose test numbers 
            // up to 200,000 for primality.
            Random rand = new Random();
            int testNumber = rand.Next(200000);

            // Task IDs are Guids.
            Guid taskId = Guid.NewGuid();
            this.AddListViewItem(taskId, testNumber);

            // Start the asynchronous task.
            this.primeNumberCalculator1.CalculatePrimeAsync(
                testNumber,
                taskId);
        }

        private void listView1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            this.cancelButton.Enabled = CanCancel();
        }

        // This event handler cancels all pending tasks that are
        // selected in the ListView control.
        private void cancelButton_Click(
            System.Object sender,
            System.EventArgs e)
        {
            Guid taskId = Guid.Empty;

            // Cancel all selected tasks.
            foreach (ListViewItem lvi in this.listView1.SelectedItems)
            {
                // Tasks that have been completed or canceled have 
                // their corresponding ListViewItem.Tag property
                // set to null.
                if (lvi.Tag != null)
                {
                    taskId = (Guid)lvi.Tag;
                    this.primeNumberCalculator1.CancelAsync(taskId);
                    lvi.Selected = false;
                }
            }

            cancelButton.Enabled = false;
        }

        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the ProgressChanged event.
        //
        // On fast computers, the PrimeNumberCalculator can raise many
        // successive ProgressChanged events, so the user interface 
        // may be flooded with messages. To prevent the user interface
        // from hanging, progress is only reported at intervals. 
        private void primeNumberCalculator1_ProgressChanged(
            ProgressChangedEventArgs e)
        {
            if (this.progressCounter++ % this.progressInterval == 0)
            {
                Guid taskId = (Guid)e.UserState;

                if (e is CalculatePrimeProgressChangedEventArgs)
                {
                    CalculatePrimeProgressChangedEventArgs cppcea =
                        e as CalculatePrimeProgressChangedEventArgs;

                    this.UpdateListViewItem(
                        taskId,
                        cppcea.ProgressPercentage,
                        cppcea.LatestPrimeNumber);
                }
                else
                {
                    this.UpdateListViewItem(
                        taskId,
                        e.ProgressPercentage);
                }
            }
            else if (this.progressCounter > this.progressInterval)
            {
                this.progressCounter = 0;
            }
        }

        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the CalculatePrimeCompleted
        // event. The ListView item is updated with the appropriate
        // outcome of the calculation: Canceled, Error, or result.
        private void primeNumberCalculator1_CalculatePrimeCompleted(
            object sender,
            CalculatePrimeCompletedEventArgs e)
        {
            Guid taskId = (Guid)e.UserState;

            if (e.Cancelled)
            {
                string result = "Canceled";

                ListViewItem lvi = UpdateListViewItem(taskId, result);

                if (lvi != null)
                {
                    lvi.BackColor = Color.Pink;
                    lvi.Tag = null;
                }
            }
            else if (e.Error != null)
            {
                string result = "Error";

                ListViewItem lvi = UpdateListViewItem(taskId, result);

                if (lvi != null)
                {
                    lvi.BackColor = Color.Red;
                    lvi.ForeColor = Color.White;
                    lvi.Tag = null;
                }
            }
            else
            {
                bool result = e.IsPrime;

                ListViewItem lvi = UpdateListViewItem(
                    taskId,
                    result,
                    e.FirstDivisor);

                if (lvi != null)
                {
                    lvi.BackColor = Color.LightGray;
                    lvi.Tag = null;
                }
            }
        }

        #endregion // Implementation

        /////////////////////////////////////////////////////////////
        //
        #region Private Methods

        private ListViewItem AddListViewItem(
            Guid guid,
            int testNumber)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = testNumber.ToString(
                CultureInfo.CurrentCulture.NumberFormat);

            lvi.SubItems.Add("Not Started");
            lvi.SubItems.Add("1");
            lvi.SubItems.Add(guid.ToString());
            lvi.SubItems.Add("---");
            lvi.SubItems.Add("---");
            lvi.Tag = guid;

            this.listView1.Items.Add(lvi);

            return lvi;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            int percentComplete,
            int current)
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[1].Text =
                            percentComplete.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lvi.SubItems[2].Text =
                            current.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            int percentComplete,
            int current,
            bool result,
            int firstDivisor)
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if ((Guid)lvi.Tag == guid)
                {
                    lvi.SubItems[1].Text =
                        percentComplete.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lvi.SubItems[2].Text =
                        current.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lvi.SubItems[4].Text =
                        result ? "Prime" : "Composite";
                    lvi.SubItems[5].Text =
                        firstDivisor.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);

                    lviRet = lvi;

                    break;
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            int percentComplete)
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[1].Text =
                            percentComplete.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            bool result,
            int firstDivisor)
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[4].Text =
                            result ? "Prime" : "Composite";
                        lvi.SubItems[5].Text =
                            firstDivisor.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            string result)
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[4].Text = result;
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private bool CanCancel()
        {
            bool oneIsActive = false;

            foreach (ListViewItem lvi in this.listView1.SelectedItems)
            {
                if (lvi.Tag != null)
                {
                    oneIsActive = true;
                    break;
                }
            }

            return (oneIsActive == true);
        }

        #endregion 
    }
}
