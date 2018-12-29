using ICAN.SIC.Plugin.ICANSEE.Client;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using Newtonsoft.Json;
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
    public class ComputeDeviceState
    {
        public Dictionary<CameraConfiguration, bool> OpenCameraMap;
        public Dictionary<PresetDescription, bool> AssignedPresetDescriptionMap;
        public Dictionary<AlgorithmDescription, bool> AssignedAlgorithmDescriptionMap;

        public ComputeDeviceState()
        {
            OpenCameraMap = new Dictionary<CameraConfiguration, bool>();
            AssignedPresetDescriptionMap = new Dictionary<PresetDescription, bool>();
            AssignedAlgorithmDescriptionMap = new Dictionary<AlgorithmDescription, bool>();
        }

        public bool IsAnyCameraActive()
        {
            foreach (var camera in OpenCameraMap)
            {
                if (camera.Value)
                    return true;
            }
            return false;
        }
        public bool IsAnyPresetActive()
        {
            foreach (var preset in AssignedPresetDescriptionMap)
            {
                if (preset.Value)
                    return true;
            }
            return false;
        }
        public bool IsAnyAlgorithmsActive()
        {
            foreach (var algo in AssignedAlgorithmDescriptionMap)
            {
                if (algo.Value)
                    return true;
            }
            return false;
        }

        public void SetCameraActive(CameraConfiguration cameraConfiguration)
        {
            OpenCameraMap[cameraConfiguration] = true;
        }
        public bool SetPresetActive(PresetDescription presetDescription, List<AlgorithmDescription> algorithmDescriptionList)
        {
            int algoIndex = algorithmDescriptionList.FindIndex(algo => algo.Id == presetDescription.AlgorithmId);

            if (algoIndex < 0 || algoIndex >= algorithmDescriptionList.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] SetPresetActive(presetId={0}) Algorithm not present in provided list");
                Console.ResetColor();
                return false;
            }

            AssignedPresetDescriptionMap[presetDescription] = true;
            AssignedAlgorithmDescriptionMap[algorithmDescriptionList[algoIndex]] = true;
            return true;
        }
        public void SetAlgorithmActive(AlgorithmDescription algorithmDescription)
        {
            AssignedAlgorithmDescriptionMap[algorithmDescription] = true;
        }

        public bool IsAlgorithmActive(string algorithmId)
        {
            foreach (var algo in AssignedAlgorithmDescriptionMap)
            {
                if (algo.Key.Id == algorithmId && algo.Value)
                    return true;
            }
            return false;
        }

        public bool IsCameraActive(int cameraId)
        {
            foreach (var camera in OpenCameraMap)
            {
                if (camera.Key.Id == cameraId && camera.Value)
                    return true;
            }
            return false;
        }

        public bool IsPresetActive(string presetId)
        {
            foreach (var preset in AssignedPresetDescriptionMap)
            {
                if (preset.Key.Id == presetId && preset.Value)
                    return true;
            }
            return false;
        }

        public bool ClearCamera(int cameraId)
        {
            CameraConfiguration cameraConfiguration = null;
            foreach (var camera in OpenCameraMap)
            {
                if (camera.Key.Id == cameraId && camera.Value)
                    cameraConfiguration = camera.Key;
            }

            if (cameraConfiguration != null)
                OpenCameraMap[cameraConfiguration] = false;
            else
                return false;

            return true;
        }

        public bool ClearAlgorithm(string algoId)
        {
            AlgorithmDescription algorithmDescription = null;
            foreach (var algo in AssignedAlgorithmDescriptionMap)
            {
                if (algo.Key.Id == algoId && algo.Value)
                    algorithmDescription = algo.Key;
            }

            if (algorithmDescription != null)
                AssignedAlgorithmDescriptionMap[algorithmDescription] = false;
            else
                return false;

            return true;
        }

        public bool ClearPreset(string presetId)
        {
            PresetDescription presetDescription = null;
            foreach (var preset in AssignedPresetDescriptionMap)
            {
                if (preset.Key.Id == presetId && preset.Value)
                    presetDescription = preset.Key;
            }

            if (presetDescription != null)
                AssignedPresetDescriptionMap[presetDescription] = false;
            else
                return false;

            return true;
        }
    }

    public class ICANSEEHelper
    {
        ICANSEEUtility utility;
        ImageClient imageClient;
        ICANSEELogger logger;

        List<ComputeDeviceInfo> computeDeviceList;
        Dictionary<ComputeDeviceInfo, Dictionary<int, ComputeDeviceState>> computeDeviceStateMap = new Dictionary<ComputeDeviceInfo, Dictionary<int, ComputeDeviceState>>();


        string brokerHubHost, brokerHubPort;

        public ICANSEEHelper(ICANSEELogger logger, ICANSEEUtility utility, ImageClient imageClient, string brokerHubHost, string brokerHubPort)
        {
            this.logger = logger;
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
            else
                foreach (var computeDevice in computeDeviceList)
                {
                    computeDeviceStateMap[computeDevice] = new Dictionary<int, ComputeDeviceState>();
                }
        }

        public bool UnloadAnyCamera(int cameraId)
        {
            foreach (var item in computeDeviceStateMap)
            {
                var computeDeviceInfo = item.Key;

                foreach (var cell in item.Value)
                {
                    if (cell.Value.IsCameraActive(cameraId))
                    {
                        string status = utility.UnloadCamera(cameraId, computeDeviceInfo, cell.Key);

                        if (status != null)
                        {
                            return cell.Value.ClearCamera(cameraId);
                        }
                    }
                }
            }

            return false;
        }

        public bool UnloadPreset(string presetId, ComputeDeviceInfo computeDeviceInfo, int port)
        {
            return computeDeviceStateMap[computeDeviceInfo][port].ClearPreset(presetId);
        }

        public bool UnloadCamera(int cameraId, string presetId)
        {
            var preset = utility.QueryPresetById(presetId);
            if (preset == null)
                return false;

            var computeDeviceInfo = utility.QueryComputeDeviceById(preset.ComputeDeviceId);
            int port = preset.Port;

            return UnloadCamera(cameraId, computeDeviceInfo, port);
        }

        public bool UnloadCamera(int cameraId, ComputeDeviceInfo computeDeviceInfo, int port)
        {
            utility.UnloadCamera(cameraId, computeDeviceInfo, port);
            return computeDeviceStateMap[computeDeviceInfo][port].ClearCamera(cameraId);
        }

        public string ExecutePreset(string presetId, CameraConfiguration cameraConfiguration)
        {
            int RunCompatibility = 0;
            bool targetCameraOpen = false;
            bool targetAlgorithmActive = false;

            PresetDescription presetConfiguration = utility.QueryPresetById(presetId, brokerHubHost, brokerHubPort);
            ComputeDeviceInfo computeDevice = utility.QueryComputeDeviceById(presetConfiguration.ComputeDeviceId);
            int port = presetConfiguration.Port;

            ComputeDeviceState currentState = QueryDeviceState(computeDevice, port);
            logger.LogComputeDeviceStateMap(computeDeviceStateMap, string.Format("QueryDeviceState({0}, {1}) = {2}", computeDevice.ComputeDeviceId, port.ToString(), logger._GetShortFormattedComputeDeviceState(currentState)));

            if (currentState == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ExecutePreset(presetId={0}, cameraId={1}) Failure in current state", presetId, cameraConfiguration.Id);
                Console.ResetColor();
                return null;
            }

            // Any logic for deciding on run
            // Update statusMap with conditions
            if (!(currentState.IsAnyAlgorithmsActive() || currentState.IsAnyCameraActive() || currentState.IsAnyPresetActive()))
                RunCompatibility = 1;
            // If same algorithm, camera is there but preset is over, then run
            else if (currentState.IsAlgorithmActive(presetConfiguration.AlgorithmId) && currentState.IsCameraActive(cameraConfiguration.Id) && !(currentState.IsPresetActive(presetId)))
                RunCompatibility = 2;
            else
            {
                RunCompatibility = 5;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[FIX NEEDED] ExecutePreset(presetId={0}, cameraId={1}) Backdoor activated for allowing execution", presetId, cameraConfiguration.Id);
                Console.ResetColor();
            }

            if (currentState.IsCameraActive(cameraConfiguration.Id))
                targetCameraOpen = true;
            if (currentState.IsAlgorithmActive(presetConfiguration.AlgorithmId))
                targetAlgorithmActive = true;


            // If run compatibility satisfies, run the algorithm in specific compute device
            if (RunCompatibility > 0)
            {
                string result = "";

                // If camera already not loaded, call LoadCamera
                if (!targetCameraOpen)
                {
                    result = utility.LoadCamera(cameraConfiguration.Id, computeDevice, port);
                    if (result == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[ERROR] ExecutePreset(presetId={0}, cameraId={1}) LoadCamera() Failed", presetId, cameraConfiguration.Id);
                        Console.ResetColor();
                        return null;
                    }
                    else
                    {
                        computeDeviceStateMap[computeDevice][port].SetCameraActive(cameraConfiguration);
                        logger.LogComputeDeviceStateMap(computeDeviceStateMap, string.Format("SetCameraActive={0}", cameraConfiguration.Id + "," + cameraConfiguration.Label));
                    }
                }


                // If preset request to run ScalarExecuteCommand attribute, call the InitCommandFirst
                if (!targetAlgorithmActive)
                {
                    result = utility.ExecuteAlgorithm(presetConfiguration, computeDevice.IpAddress, "InitCommand");
                    if (result == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[ERROR] ExecutePreset(presetId={0}, cameraId={1}) InitAlgo Failed", presetId, cameraConfiguration.Id);
                        Console.ResetColor();
                        return null;
                    }
                }

                computeDeviceStateMap[computeDevice][port].SetPresetActive(presetConfiguration, utility.GetAlgorithmsList());
                logger.LogComputeDeviceStateMap(computeDeviceStateMap, "SetPresetActive=" + presetConfiguration.Id + "," + presetConfiguration.Name);

                // If preset is one time run, then clear preset from the statusMap
                if (presetConfiguration.ReturnResult && !presetConfiguration.InfiniteLoop && (presetConfiguration.RunOnce || presetConfiguration.LoopLimit == 1))
                {
                    computeDeviceStateMap[computeDevice][port].ClearPreset(presetConfiguration.Id);
                    logger.LogComputeDeviceStateMap(computeDeviceStateMap, "One Run ClearPreset=" + presetConfiguration.Id + "," + presetConfiguration.Name);
                }

                result = utility.ExecuteAlgorithm(presetConfiguration, computeDevice.IpAddress);

                if (result == null)
                {
                    computeDeviceStateMap[computeDevice][port].ClearPreset(presetConfiguration.Id);
                    logger.LogComputeDeviceStateMap(computeDeviceStateMap, "Preset Failure ClearPreset=" + presetConfiguration.Id + "," + presetConfiguration.Name);


                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] ExecutePreset(presetId={0}, cameraId={1}) Preset Execution Failed", presetId, cameraConfiguration.Id);
                    Console.ResetColor();

                    return null;
                }

                return result;
            }

            return null;
        }

        public Dictionary<ComputeDeviceInfo, Dictionary<int, ComputeDeviceState>> ComputeDeviceStateMap { get { return computeDeviceStateMap; } }

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

        private List<ComputeDeviceInfo> QueryFreeDevices(List<string> supportedDeviceTypeIdList)
        {
            throw new NotImplementedException();
        }

        private ComputeDeviceState QueryDeviceState(ComputeDeviceInfo currentDeviceInfo, int port)
        {
            bool validPort = currentDeviceInfo.PortList.Any(p => p == port);

            if (!validPort)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] QueryDeviceState(devId={0}, port={1}) Port does not exists", currentDeviceInfo.ComputeDeviceId, port);
                Console.ResetColor();
                return null;
            }

            if (computeDeviceStateMap.ContainsKey(currentDeviceInfo))
            {
                if (computeDeviceStateMap[currentDeviceInfo].ContainsKey(port))
                    return computeDeviceStateMap[currentDeviceInfo][port];
                else
                    return computeDeviceStateMap[currentDeviceInfo][port] = new ComputeDeviceState();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] QueryDeviceState(devId={0}, port={1}) Unable to fetch data", currentDeviceInfo.ComputeDeviceId, port);
            Console.ResetColor();
            return null;
        }

        public void UnloadAllAlgorithms()
        {
            utility.UnloadAllAlgorithms();
        }

        public bool UnloadAlgorithm(string algoId, ComputeDeviceInfo computeDeviceInfo, int port)
        {
            string result = utility.UnloadAlgorithm(algoId, computeDeviceInfo, port);

            if (result != null)
            {
                return computeDeviceStateMap[computeDeviceInfo][port].ClearAlgorithm(algoId);
            }

            return false;
        }

        public bool UnloadAlgorithm(string presetId)
        {
            var presetDesc = utility.QueryPresetById(presetId);

            if (presetDesc == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] UnloadAlgorithm(presetId={0}) Preset not found", presetId);
                Console.ResetColor();
                return false;
            }

            string algoId = presetDesc.AlgorithmId;
            var computeDeviceInfo = utility.QueryComputeDeviceById(presetDesc.ComputeDeviceId);
            int port = presetDesc.Port;

            string result = utility.UnloadAlgorithm(algoId, computeDeviceInfo, port);

            if (result != null)
            {
                return computeDeviceStateMap[computeDeviceInfo][port].ClearAlgorithm(algoId);
            }

            return false;
        }

        public FBPGraph GenerateFBPGraphFromDrwFile(Stream drwFileStream, ReplacementConfiguration configuration)
        {
            return utility.GenerateFBPGraphFromDrwFile(drwFileStream, configuration);
        }

        public CameraConfiguration QueryCameraDescription(int cameraId)
        {
            return utility.QueryCameraDescription(cameraId);
        }

        public List<Tuple<string, string>> GetAllCameraInUse()
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();

            foreach (var item1 in computeDeviceStateMap)
            {
                string computeDeviceId = item1.Key.ComputeDeviceId + "/" + item1.Key.Label + "/" + item1.Key.IpAddress;

                foreach (var cell in item1.Value)
                {
                    foreach (var camera in cell.Value.OpenCameraMap)
                    {
                        result.Add(new Tuple<string, string>(JsonConvert.SerializeObject(camera), computeDeviceId));
                    }
                }
            }

            return result;
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
    }
}
