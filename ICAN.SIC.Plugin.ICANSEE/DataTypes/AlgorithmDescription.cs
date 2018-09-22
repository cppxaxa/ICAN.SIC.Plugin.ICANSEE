using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class AlgorithmDescription
    {
        public string Id;
        public string AlgorithmTypeId;
        public List<string> SupportedDeviceTypeIdList;
        public string Name;
        public string Uri;
        public string InitCommand;
        public string ScalarExecuteCommand;
        public string Description;

        public string GetScalarExecuteCommand(string ipAddress)
        {
            return ScalarExecuteCommand.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("{{host}}", ipAddress);
        }

        public string GetInitCommand(string ipAddress)
        {
            return InitCommand.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("{{host}}", ipAddress);
        }

        public string GetUri(string ipAddress)
        {
            return Uri.Replace("{{host}}", ipAddress);
        }
    }
}
