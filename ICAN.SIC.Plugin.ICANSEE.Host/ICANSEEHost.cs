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
        ICANSEEUtility utility;
        ICANSEEHelper helper;

        public ICANSEEHost()
        {
            InitializeComponent();

            utility = new ICANSEEUtility(imageClient);
            helper = new ICANSEEHelper(utility, imageClient);
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
            //controller.MakeDummyGetCall();
            //controller.MakeDummyPostCall();

            //Console.WriteLine(controller.ExecuteScalar(new List<string> { "Start", "", "result = tfnet.return_predict(imageSrc)\noutput = str(result)" }));
            //controller.Execute(new List<string> { "Start", "", "result = tfnet.return_predict(imageSrc)\noutput = str(result)" });
        }

        private void BtnAddCameraConfig_Click(object sender, EventArgs e)
        {
            helper.AddReplaceCameraConfiguration(1, new CameraConfiguration(0, null, "Default Webcam"));

            foreach (var item in utility.cameraConfigurationsMap)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine();
        }

        private void BtnListAllCameraConfigs_Click(object sender, EventArgs e)
        {
            var list = helper.GetAllCameraConfigurations();

            foreach (var item in list)
            {
                Console.WriteLine(item.Label);
            }
        }

        private void BtnListAllGPUAlgos_Click(object sender, EventArgs e)
        {
            var list = helper.GetAlgorithmsList();

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
            ComputeDeviceInfo firstDevice = utility.computeDeviceInfoList.First();
            string result = utility.LoadCamera(1, firstDevice);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnRunGPUAlgo_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = utility.GetComputeDevicesList().First();
            string result = utility.ExecuteAlgorithmScalar("Algo1", firstDevice);

            Console.WriteLine("[INFO] RunAlgo: " + result);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnLoadAlgorithm_Click(object sender, EventArgs e)
        {
            ComputeDeviceInfo firstDevice = utility.GetComputeDevicesList().First();
            string algoType = utility.LoadAlgorithm("Algo1", firstDevice);

            if (algoType != null)
                Console.WriteLine("Success with AlgoType-" + algoType);
            else
                Console.WriteLine("LoadAlgorithm problem");
        }

        private void BtnListAllComputeDevices_Click(object sender, EventArgs e)
        {
            var result = helper.GetComputeDevicesList();

            if (result != null)
                foreach (var item in result)
                {
                    Console.WriteLine(string.Join("\t", item.Label, item.IpAddress, item.Description, item.DeviceTypeId));
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = helper.Dummy("Algo1");

            Console.WriteLine("[INFO] RunAlgo: " + result);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }
    }
}
