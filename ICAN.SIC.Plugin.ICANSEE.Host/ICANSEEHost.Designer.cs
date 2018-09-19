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
            this.BtnDummyCall = new System.Windows.Forms.Button();
            this.BtnAddCameraConfig = new System.Windows.Forms.Button();
            this.BtnLoadCameraConfig = new System.Windows.Forms.Button();
            this.BtnListAllCameraConfigs = new System.Windows.Forms.Button();
            this.BtnListAllGPUAlgos = new System.Windows.Forms.Button();
            this.BtnRunGPUAlgo = new System.Windows.Forms.Button();
            this.BtnLoadAlgorithm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnReadFBP
            // 
            this.BtnReadFBP.Location = new System.Drawing.Point(8, 38);
            this.BtnReadFBP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReadFBP.Name = "BtnReadFBP";
            this.BtnReadFBP.Size = new System.Drawing.Size(205, 36);
            this.BtnReadFBP.TabIndex = 0;
            this.BtnReadFBP.Text = "Read FBP";
            this.BtnReadFBP.UseVisualStyleBackColor = true;
            this.BtnReadFBP.Click += new System.EventHandler(this.BtnReadFBP_Click);
            // 
            // BtnShowParsedFBP
            // 
            this.BtnShowParsedFBP.Location = new System.Drawing.Point(8, 79);
            this.BtnShowParsedFBP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnShowParsedFBP.Name = "BtnShowParsedFBP";
            this.BtnShowParsedFBP.Size = new System.Drawing.Size(205, 36);
            this.BtnShowParsedFBP.TabIndex = 1;
            this.BtnShowParsedFBP.Text = "Show parsed FBP";
            this.BtnShowParsedFBP.UseVisualStyleBackColor = true;
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(8, 119);
            this.BtnExecute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(205, 36);
            this.BtnExecute.TabIndex = 2;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            // 
            // TxtFbpPath
            // 
            this.TxtFbpPath.Location = new System.Drawing.Point(8, 7);
            this.TxtFbpPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtFbpPath.Name = "TxtFbpPath";
            this.TxtFbpPath.Size = new System.Drawing.Size(857, 22);
            this.TxtFbpPath.TabIndex = 3;
            // 
            // BtnDfs
            // 
            this.BtnDfs.Location = new System.Drawing.Point(217, 38);
            this.BtnDfs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDfs.Name = "BtnDfs";
            this.BtnDfs.Size = new System.Drawing.Size(205, 36);
            this.BtnDfs.TabIndex = 4;
            this.BtnDfs.Text = "Get DFS";
            this.BtnDfs.UseVisualStyleBackColor = true;
            this.BtnDfs.Click += new System.EventHandler(this.BtnDfs_Click);
            // 
            // BtnDummyCall
            // 
            this.BtnDummyCall.Location = new System.Drawing.Point(427, 38);
            this.BtnDummyCall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDummyCall.Name = "BtnDummyCall";
            this.BtnDummyCall.Size = new System.Drawing.Size(204, 36);
            this.BtnDummyCall.TabIndex = 5;
            this.BtnDummyCall.Text = "Make a Call";
            this.BtnDummyCall.UseVisualStyleBackColor = true;
            this.BtnDummyCall.Click += new System.EventHandler(this.BtnDummyCall_Click);
            // 
            // BtnAddCameraConfig
            // 
            this.BtnAddCameraConfig.Location = new System.Drawing.Point(233, 86);
            this.BtnAddCameraConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAddCameraConfig.Name = "BtnAddCameraConfig";
            this.BtnAddCameraConfig.Size = new System.Drawing.Size(189, 28);
            this.BtnAddCameraConfig.TabIndex = 6;
            this.BtnAddCameraConfig.Text = "AddCameraConfig";
            this.BtnAddCameraConfig.UseVisualStyleBackColor = true;
            this.BtnAddCameraConfig.Click += new System.EventHandler(this.BtnAddCameraConfig_Click);
            // 
            // BtnLoadCameraConfig
            // 
            this.BtnLoadCameraConfig.Location = new System.Drawing.Point(233, 119);
            this.BtnLoadCameraConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLoadCameraConfig.Name = "BtnLoadCameraConfig";
            this.BtnLoadCameraConfig.Size = new System.Drawing.Size(189, 28);
            this.BtnLoadCameraConfig.TabIndex = 7;
            this.BtnLoadCameraConfig.Text = "LoadCameraConfig";
            this.BtnLoadCameraConfig.UseVisualStyleBackColor = true;
            this.BtnLoadCameraConfig.Click += new System.EventHandler(this.BtnLoadCameraConfig_Click);
            // 
            // BtnListAllCameraConfigs
            // 
            this.BtnListAllCameraConfigs.Location = new System.Drawing.Point(431, 86);
            this.BtnListAllCameraConfigs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnListAllCameraConfigs.Name = "BtnListAllCameraConfigs";
            this.BtnListAllCameraConfigs.Size = new System.Drawing.Size(189, 28);
            this.BtnListAllCameraConfigs.TabIndex = 8;
            this.BtnListAllCameraConfigs.Text = "ListAllCameraConfigs";
            this.BtnListAllCameraConfigs.UseVisualStyleBackColor = true;
            this.BtnListAllCameraConfigs.Click += new System.EventHandler(this.BtnListAllCameraConfigs_Click);
            // 
            // BtnListAllGPUAlgos
            // 
            this.BtnListAllGPUAlgos.Location = new System.Drawing.Point(431, 119);
            this.BtnListAllGPUAlgos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnListAllGPUAlgos.Name = "BtnListAllGPUAlgos";
            this.BtnListAllGPUAlgos.Size = new System.Drawing.Size(189, 28);
            this.BtnListAllGPUAlgos.TabIndex = 9;
            this.BtnListAllGPUAlgos.Text = "ListAllGPUAlgos";
            this.BtnListAllGPUAlgos.UseVisualStyleBackColor = true;
            this.BtnListAllGPUAlgos.Click += new System.EventHandler(this.BtnListAllGPUAlgos_Click);
            // 
            // BtnRunGPUAlgo
            // 
            this.BtnRunGPUAlgo.Location = new System.Drawing.Point(628, 86);
            this.BtnRunGPUAlgo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnRunGPUAlgo.Name = "BtnRunGPUAlgo";
            this.BtnRunGPUAlgo.Size = new System.Drawing.Size(189, 28);
            this.BtnRunGPUAlgo.TabIndex = 10;
            this.BtnRunGPUAlgo.Text = "RunGPUAlgo";
            this.BtnRunGPUAlgo.UseVisualStyleBackColor = true;
            this.BtnRunGPUAlgo.Click += new System.EventHandler(this.BtnRunGPUAlgo_Click);
            // 
            // BtnLoadAlgorithm
            // 
            this.BtnLoadAlgorithm.Location = new System.Drawing.Point(628, 119);
            this.BtnLoadAlgorithm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnLoadAlgorithm.Name = "BtnLoadAlgorithm";
            this.BtnLoadAlgorithm.Size = new System.Drawing.Size(189, 28);
            this.BtnLoadAlgorithm.TabIndex = 11;
            this.BtnLoadAlgorithm.Text = "Load Algorithm";
            this.BtnLoadAlgorithm.UseVisualStyleBackColor = true;
            this.BtnLoadAlgorithm.Click += new System.EventHandler(this.BtnLoadAlgorithm_Click);
            // 
            // ICANSEEHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 162);
            this.Controls.Add(this.BtnLoadAlgorithm);
            this.Controls.Add(this.BtnRunGPUAlgo);
            this.Controls.Add(this.BtnListAllGPUAlgos);
            this.Controls.Add(this.BtnListAllCameraConfigs);
            this.Controls.Add(this.BtnLoadCameraConfig);
            this.Controls.Add(this.BtnAddCameraConfig);
            this.Controls.Add(this.BtnDummyCall);
            this.Controls.Add(this.BtnDfs);
            this.Controls.Add(this.TxtFbpPath);
            this.Controls.Add(this.BtnExecute);
            this.Controls.Add(this.BtnShowParsedFBP);
            this.Controls.Add(this.BtnReadFBP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button BtnDummyCall;
        private System.Windows.Forms.Button BtnAddCameraConfig;
        private System.Windows.Forms.Button BtnLoadCameraConfig;
        private System.Windows.Forms.Button BtnListAllCameraConfigs;
        private System.Windows.Forms.Button BtnListAllGPUAlgos;
        private System.Windows.Forms.Button BtnRunGPUAlgo;
        private System.Windows.Forms.Button BtnLoadAlgorithm;
    }
}

