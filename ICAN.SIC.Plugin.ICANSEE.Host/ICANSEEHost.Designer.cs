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
            this.BtnListOpenCameraInUse = new System.Windows.Forms.Button();
            this.BtnUnloadPreset = new System.Windows.Forms.Button();
            this.BtnUnloadCamera = new System.Windows.Forms.Button();
            this.BtnGetDeviceStateMap = new System.Windows.Forms.Button();
            this.BtnExecutePreset2 = new System.Windows.Forms.Button();
            this.BtnUnloadCamera2 = new System.Windows.Forms.Button();
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
            this.TxtFbpPath.Size = new System.Drawing.Size(1214, 31);
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
            this.BtnLoadCameraConfig.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnLoadCameraConfig.Location = new System.Drawing.Point(350, 187);
            this.BtnLoadCameraConfig.Margin = new System.Windows.Forms.Padding(6);
            this.BtnLoadCameraConfig.Name = "BtnLoadCameraConfig";
            this.BtnLoadCameraConfig.Size = new System.Drawing.Size(284, 44);
            this.BtnLoadCameraConfig.TabIndex = 7;
            this.BtnLoadCameraConfig.Text = "LoadCameraConfig";
            this.BtnLoadCameraConfig.UseVisualStyleBackColor = false;
            this.BtnLoadCameraConfig.Click += new System.EventHandler(this.BtnLoadCameraConfig_Click);
            // 
            // BtnListAllCameraConfigs
            // 
            this.BtnListAllCameraConfigs.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnListAllCameraConfigs.Location = new System.Drawing.Point(646, 135);
            this.BtnListAllCameraConfigs.Margin = new System.Windows.Forms.Padding(6);
            this.BtnListAllCameraConfigs.Name = "BtnListAllCameraConfigs";
            this.BtnListAllCameraConfigs.Size = new System.Drawing.Size(284, 44);
            this.BtnListAllCameraConfigs.TabIndex = 8;
            this.BtnListAllCameraConfigs.Text = "ListAllCameraConfigs";
            this.BtnListAllCameraConfigs.UseVisualStyleBackColor = false;
            this.BtnListAllCameraConfigs.Click += new System.EventHandler(this.BtnListAllCameraConfigs_Click);
            // 
            // BtnListAllGPUAlgos
            // 
            this.BtnListAllGPUAlgos.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnListAllGPUAlgos.Location = new System.Drawing.Point(646, 187);
            this.BtnListAllGPUAlgos.Margin = new System.Windows.Forms.Padding(6);
            this.BtnListAllGPUAlgos.Name = "BtnListAllGPUAlgos";
            this.BtnListAllGPUAlgos.Size = new System.Drawing.Size(284, 44);
            this.BtnListAllGPUAlgos.TabIndex = 9;
            this.BtnListAllGPUAlgos.Text = "ListAllGPUAlgos";
            this.BtnListAllGPUAlgos.UseVisualStyleBackColor = false;
            this.BtnListAllGPUAlgos.Click += new System.EventHandler(this.BtnListAllGPUAlgos_Click);
            // 
            // BtnRunGPUAlgo
            // 
            this.BtnRunGPUAlgo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnRunGPUAlgo.Location = new System.Drawing.Point(942, 135);
            this.BtnRunGPUAlgo.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRunGPUAlgo.Name = "BtnRunGPUAlgo";
            this.BtnRunGPUAlgo.Size = new System.Drawing.Size(284, 44);
            this.BtnRunGPUAlgo.TabIndex = 10;
            this.BtnRunGPUAlgo.Text = "RunGPUAlgo";
            this.BtnRunGPUAlgo.UseVisualStyleBackColor = false;
            this.BtnRunGPUAlgo.Click += new System.EventHandler(this.BtnRunGPUAlgo_Click);
            // 
            // BtnLoadAlgorithm
            // 
            this.BtnLoadAlgorithm.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnLoadAlgorithm.Location = new System.Drawing.Point(942, 187);
            this.BtnLoadAlgorithm.Margin = new System.Windows.Forms.Padding(6);
            this.BtnLoadAlgorithm.Name = "BtnLoadAlgorithm";
            this.BtnLoadAlgorithm.Size = new System.Drawing.Size(284, 44);
            this.BtnLoadAlgorithm.TabIndex = 11;
            this.BtnLoadAlgorithm.Text = "Load Algorithm";
            this.BtnLoadAlgorithm.UseVisualStyleBackColor = false;
            this.BtnLoadAlgorithm.Click += new System.EventHandler(this.BtnLoadAlgorithm_Click);
            // 
            // BtnListAllComputeDevices
            // 
            this.BtnListAllComputeDevices.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnListAllComputeDevices.Location = new System.Drawing.Point(350, 242);
            this.BtnListAllComputeDevices.Margin = new System.Windows.Forms.Padding(6);
            this.BtnListAllComputeDevices.Name = "BtnListAllComputeDevices";
            this.BtnListAllComputeDevices.Size = new System.Drawing.Size(284, 44);
            this.BtnListAllComputeDevices.TabIndex = 12;
            this.BtnListAllComputeDevices.Text = "ListAllComputeDevices";
            this.BtnListAllComputeDevices.UseVisualStyleBackColor = false;
            this.BtnListAllComputeDevices.Click += new System.EventHandler(this.BtnListAllComputeDevices_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 298);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(284, 44);
            this.button1.TabIndex = 13;
            this.button1.Text = "ExecutePreset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnUnloadAllCameras
            // 
            this.BtnUnloadAllCameras.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnUnloadAllCameras.Location = new System.Drawing.Point(646, 242);
            this.BtnUnloadAllCameras.Margin = new System.Windows.Forms.Padding(6);
            this.BtnUnloadAllCameras.Name = "BtnUnloadAllCameras";
            this.BtnUnloadAllCameras.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadAllCameras.TabIndex = 15;
            this.BtnUnloadAllCameras.Text = "Unload All Cameras";
            this.BtnUnloadAllCameras.UseVisualStyleBackColor = false;
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
            this.BtnUnloadAlgorithm.Click += new System.EventHandler(this.BtnUnloadAlgorithm_Click);
            // 
            // BtnUnloadAllAlgorithms
            // 
            this.BtnUnloadAllAlgorithms.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnUnloadAllAlgorithms.Location = new System.Drawing.Point(940, 242);
            this.BtnUnloadAllAlgorithms.Margin = new System.Windows.Forms.Padding(6);
            this.BtnUnloadAllAlgorithms.Name = "BtnUnloadAllAlgorithms";
            this.BtnUnloadAllAlgorithms.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadAllAlgorithms.TabIndex = 17;
            this.BtnUnloadAllAlgorithms.Text = "Unload All Algorithms";
            this.BtnUnloadAllAlgorithms.UseVisualStyleBackColor = false;
            this.BtnUnloadAllAlgorithms.Click += new System.EventHandler(this.BtnUnloadAllAlgorithms_Click);
            // 
            // BtnInitTFSSD
            // 
            this.BtnInitTFSSD.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnInitTFSSD.Location = new System.Drawing.Point(350, 431);
            this.BtnInitTFSSD.Name = "BtnInitTFSSD";
            this.BtnInitTFSSD.Size = new System.Drawing.Size(284, 44);
            this.BtnInitTFSSD.TabIndex = 18;
            this.BtnInitTFSSD.Text = "Init TFSSD";
            this.BtnInitTFSSD.UseVisualStyleBackColor = false;
            this.BtnInitTFSSD.Click += new System.EventHandler(this.BtnInitTFSSD_Click);
            // 
            // BtnRunTFSSD
            // 
            this.BtnRunTFSSD.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnRunTFSSD.Location = new System.Drawing.Point(646, 431);
            this.BtnRunTFSSD.Name = "BtnRunTFSSD";
            this.BtnRunTFSSD.Size = new System.Drawing.Size(284, 44);
            this.BtnRunTFSSD.TabIndex = 19;
            this.BtnRunTFSSD.Text = "Run TFSSD";
            this.BtnRunTFSSD.UseVisualStyleBackColor = false;
            this.BtnRunTFSSD.Click += new System.EventHandler(this.BtnRunTFSSD_Click);
            // 
            // BtnUnloadTFSSD
            // 
            this.BtnUnloadTFSSD.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnUnloadTFSSD.Location = new System.Drawing.Point(350, 481);
            this.BtnUnloadTFSSD.Name = "BtnUnloadTFSSD";
            this.BtnUnloadTFSSD.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadTFSSD.TabIndex = 20;
            this.BtnUnloadTFSSD.Text = "Unload TFSSD";
            this.BtnUnloadTFSSD.UseVisualStyleBackColor = false;
            this.BtnUnloadTFSSD.Click += new System.EventHandler(this.BtnUnloadTFSSD_Click);
            // 
            // BtnInitSampleImage
            // 
            this.BtnInitSampleImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnInitSampleImage.Location = new System.Drawing.Point(646, 481);
            this.BtnInitSampleImage.Name = "BtnInitSampleImage";
            this.BtnInitSampleImage.Size = new System.Drawing.Size(284, 44);
            this.BtnInitSampleImage.TabIndex = 21;
            this.BtnInitSampleImage.Text = "Init Sample Image";
            this.BtnInitSampleImage.UseVisualStyleBackColor = false;
            this.BtnInitSampleImage.Click += new System.EventHandler(this.BtnInitSampleImage_Click);
            // 
            // BtnReadAShotUri
            // 
            this.BtnReadAShotUri.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnReadAShotUri.Location = new System.Drawing.Point(942, 481);
            this.BtnReadAShotUri.Name = "BtnReadAShotUri";
            this.BtnReadAShotUri.Size = new System.Drawing.Size(284, 44);
            this.BtnReadAShotUri.TabIndex = 22;
            this.BtnReadAShotUri.Text = "Read a shot uri";
            this.BtnReadAShotUri.UseVisualStyleBackColor = false;
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
            this.BtnRequestImageMessage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BtnRequestImageMessage.Location = new System.Drawing.Point(646, 547);
            this.BtnRequestImageMessage.Name = "BtnRequestImageMessage";
            this.BtnRequestImageMessage.Size = new System.Drawing.Size(284, 43);
            this.BtnRequestImageMessage.TabIndex = 24;
            this.BtnRequestImageMessage.Text = "Request Image Message";
            this.BtnRequestImageMessage.UseVisualStyleBackColor = false;
            this.BtnRequestImageMessage.Click += new System.EventHandler(this.BtnRequestImageMessage_Click);
            // 
            // BtnListOpenCameraInUse
            // 
            this.BtnListOpenCameraInUse.Location = new System.Drawing.Point(943, 431);
            this.BtnListOpenCameraInUse.Name = "BtnListOpenCameraInUse";
            this.BtnListOpenCameraInUse.Size = new System.Drawing.Size(284, 44);
            this.BtnListOpenCameraInUse.TabIndex = 25;
            this.BtnListOpenCameraInUse.Text = "List Open Camera In Use";
            this.BtnListOpenCameraInUse.UseVisualStyleBackColor = true;
            this.BtnListOpenCameraInUse.Click += new System.EventHandler(this.BtnListOpenCameraInUse_Click);
            // 
            // BtnUnloadPreset
            // 
            this.BtnUnloadPreset.Location = new System.Drawing.Point(646, 351);
            this.BtnUnloadPreset.Name = "BtnUnloadPreset";
            this.BtnUnloadPreset.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadPreset.TabIndex = 26;
            this.BtnUnloadPreset.Text = "Unload Preset 2";
            this.BtnUnloadPreset.UseVisualStyleBackColor = true;
            this.BtnUnloadPreset.Click += new System.EventHandler(this.BtnUnloadPreset_Click);
            // 
            // BtnUnloadCamera
            // 
            this.BtnUnloadCamera.Location = new System.Drawing.Point(942, 351);
            this.BtnUnloadCamera.Name = "BtnUnloadCamera";
            this.BtnUnloadCamera.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadCamera.TabIndex = 27;
            this.BtnUnloadCamera.Text = "Unload Camera";
            this.BtnUnloadCamera.UseVisualStyleBackColor = true;
            this.BtnUnloadCamera.Click += new System.EventHandler(this.BtnUnloadCamera_Click);
            // 
            // BtnGetDeviceStateMap
            // 
            this.BtnGetDeviceStateMap.Location = new System.Drawing.Point(943, 547);
            this.BtnGetDeviceStateMap.Name = "BtnGetDeviceStateMap";
            this.BtnGetDeviceStateMap.Size = new System.Drawing.Size(284, 43);
            this.BtnGetDeviceStateMap.TabIndex = 28;
            this.BtnGetDeviceStateMap.Text = "Get Device State Map";
            this.BtnGetDeviceStateMap.UseVisualStyleBackColor = true;
            this.BtnGetDeviceStateMap.Click += new System.EventHandler(this.BtnGetDeviceStateMap_Click);
            // 
            // BtnExecutePreset2
            // 
            this.BtnExecutePreset2.Location = new System.Drawing.Point(646, 298);
            this.BtnExecutePreset2.Name = "BtnExecutePreset2";
            this.BtnExecutePreset2.Size = new System.Drawing.Size(284, 44);
            this.BtnExecutePreset2.TabIndex = 29;
            this.BtnExecutePreset2.Text = "ExecutePreset 2";
            this.BtnExecutePreset2.UseVisualStyleBackColor = true;
            this.BtnExecutePreset2.Click += new System.EventHandler(this.BtnExecutePreset2_Click);
            // 
            // BtnUnloadCamera2
            // 
            this.BtnUnloadCamera2.Location = new System.Drawing.Point(350, 351);
            this.BtnUnloadCamera2.Name = "BtnUnloadCamera2";
            this.BtnUnloadCamera2.Size = new System.Drawing.Size(284, 44);
            this.BtnUnloadCamera2.TabIndex = 30;
            this.BtnUnloadCamera2.Text = "Unload Camera 2";
            this.BtnUnloadCamera2.UseVisualStyleBackColor = true;
            this.BtnUnloadCamera2.Click += new System.EventHandler(this.BtnUnloadCamera2_Click);
            // 
            // ICANSEEHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 608);
            this.Controls.Add(this.BtnUnloadCamera2);
            this.Controls.Add(this.BtnExecutePreset2);
            this.Controls.Add(this.BtnGetDeviceStateMap);
            this.Controls.Add(this.BtnUnloadCamera);
            this.Controls.Add(this.BtnUnloadPreset);
            this.Controls.Add(this.BtnListOpenCameraInUse);
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
        private System.Windows.Forms.Button BtnListOpenCameraInUse;
        private System.Windows.Forms.Button BtnUnloadPreset;
        private System.Windows.Forms.Button BtnUnloadCamera;
        private System.Windows.Forms.Button BtnGetDeviceStateMap;
        private System.Windows.Forms.Button BtnExecutePreset2;
        private System.Windows.Forms.Button BtnUnloadCamera2;
    }
}
