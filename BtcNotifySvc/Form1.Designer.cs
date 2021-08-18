namespace BtcNotifySvc
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
            this.logTxt = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.sendRawTxt = new System.Windows.Forms.TextBox();
            this.sendrawBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.transLogTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectedTimeLBL = new System.Windows.Forms.ToolStripStatusLabel();
            this.autosaveTOOL = new System.Windows.Forms.ToolStripSplitButton();
            this.autosaveCHKTOOL = new System.Windows.Forms.ToolStripMenuItem();
            this.txpersecLBL = new System.Windows.Forms.ToolStripStatusLabel();
            this.txPB = new System.Windows.Forms.ToolStripProgressBar();
            this.btcpersecLBL = new System.Windows.Forms.ToolStripStatusLabel();
            this.btcPB = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nodeTXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.faketxAddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.faketxNUD = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.faketxBTN = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.notifyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faketxNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // logTxt
            // 
            this.logTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTxt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTxt.Location = new System.Drawing.Point(0, 0);
            this.logTxt.Margin = new System.Windows.Forms.Padding(4);
            this.logTxt.Multiline = true;
            this.logTxt.Name = "logTxt";
            this.logTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTxt.Size = new System.Drawing.Size(632, 441);
            this.logTxt.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Green;
            this.startBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startBtn.FlatAppearance.BorderSize = 3;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(335, 30);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(215, 53);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.BackColor = System.Drawing.Color.Maroon;
            this.stopBtn.Enabled = false;
            this.stopBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopBtn.FlatAppearance.BorderSize = 4;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopBtn.Location = new System.Drawing.Point(558, 30);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(4);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(215, 53);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "Disconnect";
            this.stopBtn.UseVisualStyleBackColor = false;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1561, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Send to Named Pipe:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sendRawTxt
            // 
            this.sendRawTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendRawTxt.Location = new System.Drawing.Point(1521, 26);
            this.sendRawTxt.Margin = new System.Windows.Forms.Padding(4);
            this.sendRawTxt.Multiline = true;
            this.sendRawTxt.Name = "sendRawTxt";
            this.sendRawTxt.Size = new System.Drawing.Size(247, 54);
            this.sendRawTxt.TabIndex = 9;
            this.sendRawTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendRawTxt_KeyDown);
            // 
            // sendrawBtn
            // 
            this.sendrawBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendrawBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendrawBtn.ForeColor = System.Drawing.Color.White;
            this.sendrawBtn.Location = new System.Drawing.Point(1776, 26);
            this.sendrawBtn.Margin = new System.Windows.Forms.Padding(4);
            this.sendrawBtn.Name = "sendrawBtn";
            this.sendrawBtn.Size = new System.Drawing.Size(65, 54);
            this.sendrawBtn.TabIndex = 10;
            this.sendrawBtn.Text = "Send";
            this.sendrawBtn.UseVisualStyleBackColor = true;
            this.sendrawBtn.Click += new System.EventHandler(this.sendrawBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.notifyMenu;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1857, 326);
            this.dataGridView1.TabIndex = 11;
            // 
            // notifyMenu
            // 
            this.notifyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyDeleteMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.ShowImageMargin = false;
            this.notifyMenu.Size = new System.Drawing.Size(98, 28);
            // 
            // notifyDeleteMenuItem
            // 
            this.notifyDeleteMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.notifyDeleteMenuItem.ForeColor = System.Drawing.Color.Tomato;
            this.notifyDeleteMenuItem.Name = "notifyDeleteMenuItem";
            this.notifyDeleteMenuItem.Size = new System.Drawing.Size(97, 24);
            this.notifyDeleteMenuItem.Text = "Delete";
            this.notifyDeleteMenuItem.Click += new System.EventHandler(this.notifyDeleteMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.logTxt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.transLogTxt);
            this.splitContainer1.Size = new System.Drawing.Size(1857, 441);
            this.splitContainer1.SplitterDistance = 632;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Application Log:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Transaction Log:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transLogTxt
            // 
            this.transLogTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transLogTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transLogTxt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transLogTxt.Location = new System.Drawing.Point(0, 0);
            this.transLogTxt.Margin = new System.Windows.Forms.Padding(4);
            this.transLogTxt.Multiline = true;
            this.transLogTxt.Name = "transLogTxt";
            this.transLogTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.transLogTxt.Size = new System.Drawing.Size(1220, 441);
            this.transLogTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(1582, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "id,1btcaddr,https://url.com?val={btc}";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1506, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Format:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectedTimeLBL,
            this.autosaveTOOL,
            this.txpersecLBL,
            this.txPB,
            this.btcpersecLBL,
            this.btcPB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 811);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1857, 34);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connectedTimeLBL
            // 
            this.connectedTimeLBL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.connectedTimeLBL.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.connectedTimeLBL.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.connectedTimeLBL.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedTimeLBL.ForeColor = System.Drawing.Color.RoyalBlue;
            this.connectedTimeLBL.Name = "connectedTimeLBL";
            this.connectedTimeLBL.Size = new System.Drawing.Size(135, 29);
            this.connectedTimeLBL.Text = "Disconnected ";
            // 
            // autosaveTOOL
            // 
            this.autosaveTOOL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.autosaveTOOL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autosaveCHKTOOL});
            this.autosaveTOOL.ForeColor = System.Drawing.Color.Black;
            this.autosaveTOOL.Image = global::BtcNotifySvc.Properties.Resources.imageres_106;
            this.autosaveTOOL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.autosaveTOOL.Name = "autosaveTOOL";
            this.autosaveTOOL.Size = new System.Drawing.Size(109, 32);
            this.autosaveTOOL.Text = "Autosave";
            // 
            // autosaveCHKTOOL
            // 
            this.autosaveCHKTOOL.BackColor = System.Drawing.Color.White;
            this.autosaveCHKTOOL.Checked = true;
            this.autosaveCHKTOOL.CheckOnClick = true;
            this.autosaveCHKTOOL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autosaveCHKTOOL.ForeColor = System.Drawing.Color.Black;
            this.autosaveCHKTOOL.Name = "autosaveCHKTOOL";
            this.autosaveCHKTOOL.Size = new System.Drawing.Size(151, 26);
            this.autosaveCHKTOOL.Text = "Auto Save";
            this.autosaveCHKTOOL.CheckedChanged += new System.EventHandler(this.autosaveCHKTOOL_CheckedChanged);
            // 
            // txpersecLBL
            // 
            this.txpersecLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.txpersecLBL.ForeColor = System.Drawing.Color.White;
            this.txpersecLBL.Name = "txpersecLBL";
            this.txpersecLBL.Size = new System.Drawing.Size(1276, 29);
            this.txpersecLBL.Spring = true;
            this.txpersecLBL.Text = "TX/Sec: 0";
            this.txpersecLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txPB
            // 
            this.txPB.AutoToolTip = true;
            this.txPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txPB.Maximum = 0;
            this.txPB.Name = "txPB";
            this.txPB.Size = new System.Drawing.Size(100, 28);
            this.txPB.Step = 1;
            this.txPB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // btcpersecLBL
            // 
            this.btcpersecLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btcpersecLBL.ForeColor = System.Drawing.Color.White;
            this.btcpersecLBL.Name = "btcpersecLBL";
            this.btcpersecLBL.Size = new System.Drawing.Size(118, 29);
            this.btcpersecLBL.Text = "BTC/sec: 0.00000";
            // 
            // btcPB
            // 
            this.btcPB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btcPB.Maximum = 0;
            this.btcPB.Name = "btcPB";
            this.btcPB.Size = new System.Drawing.Size(100, 28);
            this.btcPB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nodeTXT
            // 
            this.nodeTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeTXT.Location = new System.Drawing.Point(16, 38);
            this.nodeTXT.Name = "nodeTXT";
            this.nodeTXT.Size = new System.Drawing.Size(312, 30);
            this.nodeTXT.TabIndex = 20;
            this.nodeTXT.Text = "127.0.0.1:8333";
            this.nodeTXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Bitcoin Node:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(843, -1);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "Watching Notifies:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.splitContainer2.Location = new System.Drawing.Point(0, 109);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Size = new System.Drawing.Size(1857, 695);
            this.splitContainer2.SplitterDistance = 441;
            this.splitContainer2.TabIndex = 27;
            // 
            // faketxAddr
            // 
            this.faketxAddr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.faketxAddr.Location = new System.Drawing.Point(1010, 30);
            this.faketxAddr.Margin = new System.Windows.Forms.Padding(4);
            this.faketxAddr.Multiline = true;
            this.faketxAddr.Name = "faketxAddr";
            this.faketxAddr.Size = new System.Drawing.Size(394, 28);
            this.faketxAddr.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1194, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Send a Fake TX:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // faketxNUD
            // 
            this.faketxNUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.faketxNUD.DecimalPlaces = 8;
            this.faketxNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.faketxNUD.Location = new System.Drawing.Point(1276, 65);
            this.faketxNUD.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.faketxNUD.Name = "faketxNUD";
            this.faketxNUD.Size = new System.Drawing.Size(128, 22);
            this.faketxNUD.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1130, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Amount (BTC):";
            // 
            // faketxBTN
            // 
            this.faketxBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.faketxBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faketxBTN.ForeColor = System.Drawing.Color.White;
            this.faketxBTN.Location = new System.Drawing.Point(1412, 31);
            this.faketxBTN.Margin = new System.Windows.Forms.Padding(4);
            this.faketxBTN.Name = "faketxBTN";
            this.faketxBTN.Size = new System.Drawing.Size(65, 54);
            this.faketxBTN.TabIndex = 32;
            this.faketxBTN.Text = "Send";
            this.faketxBTN.UseVisualStyleBackColor = true;
            this.faketxBTN.Click += new System.EventHandler(this.faketxBTN_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1857, 845);
            this.Controls.Add(this.faketxBTN);
            this.Controls.Add(this.faketxNUD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.faketxAddr);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.sendrawBtn);
            this.Controls.Add(this.sendRawTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nodeTXT);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Bitcoin Notify Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.notifyMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.faketxNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTxt;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sendRawTxt;
        private System.Windows.Forms.Button sendrawBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox transLogTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel connectedTimeLBL;
        private System.Windows.Forms.ToolStripStatusLabel txpersecLBL;
        private System.Windows.Forms.ToolStripProgressBar txPB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel btcpersecLBL;
        private System.Windows.Forms.ToolStripProgressBar btcPB;
        private System.Windows.Forms.TextBox nodeTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem notifyDeleteMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox faketxAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown faketxNUD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button faketxBTN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripSplitButton autosaveTOOL;
        private System.Windows.Forms.ToolStripMenuItem autosaveCHKTOOL;
    }
}

