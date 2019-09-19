using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEELogger
    {
        string LogFilename;
        StreamWriter writer;

        public ICANSEELogger(string filename = "ICANSEELogs.txt")
        {
            this.LogFilename = filename;
            writer = new StreamWriter(filename);
        }

        public void LogComputeDeviceStateMap(Dictionary<ComputeDeviceInfo, Dictionary<int, ComputeDeviceState>> computeDeviceStateMap, string msg)
        {
            string formattedString = "";

            formattedString += "------------------------------------------------------------\n";
            formattedString += "Message:\t" + msg + "\n\n";
            formattedString += _GetShortFormattedStateMap(computeDeviceStateMap);

            writer.WriteLine(formattedString + "\n\n");
            writer.Flush();
        }

        public void Dispose()
        {
            this.writer.Flush();
            this.writer.Close();
        }

        public string _GetShortFormattedStateMap(Dictionary<ComputeDeviceInfo, Dictionary<int, ComputeDeviceState>> computeDeviceStateMap)
        {
            string formattedString = "";
            formattedString += "------------------------------------------------------------\n";

            foreach (var item in computeDeviceStateMap)
            {
                var computeInfo = item.Key;

                formattedString += "ComputeDev: " + computeInfo.ComputeDeviceId + "/ " + computeInfo.Label + "/ " + computeInfo.IpAddress + "\n";

                foreach (var cell in item.Value)
                {
                    int port = cell.Key;
                    var state = cell.Value;

                    formattedString += "\t\tPort(" + port.ToString() + ")\n";
                    formattedString += "\t\t" + _GetShortFormattedComputeDeviceState(state);
                    formattedString += "\n\n";
                }
            }

            formattedString += "--------------------------END-------------------------------\n";

            return formattedString;
        }

        public string _GetShortFormattedComputeDeviceState(ComputeDeviceState state)
        {
            string result = "(";

            foreach (var algo in state.AssignedAlgorithmDescriptionMap)
            {
                if (algo.Value)
                    result += "Algo=" + algo.Key.AlgorithmTypeId + "," + algo.Key.Name + ";";
            }

            foreach (var preset in state.AssignedPresetDescriptionMap)
            {
                if (preset.Value)
                    result += "PresetId&Name=" + preset.Key.Id + "," + preset.Key.Name + ";";
            }

            foreach (var camera in state.OpenCameraMap)
            {
                if (camera.Value)
                    result += "Camera=" + camera.Key.Id + "," + camera.Key.Label + ";";
            }
            

            result += ")";
            return result;
        }
    }
}
