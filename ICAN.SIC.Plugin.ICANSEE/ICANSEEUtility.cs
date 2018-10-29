using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using ICAN.SIC.Plugin.ICANSEE.Client;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using Newtonsoft.Json;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEUtility
    {
        public Dictionary<int, CameraConfiguration> cameraConfigurationsMap = new Dictionary<int, CameraConfiguration>();
        public Dictionary<string, AlgorithmDescription> algorithmsDescriptionMap = new Dictionary<string, AlgorithmDescription>();
        public Dictionary<string, string> unloadCommandDeviceTypeToCommadMap = new Dictionary<string, string>();
        public List<ComputeDeviceInfo> computeDeviceInfoList = new List<ComputeDeviceInfo>();
        public Dictionary<string, List<ComputeDeviceInfo>> computeDeviceInfoListMap = new Dictionary<string, List<ComputeDeviceInfo>>();
        ImageClient imageClient;

        public ICANSEEUtility(ImageClient imageClient, string algoDescriptionFileName = "AlgorithmsDescriptionList.json", string computeDeviceListFileName = "ComputeDeviceList.json", string cameraListFileName = "CameraConfigurationList.json")
        {
            this.imageClient = imageClient;

            if (!File.Exists(algoDescriptionFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Algo descriptions file not found: " + algoDescriptionFileName);
                Console.ResetColor();
            }
            else
                try
                {
                    LoadAlgorithmDescriptionsFromFile(algoDescriptionFileName);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error while reading algoDescriptionFile : " + algoDescriptionFileName);
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }




            if (!File.Exists(computeDeviceListFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Compute Device List file not found: " + computeDeviceListFileName);
                Console.ResetColor();
            }
            else
                try
                {
                    LoadComputeDeviceListFromFile(computeDeviceListFileName);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error while reading Compute Device List : " + computeDeviceListFileName);
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }


            if (!File.Exists(cameraListFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Camera description list file not found: " + cameraListFileName);
                Console.ResetColor();
            }
            else
                try
                {
                    LoadCameraDescriptionsFromFile(cameraListFileName);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error while reading Camera description list : " + cameraListFileName);
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
        }

        private void LoadAlgorithmDescriptionsFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            List<AlgorithmDescription> algoList = JsonConvert.DeserializeObject<List<AlgorithmDescription>>(fileContent);
            this.algorithmsDescriptionMap = algoList.ToDictionary(e => e.Id);

            foreach (var algoDesc in algoList)
            {
                foreach (var deviceTypeId in algoDesc.SupportedDeviceTypeIdList)
                {
                    if (!unloadCommandDeviceTypeToCommadMap.ContainsKey(deviceTypeId))
                    {
                        unloadCommandDeviceTypeToCommadMap[deviceTypeId] = "";
                    }
                    unloadCommandDeviceTypeToCommadMap[deviceTypeId] += "\\n" + algoDesc.GetUnloadCommand("{{host}}");
                }
            }
        }

        private void LoadCameraDescriptionsFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            List<CameraConfiguration> cameraList = JsonConvert.DeserializeObject<List<CameraConfiguration>>(fileContent);
            this.cameraConfigurationsMap = cameraList.ToDictionary(e => e.Id);
        }

        private void LoadComputeDeviceListFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            computeDeviceInfoList = JsonConvert.DeserializeObject<List<ComputeDeviceInfo>>(fileContent);

            foreach (var item in computeDeviceInfoList)
            {
                if (!computeDeviceInfoListMap.ContainsKey(item.DeviceTypeId))
                {
                    computeDeviceInfoListMap[item.DeviceTypeId] = new List<ComputeDeviceInfo>();
                }
                computeDeviceInfoListMap[item.DeviceTypeId].Add(item);
            }
        }

        public List<AlgorithmDescription> GetAlgorithmsList()
        {
            List<AlgorithmDescription> result = new List<AlgorithmDescription>();
            foreach (var item in algorithmsDescriptionMap)
            {
                result.Add(item.Value);
            }
            return result;
        }

        public bool AddCameraConfig(int newCustomId, CameraConfiguration cameraConfig)
        {
            if (cameraConfigurationsMap.ContainsKey(newCustomId))
                return false;

            cameraConfigurationsMap[newCustomId] = cameraConfig;

            return true;
        }

        public void AddReplaceCameraConfiguration(int newCustomId, CameraConfiguration cameraConfig)
        {
            cameraConfigurationsMap[newCustomId] = cameraConfig;
        }

        public string LoadTargetDeviceLocalImage(string deviceLocalImagePath, ComputeDeviceInfo computeDeviceInfo)
        {
            try
            {
                string apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['imageSrc'] = cv2.imread('{{deviceLocalImagePath}}')\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";

                apiCallBody = apiCallBody.Replace("{{deviceLocalImagePath}}", "\"" + deviceLocalImagePath + "\"");

                string result = imageClient.MakePostCall("http://{{host}}:5000/task".Replace("{{host}}", computeDeviceInfo.IpAddress), apiCallBody);

                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadCamera(val=" + deviceLocalImagePath + ")" + ex.Message);
                Console.ResetColor();
            }
            return null;
        }

        public string LoadCamera(int cameraConfigId, ComputeDeviceInfo computeDeviceInfo)
        {
            try
            {
                if (cameraConfigurationsMap.ContainsKey(cameraConfigId))
                {
                    CameraConfiguration cameraConfig = cameraConfigurationsMap[cameraConfigId];

                    string apiCallBody = "BlankValue";

                    // identify the type
                    switch (cameraConfig.Type)
                    {
                        case "camera":
                            apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['cap'] = cv2.VideoCapture({{index}})\\nret, frame = globals()['cap'].read()\\nglobals()['imageSrc'] = frame\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
                            apiCallBody = apiCallBody.Replace("{{index}}", cameraConfig.Index.ToString());
                            break;

                        case "mjpgStream":
                            apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['cap'] = cv2.VideoCapture({{url}})\\nret, frame = globals()['cap'].read()\\nglobals()['imageSrc'] = frame\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
                            apiCallBody = apiCallBody.Replace("{{url}}", "'" + cameraConfig.Url + "'");
                            break;

                        case "image":
                            apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['imageSrc'] = cv2.imread({{imageLocalPath}})\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
                            apiCallBody = apiCallBody.Replace("{{imageLocalPath}}", "'" + cameraConfig.Url + "'");
                            break;

                        case "imageShot":
                            apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['imageSrc'] = getImageFromShotUri({{shotUri}})\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
                            apiCallBody = apiCallBody.Replace("{{shotUri}}", "'" + cameraConfig.Url + "'");
                            break;
                    }

                    Console.WriteLine("[DEBUG] apiCallBody: " + apiCallBody);
                    string result = imageClient.MakePostCall("http://{{host}}:5000/task".Replace("{{host}}", computeDeviceInfo.IpAddress), apiCallBody);

                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadCamera(val=" + cameraConfigId + ")" + ex.Message);
                Console.ResetColor();
            }
            return null;
        }

        public string DisplayImageWindow(ComputeDeviceInfo computeDeviceInfo)
        {
            try
            {
                string apiCallBody = "{\n\"Fbp\":[\"Start\",\"ImShow('DEBUG', globals()['imageSrc'], 6000)\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";

                string result = imageClient.MakePostCall("http://{{host}}:5000/task".Replace("{{host}}", computeDeviceInfo.IpAddress), apiCallBody);

                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.DisplayImageWindow(" + computeDeviceInfo.IpAddress + ") " + ex.Message);
                Console.ResetColor();
            }
            return null;
        }

        public string UnloadAllCameras(ComputeDeviceInfo computeDeviceInfo)
        {
            try
            {
                string apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['cap'] = None\\nglobals()['imageSrc'] = None\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";

                string result = imageClient.MakePostCall("http://{{host}}:5000/task".Replace("{{host}}", computeDeviceInfo.IpAddress), apiCallBody);

                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.UnloadCameras(" + computeDeviceInfo.IpAddress + ") " + ex.Message);
                Console.ResetColor();
            }
            return null;
        }

        public string LoadAlgorithm(string algoId, ComputeDeviceInfo computeDeviceInfo)
        {
            if (!algorithmsDescriptionMap.ContainsKey(algoId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadAlgorithm(" + algoId + ")\n - Algorithm Id not found");
                Console.ResetColor();

                return null;
            }

            string apiCallBody = "{\n\"Fbp\":[\"Start\",\"" + algorithmsDescriptionMap[algoId].GetInitCommand(computeDeviceInfo.IpAddress) + "\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
            try
            {
                string result = imageClient.MakePostCall(algorithmsDescriptionMap[algoId].GetUri(computeDeviceInfo.IpAddress), apiCallBody);
                Console.WriteLine("[INFO] ICANSEEUtility.LoadAlgorithm(" + algoId + ")\n" + apiCallBody + "\n\n" + "Result: " + result);
                return algorithmsDescriptionMap[algoId].AlgorithmTypeId;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadAlgorithm(" + algoId + ")\n" + apiCallBody + "\n" + ex.Message);
                Console.ResetColor();

                return null;
            }
        }

        public string ExecuteAlgorithm(string ipAddress, bool RunOnce, bool InfiniteLoop, int LoopLimit, bool ReturnResult, string resultProcessingStatement, string algorithmId)
        {
            if (!algorithmsDescriptionMap.ContainsKey(algorithmId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadAlgorithm(" + algorithmId + ")\n - Algorithm Id not found");
                Console.ResetColor();

                return null;
            }

            string apiCallBody = "{\n\"Fbp\":[\"Start\",\"\",\"" + resultProcessingStatement + "\"],\"RunOnce\": {{RunOnce}},\"InfiniteLoop\": {{InfiniteLoop}},\"LoopLimit\": {{LoopLimit}},\"ReturnResult\": {{ReturnResult}}}";
            try
            {
                if (RunOnce)
                    apiCallBody = apiCallBody.Replace("{{RunOnce}}", "true");
                else
                    apiCallBody = apiCallBody.Replace("{{RunOnce}}", "false");

                if (InfiniteLoop)
                    apiCallBody = apiCallBody.Replace("{{InfiniteLoop}}", "true");
                else
                    apiCallBody = apiCallBody.Replace("{{InfiniteLoop}}", "false");

                apiCallBody = apiCallBody.Replace("{{LoopLimit}}", LoopLimit.ToString());

                if (ReturnResult)
                    apiCallBody = apiCallBody.Replace("{{ReturnResult}}", "true");
                else
                    apiCallBody = apiCallBody.Replace("{{ReturnResult}}", "false");



                string result = imageClient.MakePostCall(algorithmsDescriptionMap[algorithmId].GetUri(ipAddress), apiCallBody);
                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.ExecuteAlgorithmScalar()\n" + apiCallBody + "\n" + ex.Message);
                Console.ResetColor();
            }
            return null;
        }

        public string ExecuteAlgorithmScalar(string algorithmId, ComputeDeviceInfo computeDeviceInfo)
        {
            string apiCallBody = "{\n\"Fbp\":[\"Start\",\"\",\"" + algorithmsDescriptionMap[algorithmId].GetScalarExecuteCommand(computeDeviceInfo.IpAddress) + "\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
            try
            {
                string result = imageClient.MakePostCall(algorithmsDescriptionMap[algorithmId].GetUri(computeDeviceInfo.IpAddress), apiCallBody);
                return result;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.ExecuteAlgorithmScalar()\n" + apiCallBody + "\n" + ex.Message);
                Console.ResetColor();
            }
            return null;
        }

        public List<CameraConfiguration> GetAllCameraConfigurations()
        {
            List<CameraConfiguration> result = new List<CameraConfiguration>();
            foreach (var item in cameraConfigurationsMap)
            {
                result.Add(item.Value);
            }

            return result;
        }

        public ReplacementConfiguration ReadConfigurationFromFile(string path)
        {
            Dictionary<string, string> replacementStrings = new Dictionary<string, string>();

            List<DrwReplacementConfigurationUnit> replacers = JsonConvert.DeserializeObject<List<DrwReplacementConfigurationUnit>>(File.ReadAllText(path));

            foreach (var item in replacers)
            {
                replacementStrings[item.ToReplace] = item.ReplaceWith;
            }

            ReplacementConfiguration configuration = new ReplacementConfiguration(replacementStrings);
            return configuration;
        }

        public DrwConnection ExtractDrwConnectionFromNav(XPathNavigator nav)
        {
            if (!nav.HasChildren)
                return null;

            int id = -1;
            int fromId = -1;
            int toId = -1;

            nav.MoveToFirstChild();

            do
            {
                if (nav.Name.ToLower() == "id")
                    try
                    {
                        id = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("Id not an integer in DrwFile", e); }
                else if (nav.Name.ToLower() == "fromid")
                    try
                    {
                        fromId = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("FromId not an integer in DrwFile", e); }
                else if (nav.Name.ToLower() == "toid")
                    try
                    {
                        toId = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("ToId not an integer in DrwFile", e); }
            } while (nav.MoveToNext());

            DrwConnection connection = new DrwConnection(id, fromId, toId);

            return connection;
        }

        public DrwBlock ExtractDrwBlockFromNav(XPathNavigator nav, ReplacementConfiguration config)
        {
            if (!nav.HasChildren)
                return null;

            int id = -1;
            string description = null;

            nav.MoveToFirstChild();

            do
            {
                if (nav.Name.ToLower() == "id")
                    try
                    {
                        id = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("Id not an integer in DrwFile", e); }
                else if (nav.Name.ToLower() == "description")
                    description = ReplacementConfigurationSanitizer(nav.Value, config);
            } while (nav.MoveToNext());

            DrwBlock block = new DrwBlock(id, description);

            return block;
        }

        private string ReplacementConfigurationSanitizer(string value, ReplacementConfiguration config)
        {
            foreach (var pair in config.ReplacementStrings)
            {
                value = value.Replace(pair.Key, pair.Value);
            }
            return value;
        }

        private string RemoveSlashes(string str)
        {
            return str.Replace("\\", "");
        }

        public List<ComputeDeviceInfo> GetComputeDevicesList()
        {
            return computeDeviceInfoList;
        }

        public AlgorithmDescription QueryAlgoTypeId(string algoId)
        {
            return algorithmsDescriptionMap[algoId];
        }

        public CameraConfiguration QueryCameraDescription(int cameraId)
        {
            if (cameraConfigurationsMap.ContainsKey(cameraId))
                return cameraConfigurationsMap[cameraId];
            return null;
        }

        public void UnloadAllAlgorithms()
        {
            foreach (var deviceInfo in computeDeviceInfoList)
            {
                if (unloadCommandDeviceTypeToCommadMap.ContainsKey(deviceInfo.DeviceTypeId))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("[INFO] UnloadAllAlgorithm(" + deviceInfo.DeviceTypeId + " " + deviceInfo.IpAddress + "): Request to unload algorithm started");
                    Console.ResetColor();

                    imageClient.MakePostCall(deviceInfo.IpAddress, unloadCommandDeviceTypeToCommadMap[deviceInfo.DeviceTypeId]);

                    Console.Write("[INFO] UnloadAllAlgorithm(" + deviceInfo.DeviceTypeId + " " + deviceInfo.IpAddress + "): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SUCCESS");
                    Console.ResetColor();
                }
            }
        }

        public void UnloadAlgorithm(string algorithmId, ComputeDeviceInfo computeDeviceInfo)
        {
            if (algorithmsDescriptionMap.ContainsKey(algorithmId))
            {
                bool IsDeviceSupported = false;
                foreach (var deviceId in algorithmsDescriptionMap[algorithmId].SupportedDeviceTypeIdList)
                {
                    if (deviceId == computeDeviceInfo.DeviceTypeId)
                    {
                        IsDeviceSupported = true;
                        break;
                    }
                }

                if (!IsDeviceSupported)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] UnloadAlgorithm(" + algorithmId + ", " + computeDeviceInfo.IpAddress + "): The device doesn't support the algorithm");
                    Console.ResetColor();
                    return;
                }

                imageClient.MakePostCall(computeDeviceInfo.IpAddress, algorithmsDescriptionMap[algorithmId].GetUnloadCommand(computeDeviceInfo.IpAddress));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] UnloadAlgorithm(" + algorithmId + ", " + computeDeviceInfo.IpAddress + "): We cannot find the algorithmId");
                Console.ResetColor();
            }
        }
    }
}
