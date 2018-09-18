using ICAN.SIC.Plugin.ICANSEE.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEE
    {
        ImageClient imageClient;
        ICANSEEHelper helper;
        ICANSEEUtility utility;

        public ICANSEE()
        {
            imageClient = new ImageClient("localhost", 5000);

            utility = new ICANSEEUtility(imageClient);
            helper = new ICANSEEHelper(utility, imageClient);
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

        public void MakeDummyPostCall()
        {
            string result = imageClient.MakePostCall("{	\"Fbp\":[		\"Start\",		\"\",		\"result = tfnet.return_predict(imageSrc)\\noutput = str(result)\"		],	\"RunOnce\": true,	\"InfiniteLoop\": false,	\"LoopLimit\": 1,	\"ReturnResult\": true }");
            Console.WriteLine(result);
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

        public void MakeDummyGetCall()
        {
            string result = imageClient.MakeGetCall();
            Console.WriteLine(result);
        }
    }
}
