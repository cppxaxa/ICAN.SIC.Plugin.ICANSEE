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
        ICANSEEHelper helper;
        ICANSEEUtility utility;

        public ICANSEE() : base("ICANSEEv1")
        {
            imageClient = new ImageClient();

            string brokerHubHost = System.Configuration.ConfigurationSettings.AppSettings["ChatInterfaceHost"];
            string brokerHubPort = System.Configuration.ConfigurationSettings.AppSettings["ChatInterfacePort"];

            utility = new ICANSEEUtility(imageClient, brokerHubHost, brokerHubPort);
            helper = new ICANSEEHelper(utility, imageClient, brokerHubHost, brokerHubPort);

            hub.Subscribe<IInputMessage>(this.IInputMessageProcessor);
        }

        private void IInputMessageProcessor(IInputMessage inputMessage)
        {
            Console.Write("[INFO] ICANSEE.IInputMessage received (" + inputMessage.ControlFunction.ToString() + "): " + JsonConvert.SerializeObject(inputMessage));

            List<string> param = inputMessage.Parameters;
            string result = "";
            string errorLog = "";
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

                case ControlFunction.ExecutePreset:
                    // "Preset1", "2"
                    // result = helper.ExecutePreset("Preset1", helper.QueryCameraDescription(2));

                    result = helper.ExecutePreset(param[0], helper.QueryCameraDescription(int.Parse(param[1])));
                    if (result == null) errorLog = "Error occurred @ " + ControlFunction.ExecutePreset.ToString();
                    break;
            }

            string json = result;
            string text = result;

            if (errorLog != "")
                text = ", Error: " + errorLog;

            InformationMessage outputMessage = new InformationMessage(json, text);
            Hub.Publish<InformationMessage>(outputMessage);
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
    }
}
