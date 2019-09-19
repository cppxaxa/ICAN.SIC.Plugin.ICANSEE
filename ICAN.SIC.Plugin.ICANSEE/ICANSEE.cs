using ICAN.SIC.Abstractions;
using ICAN.SIC.Abstractions.IMessageVariants.ICANSEE;
using ICAN.SIC.Plugin.ICANSEE.Client;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEE : AbstractPlugin
    {
        ImageClient imageClient;
        public ICANSEEHelper helper;
        public ICANSEEUtility utility;
        ICANSEELogger logger;

        string brokerHubHost, brokerHubPort;

        public ICANSEE() : base("ICANSEEv1")
        {
            imageClient = new ImageClient();

            brokerHubHost = System.Configuration.ConfigurationSettings.AppSettings["ChatInterfaceHost"];
            brokerHubPort = System.Configuration.ConfigurationSettings.AppSettings["ChatInterfacePort"];

            logger = new ICANSEELogger();
            utility = new ICANSEEUtility(logger, imageClient, brokerHubHost, brokerHubPort);
            helper = new ICANSEEHelper(logger, utility, imageClient, brokerHubHost, brokerHubPort);

            hub.Subscribe<IInputMessage>(this.IInputMessageProcessor);
        }

        private string FormatBooleanStatus(ControlFunction controlFunction, bool status)
        {
            string result = "";
            string statusString = "false";
            if (status) statusString = "true";

            result += "{\"ControlFunction\":\"" + controlFunction.ToString() + "\", \"Status\":" + statusString + "}";
            return result;
        }

        private void IInputMessageProcessor(IInputMessage inputMessage)
        {
            try
            {
                Console.WriteLine("[INFO] ICANSEE.IInputMessage received (" + inputMessage.ControlFunction.ToString() + "): " + JsonConvert.SerializeObject(inputMessage));

                List<string> param = inputMessage.Parameters;
                string result = "";
                string errorLog = "";
                bool status;
                switch (inputMessage.ControlFunction)
                {
                    case ControlFunction.AddCamera:
                        // "0", "1", null, "Default Webcam", "camera"
                        //helper.AddReplaceCameraConfiguration(1, new CameraConfiguration(0, null, "Default Webcam", 1, "camera"));

                        helper.AddReplaceCameraConfiguration(int.Parse(param[1]), new CameraConfiguration(int.Parse(param[0]), param[2], param[3], int.Parse(param[1]), param[4]));
                        break;

                    case ControlFunction.DisplayImageInServerGUI:
                        // firstDevice.ComputeDeviceId, port.ToString()
                        // string result = utility.DisplayImageWindow(firstDevice, port);

                        result = utility.DisplayImageWindow(utility.computeDeviceInfoMap[param[0]], int.Parse(param[1]));
                        if (result == null) errorLog = "Error occurred @ " + ControlFunction.DisplayImageInServerGUI.ToString();
                        break;

                    case ControlFunction.ExecutePresetExtended:
                        // presetId, cameraId, postResultProcessingStatement

                        logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before executing preset: " + param[0] + "," + param[1]);
                        result = helper.ExecutePresetExtended(param[0], helper.QueryCameraDescription(int.Parse(param[1])), utility.ConvertHtmlToSymbols(param[2]).Replace("{{host}}", brokerHubHost).Replace("{{port}}", brokerHubPort));
                        if (result == null) errorLog = "Error occurred @ " + ControlFunction.ExecutePreset.ToString();

                        break;

                    case ControlFunction.UnloadPresetAndCamera:
                        // presetId
                        {
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadPresetAndCamera preset: " + param[0]);
                            var preset = utility.QueryPresetById(param[0]);
                            string computeDeviceId = preset.ComputeDeviceId;
                            int port = preset.Port;

                            var computeDeviceInfo = utility.QueryComputeDeviceById(computeDeviceId);

                            if (computeDeviceInfo == null)
                            {
                                status = false;
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                            }
                            else
                            {
                                var cameraDesc = helper.PresetCameraMap[param[0]];
                                if (cameraDesc == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("[WARNING] ICANSEE.cs: IInputMessageProcessor: " + "case ControlFunction.UnloadPresetAndCamera: " + "camera not associated with preset");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "1 Before UnloadCamera for preset (camera=" + cameraDesc.Id + ", preset=" + param[0] + ")");
                                    status = helper.UnloadCamera(cameraDesc.Id, param[0]);
                                    logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "1 After UnloadCamera for preset (camera=" + cameraDesc.Id + ", preset=" + param[0] + ")");
                                    result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                                }

                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "2 Before UnloadAlgorithm for preset: " + param[0]);
                                status = helper.UnloadAlgorithm(param[0]);
                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "2 After UnloadAlgorithm for preset: " + param[0]);
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);

                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "3 Before UnloadAlgorithm for preset: " + param[0]);
                                status = helper.UnloadAlgorithm(param[0]);
                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "3 After UnloadAlgorithm for preset: " + param[0]);
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);

                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "4 Before UnloadPreset: " + param[0] + "," + computeDeviceId + "," + port.ToString());
                                status = helper.UnloadPreset(param[0], computeDeviceInfo, port);
                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "4 After UnloadPreset (status=" + status.ToString() + "): " + param[0] + "," + computeDeviceId + "," + port.ToString());
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                            }
                            if (result == null) errorLog = "Error occurred @ " + ControlFunction.UnloadPresetAndCamera.ToString();
                        }

                        break;

                    case ControlFunction.ExecutePreset:
                        // "Preset1", "2"
                        // result = helper.ExecutePreset("Preset1", helper.QueryCameraDescription(2));

                        logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before executing preset: " + param[0] + "," + param[1]);
                        result = helper.ExecutePreset(param[0], helper.QueryCameraDescription(int.Parse(param[1])));
                        if (result == null) errorLog = "Error occurred @ " + ControlFunction.ExecutePreset.ToString();
                        break;

                    case ControlFunction.UnloadPreset:
                        // "Preset1", firstDevice.ComputeDeviceId, 5000
                        if (param.Count == 3)
                        {
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadPreset: " + param[0] + "," + param[1] + "," + param[2]);
                            status = helper.UnloadPreset(param[0], utility.QueryComputeDeviceById(param[1]), int.Parse(param[2]));
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "After UnloadPreset (status=" + status.ToString() + "): " + param[0] + "," + param[1] + "," + param[2]);
                            result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                        }
                        // "Preset1"
                        else if (param.Count == 1)
                        {
                            var preset = utility.QueryPresetById(param[0]);
                            string computeDeviceId = preset.ComputeDeviceId;
                            int port = preset.Port;

                            var computeDeviceInfo = utility.QueryComputeDeviceById(computeDeviceId);

                            if (computeDeviceInfo == null)
                            {
                                status = false;
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                            }
                            else
                            {
                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadAlgorithm: " + param[0]);
                                status = helper.UnloadAlgorithm(param[0]);
                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "After UnloadAlgorithm: " + param[0]);
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);

                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadPreset (param.Count=1): " + param[0] + "," + computeDeviceId + "," + port.ToString());
                                status = helper.UnloadPreset(param[0], computeDeviceInfo, port);
                                logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "After UnloadPreset (param.Count=1) (status=" + status.ToString() + "): " + param[0] + "," + computeDeviceId + "," + port.ToString());
                                result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                            }
                        }
                        break;

                    case ControlFunction.ListAllCameraInUse:

                        List<Tuple<string, string>> cameraInUse = helper.GetAllCameraInUse();
                        result = JsonConvert.SerializeObject(cameraInUse);
                        break;

                    case ControlFunction.UnloadCamera:
                        // CameraId: 1
                        logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadCamera: " + param[0]);
                        status = helper.UnloadCamera(int.Parse(param[0]), param[1]);
                        logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "After UnloadCamera: " + param[0]);
                        result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                        break;

                    case ControlFunction.UnloadAlgorithm:
                        // "Algo1", firstDevice.ComputeDeviceId, 5000
                        if (param.Count == 3)
                        {
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadAlgorithm: " + param[0]);
                            status = helper.UnloadAlgorithm(param[0], utility.QueryComputeDeviceById(param[1]), int.Parse(param[2]));
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "After UnloadAlgorithm: " + param[0]);
                            result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                        }
                        // Or "Preset1"
                        else if (param.Count == 1)
                        {
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "Before UnloadAlgorithm: " + param[0]);
                            status = helper.UnloadAlgorithm(param[0]);
                            logger.LogComputeDeviceStateMap(helper.ComputeDeviceStateMap, "After UnloadAlgorithm: " + param[0]);
                            result = FormatBooleanStatus(inputMessage.ControlFunction, status);
                        }
                        break;

                    case ControlFunction.QueryComputeDevice:
                        // Gets Compute Device State Map
                        result = "{\"CurrentState\":\"" + logger._GetShortFormattedStateMap(helper.ComputeDeviceStateMap).Replace("\n", "\\n") + "\"}";
                        break;

                    case ControlFunction.RunningTasks:
                        // Gets status of running presets and commands to unload
                        result = "<p style=\"font-family: Consolas;\">" + logger._GetShortFormattedStateMap(helper.ComputeDeviceStateMap).Replace("\n", "\\n") + "</p>";
                        break;
                }

                string json = result;
                string text = result;

                if (errorLog != "")
                    text = ", Error: " + errorLog;

                InformationMessage outputMessage = new InformationMessage(json, text);
                Hub.Publish<InformationMessage>(outputMessage);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ICANSEE.cs: IInputMessageProcessor: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("        ICANSEE.cs: IInputMessageProcessor: (InnerException) " + ex.InnerException.Message);
                Console.ResetColor();
            }
        }

        //public string ExecutePreset(int cameraId, string presetId)
        //{
        //    CameraConfiguration cameraConfiguration = helper.QueryCameraDescription(cameraId);
        //    return helper.ExecutePreset(presetId, cameraConfiguration);
        //}

        public FBPGraph ReadFBPConfiguration(string filepath)
        {
            ReplacementConfiguration config = utility.ReadConfigurationFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICANSEEDrwReplacementConfiguration.json"));

            FBPGraph graph = helper.GenerateFBPGraphFromDrwFile(File.OpenRead(filepath), config);

            // Debug Replacers
            string dumpOfConvertedValue = string.Empty;
            foreach (var pair in graph.GetBlockFromId)
            {
                dumpOfConvertedValue += pair.Value.description + "\r\n\r\n\r\n";
            }
            File.WriteAllText("Debug Replacers Result.txt", dumpOfConvertedValue);

            return graph;
        }

        public void Execute(List<string> FbpCommands, bool RunOnce = true, bool InfiniteLoop = false, int LoopLimit = 1)
        {
            // ReturnResult = false
            CommandType command = new CommandType(FbpCommands, RunOnce, InfiniteLoop, LoopLimit, false);
            string jsonCommand = JsonConvert.SerializeObject(command);
            imageClient.MakePostCall(jsonCommand);
        }

        public string ExecuteScalar(List<string> FbpCommands, bool RunOnce = true, bool InfiniteLoop = false, int LoopLimit = 1)
        {
            // ReturnResult = true
            CommandType command = new CommandType(FbpCommands, RunOnce, InfiniteLoop, LoopLimit, true);
            string jsonCommand = JsonConvert.SerializeObject(command);
            return imageClient.MakePostCall(jsonCommand);
        }

        public FBPGraph GenerateFBPGraph(string filepath)
        {
            ReplacementConfiguration config = utility.ReadConfigurationFromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICANSEEDrwReplacementConfiguration.json"));
            FBPGraph graph = helper.GenerateFBPGraphFromDrwFile(File.OpenRead(filepath), config);
            return graph;
        }

        public override void Dispose()
        {
            imageClient = null;
            logger = null;

            utility = null;
            helper = null;

            hub.Unsubscribe<IInputMessage>(this.IInputMessageProcessor);
        }
    }
}
