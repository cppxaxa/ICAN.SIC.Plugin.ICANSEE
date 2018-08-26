namespace ICAN.SIC.Plugin.ICANSEE.Host
{
    partial class ICANSEEHost
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
            this.BtnReadFBP = new System.Windows.Forms.Button();
            this.BtnShowParsedFBP = new System.Windows.Forms.Button();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.TxtFbpPath = new System.Windows.Forms.TextBox();
            this.BtnDfs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnReadFBP
            // 
            this.BtnReadFBP.Location = new System.Drawing.Point(12, 60);
            this.BtnReadFBP.Name = "BtnReadFBP";
            this.BtnReadFBP.Size = new System.Drawing.Size(308, 57);
            this.BtnReadFBP.TabIndex = 0;
            this.BtnReadFBP.Text = "Read FBP";
            this.BtnReadFBP.UseVisualStyleBackColor = true;
            this.BtnReadFBP.Click += new System.EventHandler(this.BtnReadFBP_Click);
            // 
            // BtnShowParsedFBP
            // 
            this.BtnShowParsedFBP.Location = new System.Drawing.Point(12, 123);
            this.BtnShowParsedFBP.Name = "BtnShowParsedFBP";
            this.BtnShowParsedFBP.Size = new System.Drawing.Size(308, 57);
            this.BtnShowParsedFBP.TabIndex = 1;
            this.BtnShowParsedFBP.Text = "Show parsed FBP";
            this.BtnShowParsedFBP.UseVisualStyleBackColor = true;
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(12, 186);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(308, 57);
            this.BtnExecute.TabIndex = 2;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            // 
            // TxtFbpPath
            // 
            this.TxtFbpPath.Location = new System.Drawing.Point(12, 12);
            this.TxtFbpPath.Name = "TxtFbpPath";
            this.TxtFbpPath.Size = new System.Drawing.Size(1283, 31);
            this.TxtFbpPath.TabIndex = 3;
            // 
            // BtnDfs
            // 
            this.BtnDfs.Location = new System.Drawing.Point(326, 60);
            this.BtnDfs.Name = "BtnDfs";
            this.BtnDfs.Size = new System.Drawing.Size(308, 57);
            this.BtnDfs.TabIndex = 4;
            this.BtnDfs.Text = "Get DFS";
            this.BtnDfs.UseVisualStyleBackColor = true;
            this.BtnDfs.Click += new System.EventHandler(this.BtnDfs_Click);
            // 
            // ICANSEEHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 255);
            this.Controls.Add(this.BtnDfs);
            this.Controls.Add(this.TxtFbpPath);
            this.Controls.Add(this.BtnExecute);
            this.Controls.Add(this.BtnShowParsedFBP);
            this.Controls.Add(this.BtnReadFBP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ICANSEEHost";
            this.Text = "ICANSEE Host";
            this.Load += new System.EventHandler(this.ICANSEEHost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnReadFBP;
        private System.Windows.Forms.Button BtnShowParsedFBP;
        private System.Windows.Forms.Button BtnExecute;
        private System.Windows.Forms.TextBox TxtFbpPath;
        private System.Windows.Forms.Button BtnDfs;
    }
}

