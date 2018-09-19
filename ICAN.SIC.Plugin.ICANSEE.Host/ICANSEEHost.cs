using ICAN.SIC.Plugin.ICANSEE.Client;
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

        public ICANSEEHost()
        {
            InitializeComponent();

            utility = new ICANSEEUtility(imageClient);
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
            utility.AddReplaceCameraConfiguration(1, new CameraConfiguration(0, null, "Default Webcam"));

            foreach (var item in utility.cameraConfigurationsMap)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine();
        }

        private void BtnListAllCameraConfigs_Click(object sender, EventArgs e)
        {
            var list = utility.GetAllCameraConfigurations();

            foreach (var item in list)
            {
                Console.WriteLine(item.Label);
            }
        }

        private void BtnListAllGPUAlgos_Click(object sender, EventArgs e)
        {
            var list = utility.GetAlgorithmsList();

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        private void BtnLoadCameraConfig_Click(object sender, EventArgs e)
        {
            string result = utility.LoadCamera(1);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnRunGPUAlgo_Click(object sender, EventArgs e)
        {
            string result = utility.ExecuteAlgorithmScalar("1");

            Console.WriteLine("[INFO] RunAlgo: " + result);

            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Failure");
        }

        private void BtnLoadAlgorithm_Click(object sender, EventArgs e)
        {
            bool result = utility.LoadAlgorithm("1");

            if (result)
                Console.WriteLine("Success");
            else
                Console.WriteLine("LoadAlgorithm problem");
        }
    }
}
