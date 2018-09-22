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
            this.BtnListAllComputeDevices = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnRunAlgoOnImage = new System.Windows.Forms.Button();
            this.BtnUnloadAllCameras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnReadFBP
            // 
            this.BtnReadFBP.Location = new System.Drawing.Point(6, 30);
            this.BtnReadFBP.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReadFBP.Name = "BtnReadFBP";
            this.BtnReadFBP.Size = new System.Drawing.Size(142, 22);
            this.BtnReadFBP.TabIndex = 0;
            this.BtnReadFBP.Text = "Read FBP";
            this.BtnReadFBP.UseVisualStyleBackColor = true;
            this.BtnReadFBP.Click += new System.EventHandler(this.BtnReadFBP_Click);
            // 
            // BtnShowParsedFBP
            // 
            this.BtnShowParsedFBP.Location = new System.Drawing.Point(6, 56);
            this.BtnShowParsedFBP.Margin = new System.Windows.Forms.Padding(2);
            this.BtnShowParsedFBP.Name = "BtnShowParsedFBP";
            this.BtnShowParsedFBP.Size = new System.Drawing.Size(142, 21);
            this.BtnShowParsedFBP.TabIndex = 1;
            this.BtnShowParsedFBP.Text = "Show parsed FBP";
            this.BtnShowParsedFBP.UseVisualStyleBackColor = true;
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(6, 81);
            this.BtnExecute.Margin = new System.Windows.Forms.Padding(2);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(142, 21);
            this.BtnExecute.TabIndex = 2;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            // 
            // TxtFbpPath
            // 
            this.TxtFbpPath.Location = new System.Drawing.Point(6, 6);
            this.TxtFbpPath.Margin = new System.Windows.Forms.Padding(2);
            this.TxtFbpPath.Name = "TxtFbpPath";
            this.TxtFbpPath.Size = new System.Drawing.Size(644, 20);
            this.TxtFbpPath.TabIndex = 3;
            // 
            // BtnDfs
            // 
            this.BtnDfs.Location = new System.Drawing.Point(152, 30);
            this.BtnDfs.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDfs.Name = "BtnDfs";
            this.BtnDfs.Size = new System.Drawing.Size(142, 22);
            this.BtnDfs.TabIndex = 4;
            this.BtnDfs.Text = "Get DFS";
            this.BtnDfs.UseVisualStyleBackColor = true;
            this.BtnDfs.Click += new System.EventHandler(this.BtnDfs_Click);
            // 
            // BtnDummyCall
            // 
            this.BtnDummyCall.Location = new System.Drawing.Point(298, 30);
            this.BtnDummyCall.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDummyCall.Name = "BtnDummyCall";
            this.BtnDummyCall.Size = new System.Drawing.Size(142, 22);
            this.BtnDummyCall.TabIndex = 5;
            this.BtnDummyCall.Text = "Make a Call";
            this.BtnDummyCall.UseVisualStyleBackColor = true;
            this.BtnDummyCall.Click += new System.EventHandler(this.BtnDummyCall_Click);
            // 
            // BtnAddCameraConfig
            // 
            this.BtnAddCameraConfig.Location = new System.Drawing.Point(175, 70);
            this.BtnAddCameraConfig.Name = "BtnAddCameraConfig";
            this.BtnAddCameraConfig.Size = new System.Drawing.Size(142, 23);
            this.BtnAddCameraConfig.TabIndex = 6;
            this.BtnAddCameraConfig.Text = "AddCameraConfig";
            this.BtnAddCameraConfig.UseVisualStyleBackColor = true;
            this.BtnAddCameraConfig.Click += new System.EventHandler(this.BtnAddCameraConfig_Click);
            // 
            // BtnLoadCameraConfig
            // 
            this.BtnLoadCameraConfig.Location = new System.Drawing.Point(175, 97);
            this.BtnLoadCameraConfig.Name = "BtnLoadCameraConfig";
            this.BtnLoadCameraConfig.Size = new System.Drawing.Size(142, 23);
            this.BtnLoadCameraConfig.TabIndex = 7;
            this.BtnLoadCameraConfig.Text = "LoadCameraConfig";
            this.BtnLoadCameraConfig.UseVisualStyleBackColor = true;
            this.BtnLoadCameraConfig.Click += new System.EventHandler(this.BtnLoadCameraConfig_Click);
            // 
            // BtnListAllCameraConfigs
            // 
            this.BtnListAllCameraConfigs.Location = new System.Drawing.Point(323, 70);
            this.BtnListAllCameraConfigs.Name = "BtnListAllCameraConfigs";
            this.BtnListAllCameraConfigs.Size = new System.Drawing.Size(142, 23);
            this.BtnListAllCameraConfigs.TabIndex = 8;
            this.BtnListAllCameraConfigs.Text = "ListAllCameraConfigs";
            this.BtnListAllCameraConfigs.UseVisualStyleBackColor = true;
            this.BtnListAllCameraConfigs.Click += new System.EventHandler(this.BtnListAllCameraConfigs_Click);
            // 
            // BtnListAllGPUAlgos
            // 
            this.BtnListAllGPUAlgos.Location = new System.Drawing.Point(323, 97);
            this.BtnListAllGPUAlgos.Name = "BtnListAllGPUAlgos";
            this.BtnListAllGPUAlgos.Size = new System.Drawing.Size(142, 23);
            this.BtnListAllGPUAlgos.TabIndex = 9;
            this.BtnListAllGPUAlgos.Text = "ListAllGPUAlgos";
            this.BtnListAllGPUAlgos.UseVisualStyleBackColor = true;
            this.BtnListAllGPUAlgos.Click += new System.EventHandler(this.BtnListAllGPUAlgos_Click);
            // 
            // BtnRunGPUAlgo
            // 
            this.BtnRunGPUAlgo.Location = new System.Drawing.Point(471, 70);
            this.BtnRunGPUAlgo.Name = "BtnRunGPUAlgo";
            this.BtnRunGPUAlgo.Size = new System.Drawing.Size(142, 23);
            this.BtnRunGPUAlgo.TabIndex = 10;
            this.BtnRunGPUAlgo.Text = "RunGPUAlgo";
            this.BtnRunGPUAlgo.UseVisualStyleBackColor = true;
            this.BtnRunGPUAlgo.Click += new System.EventHandler(this.BtnRunGPUAlgo_Click);
            // 
            // BtnLoadAlgorithm
            // 
            this.BtnLoadAlgorithm.Location = new System.Drawing.Point(471, 97);
            this.BtnLoadAlgorithm.Name = "BtnLoadAlgorithm";
            this.BtnLoadAlgorithm.Size = new System.Drawing.Size(142, 23);
            this.BtnLoadAlgorithm.TabIndex = 11;
            this.BtnLoadAlgorithm.Text = "Load Algorithm";
            this.BtnLoadAlgorithm.UseVisualStyleBackColor = true;
            this.BtnLoadAlgorithm.Click += new System.EventHandler(this.BtnLoadAlgorithm_Click);
            // 
            // BtnListAllComputeDevices
            // 
            this.BtnListAllComputeDevices.Location = new System.Drawing.Point(175, 126);
            this.BtnListAllComputeDevices.Name = "BtnListAllComputeDevices";
            this.BtnListAllComputeDevices.Size = new System.Drawing.Size(142, 23);
            this.BtnListAllComputeDevices.TabIndex = 12;
            this.BtnListAllComputeDevices.Text = "ListAllComputeDevices";
            this.BtnListAllComputeDevices.UseVisualStyleBackColor = true;
            this.BtnListAllComputeDevices.Click += new System.EventHandler(this.BtnListAllComputeDevices_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Execute Scalar, Check/Load Algo, Reserve device";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnRunAlgoOnImage
            // 
            this.BtnRunAlgoOnImage.Location = new System.Drawing.Point(175, 184);
            this.BtnRunAlgoOnImage.Name = "BtnRunAlgoOnImage";
            this.BtnRunAlgoOnImage.Size = new System.Drawing.Size(290, 23);
            this.BtnRunAlgoOnImage.TabIndex = 14;
            this.BtnRunAlgoOnImage.Text = "Run algo image on image";
            this.BtnRunAlgoOnImage.UseVisualStyleBackColor = true;
            this.BtnRunAlgoOnImage.Click += new System.EventHandler(this.BtnRunAlgoOnImage_Click);
            // 
            // BtnUnloadAllCameras
            // 
            this.BtnUnloadAllCameras.Location = new System.Drawing.Point(323, 126);
            this.BtnUnloadAllCameras.Name = "BtnUnloadAllCameras";
            this.BtnUnloadAllCameras.Size = new System.Drawing.Size(142, 23);
            this.BtnUnloadAllCameras.TabIndex = 15;
            this.BtnUnloadAllCameras.Text = "Unload All Cameras";
            this.BtnUnloadAllCameras.UseVisualStyleBackColor = true;
            this.BtnUnloadAllCameras.Click += new System.EventHandler(this.BtnUnloadAllCameras_Click);
            // 
            // ICANSEEHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 213);
            this.Controls.Add(this.BtnUnloadAllCameras);
            this.Controls.Add(this.BtnReadFBP);
            this.Controls.Add(this.BtnRunAlgoOnImage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnListAllComputeDevices);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button BtnListAllComputeDevices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnRunAlgoOnImage;
        private System.Windows.Forms.Button BtnUnloadAllCameras;
    }
}

