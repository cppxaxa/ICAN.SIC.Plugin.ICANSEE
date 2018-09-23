using ICAN.SIC.Abstractions;
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

            utility = new ICANSEEUtility(imageClient);
            helper = new ICANSEEHelper(utility, imageClient);
        }

        public string ExecuteScalar(int cameraId, string algoId)
        {
            return helper.ExecuteScalar(cameraId, algoId);
        }

        public void AddReplaceCameraConfiguration(int newCustomId, CameraConfiguration cameraConfig)
        {
            helper.AddReplaceCameraConfiguration(newCustomId, cameraConfig);
        }

        public bool AddCameraConfiguration(int newCustomId, CameraConfiguration cameraConfig)
        {
            return helper.AddCameraConfiguration(newCustomId, cameraConfig);
        }

        public List<ComputeDeviceInfo> GetComputeDevicesList()
        {
            return helper.GetComputeDevicesList();
        }

        public List<CameraConfiguration> GetAllCameraConfigurations()
        {
            return helper.GetAllCameraConfigurations();
        }

        public List<AlgorithmDescription> GetAlgorithmsList()
        {
            return helper.GetAlgorithmsList();
        }

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
