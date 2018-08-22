using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEHelper
    {
        ICANSEEUtility utility = new ICANSEEUtility();

        public FBPGraph GenerateFBPGraph(string[] fbpLines)
        {
            FBPGraph graph = new FBPGraph();

            string wholeText = string.Empty;

            foreach (var line in fbpLines)
            {
                wholeText += utility.NormalizeFbpText(line) + "\n";
            }

            // Debug
            // File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleFBP", "Processed.txt"), wholeText);

            return graph;
        }

        public List<ICANSEEAPICall> GetApiCalls(FBPGraph graph)
        {
            List<ICANSEEAPICall> result = new List<ICANSEEAPICall>();

            foreach(var callDescription in graph)
            {
                result.Add(utility.ConvertDescriptionToAPICall(callDescription));
            }

            return result;
        }
    }
}
