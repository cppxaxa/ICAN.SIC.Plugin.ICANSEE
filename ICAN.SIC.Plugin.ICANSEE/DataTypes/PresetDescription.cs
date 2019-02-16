using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE.DataTypes
{
    public class PresetDescription
    {
        public string Id;
        public string Name;
        public string AlgorithmId;
        public string AlgorithmAttributeKey;
        public string ComputeDeviceId;
        public int Port;
        public string Description;
        public bool RunOnce;
        public bool InfiniteLoop;
        public int LoopLimit;
        public bool ReturnResult;
        public string ResultProcessingStatement;

        public PresetDescription(string id, string name, string algorithmId, string computeDeviceId, 
                                 int port, bool runOnce, bool infiniteLoop, int loopLimit, 
                                 bool returnResult, string description = "", string algorithmAttributeKey = "ScalarExecuteCommand", string resultProcessingStatement = "")
        {
            Id = id;
            Name = name;
            AlgorithmId = algorithmId;
            AlgorithmAttributeKey = algorithmAttributeKey;
            ComputeDeviceId = computeDeviceId;
            Port = port;
            Description = description;
            RunOnce = runOnce;
            InfiniteLoop = infiniteLoop;
            LoopLimit = loopLimit;
            ReturnResult = returnResult;
            ResultProcessingStatement = resultProcessingStatement;
        }

        public PresetDescription Clone()
        {
            return new PresetDescription(Id, Name, AlgorithmId, ComputeDeviceId, 
                Port, RunOnce, InfiniteLoop, LoopLimit, ReturnResult, 
                Description, AlgorithmAttributeKey, ResultProcessingStatement);
        }

        private string EncodeStringForTransmission(string input, string ipAddress, string port)
        {
            return input.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("{{host}}", ipAddress).Replace("{{port}}", port);
        }

        public string GetResultProcessingStatement(string brokerHubIpAddress, string brokerHubPort)
        {
            return EncodeStringForTransmission(ResultProcessingStatement, brokerHubIpAddress, brokerHubPort);
        }

        public string GetCompleteExecuteCommand(AlgorithmDescription targetAlgorithmDescription, ComputeDeviceInfo targetComputeDeviceInfo, string port)
        {
            string attributeKey = "ScalarExecuteCommand";
            return GetCompleteExecuteCommandWithResultProcessingStatement(targetAlgorithmDescription, targetComputeDeviceInfo, port, attributeKey);
        }

        public string GetExecuteCommandWithCustomResultStatement(AlgorithmDescription targetAlgorithmDescription, ComputeDeviceInfo targetComputeDeviceInfo, string port, string customResultProcessingStatement)
        {
            string attributeKey = "ScalarExecuteCommand";
            return GetCompleteExecuteCommandWithResultProcessingStatement(targetAlgorithmDescription, targetComputeDeviceInfo, port, attributeKey, customResultProcessingStatement);
        }

        private string GetCompleteExecuteCommandWithResultProcessingStatement(AlgorithmDescription targetAlgorithmDescription, ComputeDeviceInfo targetComputeDeviceInfo, string port, string attributeKey = "ScalarExecuteCommand", string customResultProcessingStatement = null)
        {
            string errorList = "";
            if (targetAlgorithmDescription.Id != AlgorithmId)
                errorList += "[ERROR] PresetDescription::GetCompleteExecuteCommand() - Preset.AlgorithmId does not match with given 'targetAlgorithmDescription'\n";
            if (targetComputeDeviceInfo.ComputeDeviceId != ComputeDeviceId)
                errorList += "[ERROR] PresetDescription::GetCompleteExecuteCommand() - Preset.ComputeDeviceId does not match with given 'targetComputeDeviceInfo'\n";

            if (errorList != "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorList);
                Console.ResetColor();

                return null;
            }

            string ipAddress = targetComputeDeviceInfo.IpAddress;

            string algorithmCommand = null;
            switch (attributeKey)
            {
                case "ScalarExecuteCommand":
                    algorithmCommand = targetAlgorithmDescription.GetScalarExecuteCommand(ipAddress, port);
                    break;
                case "InitCommand":
                    algorithmCommand = targetAlgorithmDescription.GetInitCommand(ipAddress, port);
                    break;
                case "UnloadCommand":
                    algorithmCommand = targetAlgorithmDescription.GetUnloadCommand(ipAddress, port);
                    break;
            }

            // If custom result processing statement is found, encode-append-send
            if (customResultProcessingStatement != null)
            {
                algorithmCommand += "\\n" + EncodeStringForTransmission(customResultProcessingStatement, ipAddress, port);
                return algorithmCommand;
            }
            else if (ResultProcessingStatement == null || ResultProcessingStatement == "")
                return algorithmCommand;
            else
            {
                algorithmCommand += "\\n" + EncodeStringForTransmission(ResultProcessingStatement, ipAddress, port);
                return algorithmCommand;
            }
        }

        public string GetCompleteInitCommand(AlgorithmDescription targetAlgorithmDescription, ComputeDeviceInfo targetComputeDeviceInfo, string port)
        {
            string attributeKey = "InitCommand";
            return GetCompleteExecuteCommandWithResultProcessingStatement(targetAlgorithmDescription, targetComputeDeviceInfo, port, attributeKey);
        }

        public string GetCompleteUnloadCommand(AlgorithmDescription targetAlgorithmDescription, ComputeDeviceInfo targetComputeDeviceInfo, string port)
        {
            string attributeKey = "UnloadCommand";
            return GetCompleteExecuteCommandWithResultProcessingStatement(targetAlgorithmDescription, targetComputeDeviceInfo, port, attributeKey);
        }
    }
}
