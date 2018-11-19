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
        Dictionary<ComputeDeviceInfo, bool> computeDeviceLocked = new Dictionary<ComputeDeviceInfo, bool>();
        Dictionary<int, ComputeDeviceInfo> assignedDeviceForCameraMap = new Dictionary<int, ComputeDeviceInfo>();
        Dictionary<string, ComputeDeviceInfo> assignedDeviceForAlgoTypeMap = new Dictionary<string, ComputeDeviceInfo>();

        string brokerHubHost, brokerHubPort;

        public ICANSEEHelper(ICANSEEUtility utility, ImageClient imageClient, string brokerHubHost, string brokerHubPort)
        {
            this.utility = utility;
            this.imageClient = imageClient;
            this.brokerHubHost = brokerHubHost;
            this.brokerHubPort = brokerHubPort;

            computeDeviceList = utility.GetComputeDevicesList();

            if (computeDeviceList.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No compute devices available (Check ComputeDeviceConfig file for extensive list)");
                Console.ResetColor();
            }
        }

        public bool AddCameraConfiguration(int newCustomId, CameraConfiguration cameraConfig)
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

        public string Dummy(int cameraId, string algoId)
        {
            //return ExecuteScalar(cameraId, algoId);
            UnloadAllAlgorithms();
            return "Done";
        }

        /*
        public string ExecuteScalar(int cameraId, string algoId)
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

            var cameraDesc = utility.QueryCameraDescription(cameraId);
            if (cameraDesc == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Helper.ExecuteAlgo : CameraId=" + cameraId + " not available");
                Console.ResetColor();
                return "";
            }

            if (assignedDeviceForCameraMap.ContainsKey(cameraId) && assignedDeviceForCameraMap[cameraId] != null)
            {
                // Camera is already loaded
                // Check if device already have the algoType loaded
                var currentDeviceInfo = assignedDeviceForCameraMap[cameraId];


                bool isCompatibleDeviceForAlgo = false;
                foreach (var deviceTypeId in algoDecription.SupportedDeviceTypeIdList)
                {
                    if (currentDeviceInfo.DeviceTypeId == deviceTypeId)
                        isCompatibleDeviceForAlgo = true;
                }

                if (isCompatibleDeviceForAlgo &&
                        assignedDeviceForAlgoTypeMap.ContainsKey(algoDecription.AlgorithmTypeId) &&
                        currentDeviceInfo == assignedDeviceForAlgoTypeMap[algoDecription.AlgorithmTypeId] &&
                        IsDeviceFree(currentDeviceInfo))
                {
                    // Execute Scalar and return
                    result = utility.ExecuteAlgorithmScalar(algoId, currentDeviceInfo);
                    return result;
                }
                else
                {
                    // Unload the camera
                    utility.UnloadAllCameras(currentDeviceInfo);
                }
            }
            else
            {
                // Get a compatible device, load the camera and execute scalar
                List<ComputeDeviceInfo> availableComputeDevices = QueryFreeDevices(supportedDeviceTypeIdList);

                if (availableComputeDevices.Count <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] SupportedComputeDevices matching for algo type not found: ");
                    foreach (var item in supportedDeviceTypeIdList)
                    {
                        Console.WriteLine("\t" + item);
                    }
                    Console.ResetColor();
                    return "";
                }


                // Device selection algo : FCFS
                ComputeDeviceInfo deviceInfo = availableComputeDevices.First();

                utility.LoadCamera(cameraId, deviceInfo);

                computeDeviceLocked[deviceInfo] = true;
                {
                    // Set new status
                    assignedDeviceForCameraMap[cameraId] = deviceInfo;
                    assignedDeviceForAlgoTypeMap[algoTypeId] = deviceInfo;

                    utility.LoadAlgorithm(algoId, deviceInfo);
                    result = utility.ExecuteAlgorithmScalar(algoId, deviceInfo, port);
                }
                computeDeviceLocked[deviceInfo] = false;


                return result;
            }

            return result;
        }
        */

        private List<ComputeDeviceInfo> QueryFreeDevices(List<string> supportedDeviceTypeIdList)
        {
            List<ComputeDeviceInfo> result = new List<ComputeDeviceInfo>();

            HashSet<string> supportedDeviceTypeIdSet = new HashSet<string>();
            foreach (var item in supportedDeviceTypeIdList)
            {
                supportedDeviceTypeIdSet.Add(item);
            }

            var availableDevices = GetComputeDevicesList();
            foreach (var deviceInfo in availableDevices)
            {
                if (supportedDeviceTypeIdSet.Contains(deviceInfo.DeviceTypeId))
                {
                    result.Add(deviceInfo);
                }
            }

            return result;
        }

        private bool IsDeviceFree(ComputeDeviceInfo currentDeviceInfo)
        {
            if (!computeDeviceLocked.ContainsKey(currentDeviceInfo))
                return true;
            return !computeDeviceLocked[currentDeviceInfo];
        }

        public void UnloadAllAlgorithms()
        {
            utility.UnloadAllAlgorithms();
        }

        public void UnloadAlgorithm(string algoId, ComputeDeviceInfo computeDeviceInfo, int port)
        {
            utility.UnloadAlgorithm(algoId, computeDeviceInfo, port);
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
