namespace TestForm
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
            this.logTxt = new System.Windows.Forms.TextBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.printPeersBtn = new System.Windows.Forms.Button();
            this.fetchBlockBtn = new System.Windows.Forms.Button();
            this.blockHashTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logTxt
            // 
            this.logTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTxt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTxt.Location = new System.Drawing.Point(12, 12);
            this.logTxt.Multiline = true;
            this.logTxt.Name = "logTxt";
            this.logTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTxt.Size = new System.Drawing.Size(640, 375);
            this.logTxt.TabIndex = 0;
            // 
            // goBtn
            // 
            this.goBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.goBtn.Location = new System.Drawing.Point(577, 434);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 1;
            this.goBtn.Text = "Go!";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // printPeersBtn
            // 
            this.printPeersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printPeersBtn.Location = new System.Drawing.Point(13, 394);
            this.printPeersBtn.Name = "printPeersBtn";
            this.printPeersBtn.Size = new System.Drawing.Size(75, 23);
            this.printPeersBtn.TabIndex = 2;
            this.printPeersBtn.Text = "Print Peers";
            this.printPeersBtn.UseVisualStyleBackColor = true;
            this.printPeersBtn.Click += new System.EventHandler(this.printPeersBtn_Click);
            // 
            // fetchBlockBtn
            // 
            this.fetchBlockBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fetchBlockBtn.Location = new System.Drawing.Point(358, 393);
            this.fetchBlockBtn.Name = "fetchBlockBtn";
            this.fetchBlockBtn.Size = new System.Drawing.Size(75, 23);
            this.fetchBlockBtn.TabIndex = 3;
            this.fetchBlockBtn.Text = "Fetch Block";
            this.fetchBlockBtn.UseVisualStyleBackColor = true;
            this.fetchBlockBtn.Click += new System.EventHandler(this.fetchBlockBtn_Click);
            // 
            // blockHashTxt
            // 
            this.blockHashTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.blockHashTxt.Location = new System.Drawing.Point(123, 396);
            this.blockHashTxt.Name = "blockHashTxt";
            this.blockHashTxt.Size = new System.Drawing.Size(229, 20);
            this.blockHashTxt.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 469);
            this.Controls.Add(this.blockHashTxt);
            this.Controls.Add(this.fetchBlockBtn);
            this.Controls.Add(this.printPeersBtn);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.logTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTxt;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Button printPeersBtn;
        private System.Windows.Forms.Button fetchBlockBtn;
        private System.Windows.Forms.TextBox blockHashTxt;
    }
}

