namespace IISExpressManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblIISConfig = new System.Windows.Forms.Label();
            this.lblIISConfigStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIIS = new System.Windows.Forms.Label();
            this.lblIISStatus = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.siteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.processId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notificationIconContextItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(12, 236);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help!";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(93, 236);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblIISConfig
            // 
            this.lblIISConfig.AutoSize = true;
            this.lblIISConfig.Location = new System.Drawing.Point(391, 13);
            this.lblIISConfig.Name = "lblIISConfig";
            this.lblIISConfig.Size = new System.Drawing.Size(72, 13);
            this.lblIISConfig.TabIndex = 6;
            this.lblIISConfig.Text = "IIS Config File";
            // 
            // lblIISConfigStatus
            // 
            this.lblIISConfigStatus.AutoSize = true;
            this.lblIISConfigStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIISConfigStatus.Location = new System.Drawing.Point(469, 13);
            this.lblIISConfigStatus.Name = "lblIISConfigStatus";
            this.lblIISConfigStatus.Size = new System.Drawing.Size(57, 13);
            this.lblIISConfigStatus.TabIndex = 7;
            this.lblIISConfigStatus.Text = "Not Found";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "IIS Express Manager V0.31B";
            // 
            // lblIIS
            // 
            this.lblIIS.AutoSize = true;
            this.lblIIS.Location = new System.Drawing.Point(391, 37);
            this.lblIIS.Name = "lblIIS";
            this.lblIIS.Size = new System.Drawing.Size(60, 13);
            this.lblIIS.TabIndex = 9;
            this.lblIIS.Text = "IIS Express";
            // 
            // lblIISStatus
            // 
            this.lblIISStatus.AutoSize = true;
            this.lblIISStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIISStatus.Location = new System.Drawing.Point(469, 37);
            this.lblIISStatus.Name = "lblIISStatus";
            this.lblIISStatus.Size = new System.Drawing.Size(57, 13);
            this.lblIISStatus.TabIndex = 10;
            this.lblIISStatus.Text = "Not Found";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.siteName,
            this.status,
            this.processId});
            this.listView1.Location = new System.Drawing.Point(12, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(373, 191);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.ListViewDoubleClickItem);
            // 
            // id
            // 
            this.id.Text = "ID";
            // 
            // siteName
            // 
            this.siteName.Text = "Name";
            this.siteName.Width = 143;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 86;
            // 
            // processId
            // 
            this.processId.Text = "Process ID";
            this.processId.Width = 74;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(394, 76);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(142, 128);
            this.textBox1.TabIndex = 12;
            // 
            // btnStopAll
            // 
            this.btnStopAll.Location = new System.Drawing.Point(93, 210);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(75, 23);
            this.btnStopAll.TabIndex = 13;
            this.btnStopAll.Text = "Stop All";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // btnResetAll
            // 
            this.btnResetAll.Location = new System.Drawing.Point(174, 210);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(75, 23);
            this.btnResetAll.TabIndex = 14;
            this.btnResetAll.Text = "Reset";
            this.btnResetAll.UseVisualStyleBackColor = true;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IIS Express Manager";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notificationIconContextItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 26);
            // 
            // notificationIconContextItem1
            // 
            this.notificationIconContextItem1.Name = "notificationIconContextItem1";
            this.notificationIconContextItem1.Size = new System.Drawing.Size(92, 22);
            this.notificationIconContextItem1.Text = "Exit";
            this.notificationIconContextItem1.Click += new System.EventHandler(this.NotificationIconContextItem1Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 210);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 268);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnResetAll);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblIISStatus);
            this.Controls.Add(this.lblIIS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIISConfigStatus);
            this.Controls.Add(this.lblIISConfig);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(564, 307);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IISExpressManager (Beta)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingEvent);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblIISConfig;
        private System.Windows.Forms.Label lblIISConfigStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIIS;
        private System.Windows.Forms.Label lblIISStatus;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader siteName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnResetAll;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem notificationIconContextItem1;
        private System.Windows.Forms.ColumnHeader processId;
        private System.Windows.Forms.Button btnRefresh;
    }
}

