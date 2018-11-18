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
            this.BtnUnloadAllCameras = new System.Windows.Forms.Button();
            this.BtnUnloadAlgorithm = new System.Windows.Forms.Button();
            this.BtnUnloadAllAlgorithms = new System.Windows.Forms.Button();
            this.BtnInitTFSSD = new System.Windows.Forms.Button();
            this.BtnRunTFSSD = new System.Windows.Forms.Button();
            this.BtnUnloadTFSSD = new System.Windows.Forms.Button();
            this.BtnInitSampleImage = new System.Windows.Forms.Button();
            this.BtnReadAShotUri = new System.Windows.Forms.Button();
            this.BtnDisplayImage = new System.Windows.Forms.Button();
            this.BtnRequestImageMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnReadFBP
            // 
            this.BtnReadFBP.Location = new System.Drawing.Point(12, 58);
            this.BtnReadFBP.Margin = new System.Windows.Forms.Padding(4);
            this.BtnReadFBP.Name = "BtnReadFBP";
            this.BtnReadFBP.Size = new System.Drawing.Size(284, 42);
            this.BtnReadFBP.TabIndex = 0;
            this.BtnReadFBP.Text = "Read FBP";
            this.BtnReadFBP.UseVisualStyleBackColor = true;
            this.BtnReadFBP.Click += new System.EventHandler(this.BtnReadFBP_Click);
            // 
            // BtnShowParsedFBP
            // 
            this.BtnShowParsedFBP.Location = new System.Drawing.Point(12, 108);
            this.BtnShowParsedFBP.Margin = new System.Windows.Forms.Padding(4);
            this.BtnShowParsedFBP.Name = "BtnShowParsedFBP";
            this.BtnShowParsedFBP.Size = new System.Drawing.Size(284, 40);
            this.BtnShowParsedFBP.TabIndex = 1;
            this.BtnShowParsedFBP.Text = "Show parsed FBP";
            this.BtnShowParsedFBP.UseVisualStyleBackColor = true;
            // 
            // BtnExecute
            // 
            this.BtnExecute.Location = new System.Drawing.Point(12, 156);
            this.BtnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(284, 40);
            this.BtnExecute.TabIndex = 2;
            this.BtnExecute.Text = "Execute";
            this.BtnExecute.UseVisualStyleBackColor = true;
            // 
            // TxtFbpPath
            // 
            this.TxtFbpPath.Location = new System.Drawing.Point(12, 12);
            this.TxtFbpPath.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFbpPath.Name = "TxtFbpPath";
            this.TxtFbpPath.Size = new System.Drawing.Size(1284, 31);
            this.TxtFbpPath.TabIndex = 3;
            // 
            // BtnDfs
            // 
            this.BtnDfs.Location = new System.Drawing.Point(304, 58);
            this.BtnDfs.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDfs.Name = "BtnDfs";
            this.BtnDfs.Size = new System.Drawing.Size(284, 42);
            this.BtnDfs.TabIndex = 4;
            this.BtnDfs.Text = "Get DFS";
            this.BtnDfs.UseVisualStyleBackColor = true;
            this.BtnDfs.Click += new System.EventHandler(this.BtnDfs_Click);
            // 
            // BtnDummyCall
            // 
            this.BtnDummyCall.Location = new System.Drawing.Point(596, 58);
            this.BtnDummyCall.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDummyCall.Name = "BtnDummyCall";
            this.BtnDummyCall.Size = new System.Drawing.Size(284, 42);
            this.BtnDummyCall.TabIndex = 5;
            this.BtnDummyCall.Text = "Make a Call";
            this.BtnDummyCall.UseVisualStyleBackColor = true;
            this.BtnDummyCall.Click += new System.EventHandler(this.BtnDummyCall_Click);
            // 
            // BtnAddCameraConfig
            // 
            this.BtnAddCameraConfig.Location = new System.Drawing.Point(350, 135);
            this.BtnAddCameraConfig.Margin = new System.Windows.Forms.Padding(6);
            this.BtnAddCameraConfig.Name = "BtnAddCameraConfig";
            this.BtnAddCameraConfig.Size = new System.Drawing.Size(284, 44);
            this.BtnAddCameraConfig.TabIndex = 6;
            this.BtnAddCameraConfig.Text = "AddCameraConfig";
            this.BtnAddCameraConfig.UseVisualStyleBackColor = true;
            this.BtnAddCameraConfig.Click += new System.EventHandler(this.BtnAddCameraConfig_Click);
            // 
            // BtnLoadCameraConfig
            // 
            this.BtnLoadCameraConfig.Location = new System.Drawing.Point(350, 187);
            this.BtnLoadCameraConfig.Margin = new System.Windows.Forms.Padding(6);
            this.BtnLoadCameraConfig.Name = "BtnLoadCameraConfig";
            this.BtnLoadCameraConfig.Size = new System.Drawing.Size(284, 44);
            this.BtnLoadCameraConfig.TabIndex = 7;
            this.BtnLoadCameraConfig.Text = "LoadCameraConfig";
            this.BtnLoadCameraConfig.UseVisualStyleBackColor = true;
            this.BtnLoadCameraConfig.Click += new System.EventHandler(this.BtnLoadCameraConfig_Click);
            // 
            // BtnListAllCameraConfigs
            // 
            this.BtnListAllCameraConfigs.Location = new System.Drawing.Point(646, 135);
            this.BtnListAllCameraConfigs.Margin = new System.Windows.Forms.Padding(6);
            this.BtnListAllCameraConfigs.Name = "BtnListAllCameraConfigs";
            this.BtnListAllCameraConfigs.Size = new System.Drawing.Size(284, 44);
            this.BtnListAllCameraConfigs.TabIndex = 8;
            this.BtnListAllCameraConfigs.Text = "ListAllCameraConfigs";
            this.BtnListAllCameraConfigs.UseVisualStyleBackColor = true;
            this.BtnListAllCameraConfigs.Click += new System.EventHandler(this.BtnListAllCameraConfigs_Click);
            // 
            // BtnListAllGPUAlgos
            // 
            this.BtnListAllGPUAlgos.Location = new System.Drawing.Point(646, 187);
            this.BtnListAllGPUAlgos.Margin = new System.Windows.Forms.Padding(6);
            this.BtnListAllGPUAlgos.Name = "BtnListAllGPUAlgos";
            this.BtnListAllGPUAlgos.Size = new System.Drawing.Size(284, 44);
            this.BtnListAllGPUAlgos.TabIndex = 9;
            this.BtnListAllGPUAlgos.Text = "ListAllGPUAlgos";
            this.BtnListAllGPUAlgos.UseVisualStyleBackColor = true;
            this.BtnListAllGPUAlgos.Click += new System.EventHandler(this.BtnListAllGPUAlgos_Click);
            // 
            // BtnRunGPUAlgo
            // 
            this.BtnRunGPUAlgo.Location = new System.Drawing.Point(942, 135);
            this.BtnRunGPUAlgo.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRunGPUAlgo.Name = "BtnRunGPUAlgo";
            this.BtnRunGPUAlgo.Size = new System.Drawing.Size(284, 44);
            this.BtnRunGPUAlgo.TabIndex = 10;
            this.BtnRunGPUAlgo.Text = "RunGPUAlgo";
            this.BtnRunGPUAlgo.UseVisualStyleBackColor = true;
            this.BtnRunGPUAlgo.Click += new System.EventHandler(this.BtnRunGPUAlgo_Click);
            // 
            // BtnLoadAlgorithm
            // 
            this.BtnLoadAlgorithm.Location = new System.Drawing.Point(942, 187);
            this.BtnLoadAlgorithm.Margin = new System.Windows.Forms.Padding(6);
            this.BtnLoadAlgorithm.Name = "BtnLoadAlgorithm";
            this.BtnLoadAlgorithm.Size = new System.Drawing.Size(284, 44);
            this.BtnLoadAlgorithm.TabIndex = 11;
            this.BtnLoadAlgorithm.Text = "Load Algorithm";
            this.BtnLoadAlgorithm.UseVisualStyleBackColor = true;
            this.BtnLoadAlgorithm.Click += new System.EventHandler(this.BtnLoadAlgorithm_Click);
            // 
            // BtnListAllComputeDevices
            // 
            this.BtnListAllComputeDevices.Location = new System.Drawing.Point(350, 242);
            this.BtnListAllComputeDevices.Margin = new System.Windows.Forms.Padding(6);
            this.BtnListAllComputeDevices.Name = "BtnListAllComputeDevices";
            this.BtnListAllComputeDevices.Size = new System.Drawing.Size(284, 44);
            this.BtnListAllComputeDevices.TabIndex = 12;
            this.BtnListAllComputeDevices.Text = "ListAllComputeDevices";
            this.BtnListAllComputeDevices.UseVisualStyleBackColor = true;
            this.BtnListAllComputeDevices.Click += new System.EventHandler(this.BtnListAllComputeDevices_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 298);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(580, 44);
            this.button1.TabIndex = 13;
            this.button1.Text = "Execute Scalar, Check/Load Algo, Reserve device";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnUnloadAllCameras
            // 
            this.BtnUnloadAllCameras.Location = new System.Drawing.Point(646, 242);
            this.BtnUnloadAllCameras.Margin = new System.Windows.Forms.Padding(6);
            this.BtnUnloadAllCameras.Name = "BtnUnloadAllCameras";
            this.BtnUnloadAllCameras.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadAllCameras.TabIndex = 15;
            this.BtnUnloadAllCameras.Text = "Unload All Cameras";
            this.BtnUnloadAllCameras.UseVisualStyleBackColor = true;
            this.BtnUnloadAllCameras.Click += new System.EventHandler(this.BtnUnloadAllCameras_Click);
            // 
            // BtnUnloadAlgorithm
            // 
            this.BtnUnloadAlgorithm.Location = new System.Drawing.Point(942, 298);
            this.BtnUnloadAlgorithm.Margin = new System.Windows.Forms.Padding(6);
            this.BtnUnloadAlgorithm.Name = "BtnUnloadAlgorithm";
            this.BtnUnloadAlgorithm.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadAlgorithm.TabIndex = 16;
            this.BtnUnloadAlgorithm.Text = "Unload Algorithm";
            this.BtnUnloadAlgorithm.UseVisualStyleBackColor = true;
            // 
            // BtnUnloadAllAlgorithms
            // 
            this.BtnUnloadAllAlgorithms.Location = new System.Drawing.Point(942, 354);
            this.BtnUnloadAllAlgorithms.Margin = new System.Windows.Forms.Padding(6);
            this.BtnUnloadAllAlgorithms.Name = "BtnUnloadAllAlgorithms";
            this.BtnUnloadAllAlgorithms.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadAllAlgorithms.TabIndex = 17;
            this.BtnUnloadAllAlgorithms.Text = "Unload All Algorithms";
            this.BtnUnloadAllAlgorithms.UseVisualStyleBackColor = true;
            this.BtnUnloadAllAlgorithms.Click += new System.EventHandler(this.BtnUnloadAllAlgorithms_Click);
            // 
            // BtnInitTFSSD
            // 
            this.BtnInitTFSSD.Location = new System.Drawing.Point(350, 431);
            this.BtnInitTFSSD.Name = "BtnInitTFSSD";
            this.BtnInitTFSSD.Size = new System.Drawing.Size(284, 44);
            this.BtnInitTFSSD.TabIndex = 18;
            this.BtnInitTFSSD.Text = "Init TFSSD";
            this.BtnInitTFSSD.UseVisualStyleBackColor = true;
            this.BtnInitTFSSD.Click += new System.EventHandler(this.BtnInitTFSSD_Click);
            // 
            // BtnRunTFSSD
            // 
            this.BtnRunTFSSD.Location = new System.Drawing.Point(646, 431);
            this.BtnRunTFSSD.Name = "BtnRunTFSSD";
            this.BtnRunTFSSD.Size = new System.Drawing.Size(284, 44);
            this.BtnRunTFSSD.TabIndex = 19;
            this.BtnRunTFSSD.Text = "Run TFSSD";
            this.BtnRunTFSSD.UseVisualStyleBackColor = true;
            this.BtnRunTFSSD.Click += new System.EventHandler(this.BtnRunTFSSD_Click);
            // 
            // BtnUnloadTFSSD
            // 
            this.BtnUnloadTFSSD.Location = new System.Drawing.Point(350, 481);
            this.BtnUnloadTFSSD.Name = "BtnUnloadTFSSD";
            this.BtnUnloadTFSSD.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadTFSSD.TabIndex = 20;
            this.BtnUnloadTFSSD.Text = "Unload TFSSD";
            this.BtnUnloadTFSSD.UseVisualStyleBackColor = true;
            this.BtnUnloadTFSSD.Click += new System.EventHandler(this.BtnUnloadTFSSD_Click);
            // 
            // BtnInitSampleImage
            // 
            this.BtnInitSampleImage.Location = new System.Drawing.Point(646, 481);
            this.BtnInitSampleImage.Name = "BtnInitSampleImage";
            this.BtnInitSampleImage.Size = new System.Drawing.Size(284, 44);
            this.BtnInitSampleImage.TabIndex = 21;
            this.BtnInitSampleImage.Text = "Init Sample Image";
            this.BtnInitSampleImage.UseVisualStyleBackColor = true;
            this.BtnInitSampleImage.Click += new System.EventHandler(this.BtnInitSampleImage_Click);
            // 
            // BtnReadAShotUri
            // 
            this.BtnReadAShotUri.Location = new System.Drawing.Point(942, 481);
            this.BtnReadAShotUri.Name = "BtnReadAShotUri";
            this.BtnReadAShotUri.Size = new System.Drawing.Size(284, 44);
            this.BtnReadAShotUri.TabIndex = 22;
            this.BtnReadAShotUri.Text = "Read a shot uri";
            this.BtnReadAShotUri.UseVisualStyleBackColor = true;
            this.BtnReadAShotUri.Click += new System.EventHandler(this.BtnReadAShotUri_Click);
            // 
            // BtnDisplayImage
            // 
            this.BtnDisplayImage.Location = new System.Drawing.Point(350, 547);
            this.BtnDisplayImage.Name = "BtnDisplayImage";
            this.BtnDisplayImage.Size = new System.Drawing.Size(284, 43);
            this.BtnDisplayImage.TabIndex = 23;
            this.BtnDisplayImage.Text = "Display Image";
            this.BtnDisplayImage.UseVisualStyleBackColor = true;
            this.BtnDisplayImage.Click += new System.EventHandler(this.BtnDisplayImage_Click);
            // 
            // BtnRequestImageMessage
            // 
            this.BtnRequestImageMessage.Location = new System.Drawing.Point(646, 547);
            this.BtnRequestImageMessage.Name = "BtnRequestImageMessage";
            this.BtnRequestImageMessage.Size = new System.Drawing.Size(284, 43);
            this.BtnRequestImageMessage.TabIndex = 24;
            this.BtnRequestImageMessage.Text = "Request Image Message";
            this.BtnRequestImageMessage.UseVisualStyleBackColor = true;
            this.BtnRequestImageMessage.Click += new System.EventHandler(this.BtnRequestImageMessage_Click);
            // 
            // ICANSEEHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 602);
            this.Controls.Add(this.BtnRequestImageMessage);
            this.Controls.Add(this.BtnDisplayImage);
            this.Controls.Add(this.BtnReadAShotUri);
            this.Controls.Add(this.BtnInitSampleImage);
            this.Controls.Add(this.BtnUnloadTFSSD);
            this.Controls.Add(this.BtnRunTFSSD);
            this.Controls.Add(this.BtnInitTFSSD);
            this.Controls.Add(this.BtnUnloadAllAlgorithms);
            this.Controls.Add(this.BtnUnloadAlgorithm);
            this.Controls.Add(this.BtnUnloadAllCameras);
            this.Controls.Add(this.BtnReadFBP);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button BtnUnloadAllCameras;
        private System.Windows.Forms.Button BtnUnloadAlgorithm;
        private System.Windows.Forms.Button BtnUnloadAllAlgorithms;
        private System.Windows.Forms.Button BtnInitTFSSD;
        private System.Windows.Forms.Button BtnRunTFSSD;
        private System.Windows.Forms.Button BtnUnloadTFSSD;
        private System.Windows.Forms.Button BtnInitSampleImage;
        private System.Windows.Forms.Button BtnReadAShotUri;
        private System.Windows.Forms.Button BtnDisplayImage;
        private System.Windows.Forms.Button BtnRequestImageMessage;
    }
}
