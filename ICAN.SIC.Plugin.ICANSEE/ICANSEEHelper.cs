using ICAN.SIC.Plugin.ICANSEE.Client;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEHelper
    {
        ICANSEEUtility utility;
        ImageClient imageClient;

        List<ComputeDeviceInfo> computeDeviceList;
        Dictionary<ComputeDeviceInfo, bool> computeDeviceLocked = new Dictionary<ComputeDeviceInfo,bool>();

        public ICANSEEHelper(ICANSEEUtility utility, ImageClient imageClient)
        {
            this.utility = utility;
            this.imageClient = imageClient;

            computeDeviceList = utility.GetComputeDevicesList();

            if (computeDeviceList.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No compute devices available (Check ComputeDeviceConfig file for extensive list)");
                Console.ResetColor();
            }
        }

        public bool AddCameraConfig(int newCustomId, CameraConfiguration cameraConfig)
        {
            return this.utility.AddCameraConfig(newCustomId, cameraConfig);
        }

        public void AddReplaceCameraConfiguration(int newCustomId, CameraConfiguration cameraConfig)
        {
            this.utility.AddReplaceCameraConfiguration(newCustomId, cameraConfig);
        }

        public List<AlgorithmDescription> GetAlgorithmsList()
        {
            return this.utility.GetAlgorithmsList();
        }

        public List<CameraConfiguration> GetAllCameraConfigurations()
        {
            return this.utility.GetAllCameraConfigurations();
        }

        public List<ComputeDeviceInfo> GetComputeDevicesList()
        {
            return this.utility.GetComputeDevicesList();
        }

        public string Dummy(string algoId)
        {
            string result = "";

            // Input - AlgoId

            // Find AlgoTypeId
            // Find all SupportedDeviceTypeIds

            // Check if camera already loaded in any device
                // If the device.DeviceTypeId in any SupportedDeviceTypeIds
                    // RETURN - Execute scalar
                // Else 
                    // Unload camera
            
            // Check which device already have the algo loaded
                // If found, ExecuteScalar for that device
                // Else, list all devices with supportedDeviceTypeId
                    // Load the algo in that device and ExecteScalar
                    // RETURN result

            var algoDecription = utility.QueryAlgoTypeId(algoId);
            string algoTypeId = algoDecription.AlgorithmTypeId;
            List<string> supportedDeviceTypeIdList = algoDecription.SupportedDeviceTypeIdList;

            // List<ComputeDeviceInfo> availableComputeDevices = QueryFreeDevices(supportedDeviceTypeIdList, algoTypeId);
            // Lock the available device
            // LoadAlgo to device
            // Set Device AlgoSet status
            // ExecuteScalar with device
            // Unlock device

            return result;
        }

        public FBPGraph GenerateFBPGraphFromDrwFile(Stream drwFileStream, ReplacementConfiguration configuration)
        {
            XPathDocument xmlPathDoc = new XPathDocument(drwFileStream);
            XPathNavigator navigator = xmlPathDoc.CreateNavigator();

            XPathNodeIterator blockIterator = navigator.SelectDescendants("block", "", false);
            XPathNodeIterator connectionIterator = navigator.SelectDescendants("connection", "", false);

            int count = connectionIterator.Count;

            List<DrwBlock> blocks = new List<DrwBlock>();
            List<DrwConnection> connections = new List<DrwConnection>();

            while (blockIterator.MoveNext())
            {
                XPathNavigator nav = blockIterator.Current.Clone();

                DrwBlock block = utility.ExtractDrwBlockFromNav(nav, configuration);

                if (block != null)
                    blocks.Add(block);
            }

            while (connectionIterator.MoveNext())
            {
                XPathNavigator nav = connectionIterator.Current.Clone();

                DrwConnection connection = utility.ExtractDrwConnectionFromNav(nav);

                if (connection != null)
                    connections.Add(connection);
            }

            FBPGraph graph = new FBPGraph(blocks, connections);

            return graph;
        }
    }
}
