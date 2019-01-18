using ICAN.SIC.Abstractions.IMessageVariants.ICANSEE;
using ICAN.SIC.Plugin.ICANSEE.Client;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICAN.SIC.Plugin.ICANSEE.Host
{
    public partial class ICANSEEHost : Form
    {
        ICANSEE controller = new ICANSEE();
        ImageClient imageClient = new ImageClient();

        public ICANSEEHost()
        {
            InitializeComponent();
            controller.Hub.Subscribe<IInformationMessage>(PrintIInformationMessage);
        }

        private void PrintIInformationMessage(IInformationMessage message)
        {
            Console.WriteLine("JSON: " + message.Json);
            Console.WriteLine("Text: " + message.Text);
        }

        private void ICANSEEHost_Load(object sender, EventArgs e)
        {
            TxtFbpPath.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleFBP", "Population5.drw");
        }

        private void BtnReadFBP_Click(object sender, EventArgs e)
        {
            controller.ReadFBPConfiguration(TxtFbpPath.Text);
        }

        private void BtnDfs_Click(object sender, EventArgs e)
        {
            var result = controller.GenerateFBPGraph(TxtFbpPath.Text);

            foreach (var node in result.GetDFSEnumerator())
            {
                Console.WriteLine("{0} {1}", node.id, node.description.Replace("\n", " "));
            }
        }

        private void BtnDummyCall_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddCameraConfig_Click(object sender, EventArgs e)
        {
            InputMessage message = new InputMessage(ControlFunction.AddCamera, new List<string> { "0", "1", null, "Default Webcam", "camera" });
            controller.Hub.Publish<InputMessage>(message);

            foreach (var item in controller.utility.cameraConfigurationsMap)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine();
        }

        private void BtnListAllCameraConfigs_Click(object sender, EventArgs e)
        {
            var list = controller.helper.GetAllCameraConfigurations();

            foreach (var item in list)
            {
                Console.WriteLine(item.Label);
            }
        }

        private void BtnListAllGPUAlgos_Click(object sender, EventArgs e)
        {
            var list = controller.helper.GetAlgorithmsList();

            foreach (var item in list)
            {
                Console.WriteLine(string.Join("\t", item.Id, item.Name, item.Uri, "AlgoId-" + item.AlgorithmTypeId));
                foreach (var supportDeviceId in item.SupportedDeviceTypeIdList)
                {
                    Console.WriteLine("\t" + supportDeviceId);
                }
                Console.WriteLine();
            }
        }

        private void BtnLoadCameraConfig_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            int port = firstDevice.PortList.First();

            string result = controller.utility.LoadCamera(1, firstDevice, port);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnRunGPUAlgo_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.GetComputeDevicesList().First();
            int port = firstDevice.PortList.First();

            string result = controller.utility.ExecuteAlgorithmScalar("Algo1", firstDevice, port);

            Console.WriteLine("[INFO] RunAlgo: " + result);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnLoadAlgorithm_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.GetComputeDevicesList().First();
            int port = firstDevice.PortList.First();

            string algoType = controller.utility.LoadAlgorithm("Algo1", firstDevice, port);

            if (algoType != null)
                Console.WriteLine("Success with AlgoType-" + algoType);
            else
                Console.WriteLine("LoadAlgorithm problem");
        }

        private void BtnListAllComputeDevices_Click(object sender, EventArgs e)
        {
            var result = controller.helper.GetComputeDevicesList();

            if (result != null)
                foreach (var item in result)
                {
                    Console.WriteLine(string.Join("\t", item.Label, item.IpAddress, item.Description, item.DeviceTypeId));
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputMessage message = new InputMessage(ControlFunction.ExecutePreset, new List<string> { "Preset1", "1" });
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnRunAlgoOnImage_Click(object sender, EventArgs e)
        {

        }

        private void BtnUnloadAllCameras_Click(object sender, EventArgs e)
        {
            var deviceInfo = controller.helper.GetComputeDevicesList().First();
            int port = deviceInfo.PortList.First();

            if (deviceInfo != null)
                controller.utility.UnloadAllCameras(deviceInfo, port);
            else
                Console.WriteLine("No device found to unload");
        }

        private void BtnUnloadAllAlgorithms_Click(object sender, EventArgs e)
        {
            controller.helper.UnloadAllAlgorithms();
        }

        private void BtnInitTFSSD_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.GetComputeDevicesList().First();
            int port = firstDevice.PortList.First();

            string algoType = controller.utility.LoadAlgorithm("Algo3", firstDevice, port);

            if (algoType != null)
                Console.WriteLine("Success with AlgoType-" + algoType);
            else
                Console.WriteLine("LoadAlgorithm problem");
        }

        private void BtnRunTFSSD_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.GetComputeDevicesList().First();
            PresetDescription preset = new PresetDescription("1000", "Sample", "Algo3", firstDevice.ComputeDeviceId, firstDevice.PortList.First(), true, false, 1, true);
            string result = controller.utility.ExecuteAlgorithm(preset, firstDevice.IpAddress);

            if (result != null)
                Console.WriteLine("[INFO] RunAlgo: " + result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnInitSampleImage_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            int port = firstDevice.PortList.First();

            string result = controller.utility.LoadCamera(2, firstDevice, port);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnReadAShotUri_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            int port = firstDevice.PortList.First();

            string result = controller.utility.LoadCamera(4, firstDevice, port);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnDisplayImage_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            int port = firstDevice.PortList.First();

            InputMessage message = new InputMessage(ControlFunction.DisplayImageInServerGUI, new List<string> { firstDevice.ComputeDeviceId, port.ToString() });
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnUnloadTFSSD_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.GetComputeDevicesList().First();
            int port = firstDevice.PortList.First();

            string algoType = "Algo3";
            string result = controller.utility.UnloadAlgorithm(algoType, firstDevice, port);

            if (result != null)
                Console.WriteLine("Success with AlgoType-" + algoType);
            else
                Console.WriteLine("LoadAlgorithm problem");
        }

        private void BtnRequestImageMessage_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            int port = firstDevice.PortList.First();

            string result = controller.utility.RequestCurrentImage(firstDevice, port);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnUnloadAlgorithm_Click(object sender, EventArgs e)
        {
            //ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            //int port = firstDevice.PortList.First();

            // Option 1
            //InputMessage message = new InputMessage(ControlFunction.UnloadAlgorithm, new List<string> { "Algo3", firstDevice.ComputeDeviceId, port.ToString() });
            //controller.Hub.Publish<InputMessage>(message);

            // Option 2
            InputMessage message = new InputMessage(ControlFunction.UnloadAlgorithm, new List<string> { "Preset1" });
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnListOpenCameraInUse_Click(object sender, EventArgs e)
        {
            InputMessage message = new InputMessage(ControlFunction.ListAllCameraInUse, new List<string> {});
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnUnloadPreset_Click(object sender, EventArgs e)
        {
            InputMessage message = new InputMessage(ControlFunction.UnloadPreset, new List<string> { "Preset2" });
            controller.Hub.Publish<InputMessage>(message);

            //ComputeDeviceInfo firstDevice = controller.utility.computeDeviceInfoList.First();
            //int port = firstDevice.PortList.First();

            //InputMessage message = new InputMessage(ControlFunction.UnloadPreset, new List<string> { "Preset1", firstDevice.ComputeDeviceId, port.ToString() });
            //controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnUnloadCamera_Click(object sender, EventArgs e)
        {
            string presetId = "Preset1";

            string computeDeviceId = controller.utility.QueryPresetById(presetId).ComputeDeviceId;
            var computeDeviceInfo = controller.utility.QueryComputeDeviceById(computeDeviceId);

            int? cameraId = controller.helper.ComputeDeviceStateMap[computeDeviceInfo][computeDeviceInfo.PortList.First()].OpenCameraMap.First().Key?.Id;

            if (!cameraId.HasValue)
            {
                Console.WriteLine("Camera Id null");
                return;
            }

            InputMessage message = new InputMessage(ControlFunction.UnloadCamera, new List<string> { cameraId.Value.ToString(), presetId });
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnGetDeviceStateMap_Click(object sender, EventArgs e)
        {
            InputMessage message = new InputMessage(ControlFunction.QueryComputeDevice, new List<string> { });
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnExecutePreset2_Click(object sender, EventArgs e)
        {
            InputMessage message = new InputMessage(ControlFunction.ExecutePreset, new List<string> { "Preset2", "1" });
            controller.Hub.Publish<InputMessage>(message);
        }

        private void BtnUnloadCamera2_Click(object sender, EventArgs e)
        {
            string presetId = "Preset2";

            string computeDeviceId = controller.utility.QueryPresetById(presetId).ComputeDeviceId;
            var computeDeviceInfo = controller.utility.QueryComputeDeviceById(computeDeviceId);

            int? cameraId = controller.helper.ComputeDeviceStateMap[computeDeviceInfo][computeDeviceInfo.PortList.First()].OpenCameraMap.First().Key?.Id;

            if (!cameraId.HasValue)
            {
                Console.WriteLine("Camera Id null");
                return;
            }

            InputMessage message = new InputMessage(ControlFunction.UnloadCamera, new List<string> { cameraId.Value.ToString(), presetId });
            controller.Hub.Publish<InputMessage>(message);
        }
    }
}