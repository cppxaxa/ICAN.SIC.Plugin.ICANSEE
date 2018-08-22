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
            List<ICANSEEAPICall> result = new List<ICANSEEAPICall>();

            FBPGraph graph = helper.GenerateFBPGraph(File.ReadAllLines(filepath));
            result = helper.GetApiCalls(graph);

            return result;
        }
    }
}
