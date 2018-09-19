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
        ImageClient imageClient;

        public ICANSEEUtility(ImageClient imageClient, string algoDescriptionFileName = "AlgorithmsDescriptionList.json")
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
        }

        private void LoadAlgorithmDescriptionsFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            List<AlgorithmDescription> algoList = JsonConvert.DeserializeObject<List<AlgorithmDescription>>(fileContent);
            this.algorithmsDescriptionMap = algoList.ToDictionary(e => e.Id);
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

        public string LoadCamera(int cameraConfigId)
        {
            try
            {
                if (cameraConfigurationsMap.ContainsKey(cameraConfigId))
                {
                    CameraConfiguration cameraConfig = cameraConfigurationsMap[cameraConfigId];

                    string apiCallBody = "{\n\"Fbp\":[\"Start\",\"globals()['cap'] = cv2.VideoCapture({{index}})\\nret, frame = globals()['cap'].read()\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
                    if (cameraConfig.Url == null)
                    {
                        apiCallBody = apiCallBody.Replace("{{index}}", cameraConfig.Index.ToString());
                    }
                    else
                    {
                        apiCallBody = apiCallBody.Replace("{{index}}", "\"" + cameraConfig.Url + "\"");
                    }

                    string result = imageClient.MakePostCall("http://localhost:5000/task", apiCallBody);

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

        public bool LoadAlgorithm(string Id)
        {
            if (!algorithmsDescriptionMap.ContainsKey(Id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadAlgorithm(" + Id + ")\n - Algorithm Id not found");
                Console.ResetColor();

                return false;
            }

            string apiCallBody = "{\n\"Fbp\":[\"Start\",\"" + algorithmsDescriptionMap[Id].InitCommand + "\",\"\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
            try
            {
                string result = imageClient.MakePostCall(algorithmsDescriptionMap[Id].Uri, apiCallBody);
                Console.WriteLine("[INFO] ICANSEEUtility.LoadAlgorithm(" + Id + ")\n" + apiCallBody + "\n\n" + "Result: " + result);
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEEUtility.LoadAlgorithm(" + Id + ")\n" + apiCallBody + "\n" + ex.Message);
                Console.ResetColor();

                return false;
            }
        }

        public string ExecuteAlgorithm(bool RunOnce, bool InfiniteLoop, int LoopLimit, bool ReturnResult, string resultProcessingStatement, string algorithmId)
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



                string result = imageClient.MakePostCall(algorithmsDescriptionMap[algorithmId].Uri, apiCallBody);
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

        public string ExecuteAlgorithmScalar(string algorithmId)
        {
            string apiCallBody = "{\n\"Fbp\":[\"Start\",\"\",\"" + algorithmsDescriptionMap[algorithmId].ScalarExecuteCommand + "\"],\"RunOnce\": true,\"InfiniteLoop\": false,\"LoopLimit\": 1,\"ReturnResult\": true}";
            try
            {
                string result = imageClient.MakePostCall(algorithmsDescriptionMap[algorithmId].Uri, apiCallBody);
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
    }
}
