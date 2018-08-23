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
        ICANSEEHelper helper = new ICANSEEHelper();
        ICANSEEUtility utility = new ICANSEEUtility();

        public ICANSEE()
        {

        }

        public List<ICANSEEAPICall> ReadFBPConfiguration(string filepath)
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



            List<ICANSEEAPICall> result = helper.GetApiCalls(graph);

            return result;
        }
    }
}
