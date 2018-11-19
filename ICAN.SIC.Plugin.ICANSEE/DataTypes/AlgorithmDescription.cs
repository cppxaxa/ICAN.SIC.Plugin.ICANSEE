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
        public string UnloadCommand;

        private string EncodeStringForTransmission(string input, string ipAddress, string port)
        {
            return input.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("{{host}}", ipAddress).Replace("{{port}}", port);
        }

        public string GetScalarExecuteCommand(string ipAddress, string port)
        {
            return EncodeStringForTransmission(ScalarExecuteCommand, ipAddress, port);
        }

        public string GetUnloadCommand(string ipAddress, string port)
        {
            return EncodeStringForTransmission(UnloadCommand, ipAddress, port);
        }

        public string GetInitCommand(string ipAddress, string port)
        {
            return EncodeStringForTransmission(InitCommand, ipAddress, port);
        }

        public string GetUri(string ipAddress, string port)
        {
            return Uri.Replace("{{host}}", ipAddress).Replace("{{port}}", port);
        }
    }
}
