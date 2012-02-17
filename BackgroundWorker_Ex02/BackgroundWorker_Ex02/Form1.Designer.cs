namespace BackgroundWorker_Ex02
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startAsyncButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.testNumberColHeader = new System.Windows.Forms.ColumnHeader();
            this.progressColHeader = new System.Windows.Forms.ColumnHeader();
            this.currentColHeader = new System.Windows.Forms.ColumnHeader();
            this.taskIdColHeader = new System.Windows.Forms.ColumnHeader();
            this.resultColHeader = new System.Windows.Forms.ColumnHeader();
            this.firstDivisorColHeader = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.primeNumberCalculator1 = new PrimeNumberCalculator(this.components);
            this.taskGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskGroupBox
            // 
            this.taskGroupBox.Controls.Add(this.buttonPanel);
            this.taskGroupBox.Controls.Add(this.listView1);
            this.taskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskGroupBox.Location = new System.Drawing.Point(0, 0);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(608, 254);
            this.taskGroupBox.TabIndex = 1;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Tasks";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.startAsyncButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(3, 176);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(602, 75);
            this.buttonPanel.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(128, 24);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // startAsyncButton
            // 
            this.startAsyncButton.Location = new System.Drawing.Point(24, 24);
            this.startAsyncButton.Name = "startAsyncButton";
            this.startAsyncButton.Size = new System.Drawing.Size(88, 23);
            this.startAsyncButton.TabIndex = 0;
            this.startAsyncButton.Text = "Start New Task";
            this.startAsyncButton.Click += new System.EventHandler(this.startAsyncButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.testNumberColHeader,
                this.progressColHeader,
                this.currentColHeader,
                this.taskIdColHeader,
                this.resultColHeader,
                this.firstDivisorColHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(602, 160);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // testNumberColHeader
            // 
            this.testNumberColHeader.Text = "Test Number";
            this.testNumberColHeader.Width = 80;
            // 
            // progressColHeader
            // 
            this.progressColHeader.Text = "Progress";
            // 
            // currentColHeader
            // 
            this.currentColHeader.Text = "Current";
            // 
            // taskIdColHeader
            // 
            this.taskIdColHeader.Text = "Task ID";
            this.taskIdColHeader.Width = 200;
            // 
            // resultColHeader
            // 
            this.resultColHeader.Text = "Result";
            this.resultColHeader.Width = 80;
            // 
            // firstDivisorColHeader
            // 
            this.firstDivisorColHeader.Text = "First Divisor";
            this.firstDivisorColHeader.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(200, 128);
            this.panel2.Name = "panel2";
            this.panel2.TabIndex = 2;
            // 
            // PrimeNumberCalculatorMain
            // 
            this.ClientSize = new System.Drawing.Size(608, 254);
            this.Controls.Add(this.taskGroupBox);
            this.Name = "PrimeNumberCalculatorMain";
            this.Text = "Prime Number Calculator";
            this.taskGroupBox.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #region Private fields

        private PrimeNumberCalculator primeNumberCalculator1;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader taskIdColHeader;
        private System.Windows.Forms.ColumnHeader progressColHeader;
        private System.Windows.Forms.ColumnHeader currentColHeader;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button startAsyncButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader testNumberColHeader;
        private System.Windows.Forms.ColumnHeader resultColHeader;
        private System.Windows.Forms.ColumnHeader firstDivisorColHeader;
        private int progressCounter;
        private int progressInterval = 100;


        #endregion // Private fields

        #endregion
    }
}

