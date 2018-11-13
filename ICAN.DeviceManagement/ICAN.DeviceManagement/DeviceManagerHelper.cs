using System;
using System.Collections.Generic;
using ICAN.SIC.Plugin.ICANSEE;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;

namespace ICAN.DeviceManagement.Manager
{
    public class DeviceManagerHelper
    {
        Dictionary<string, Dictionary<int, AssignmentConfiguration>> DevicePortAssignmentMapping;

        public DeviceManagerHelper(Dictionary<string, Dictionary<int, AssignmentConfiguration>> DevicePortAssignmentMapping)
        {
            this.DevicePortAssignmentMapping = DevicePortAssignmentMapping;
        }

        public void AddComputeDevice(ComputeDeviceInfo computeDevice)
        {
            if (!DevicePortAssignmentMapping.ContainsKey(computeDevice.ComputeDeviceId))
            {
                DevicePortAssignmentMapping.Add(computeDevice.ComputeDeviceId, new Dictionary<int, AssignmentConfiguration>());

                foreach (var item in computeDevice.PortList)
                {
                    DevicePortAssignmentMapping[computeDevice.ComputeDeviceId].Add(item, null);
                }
            }
        }

        public int CheckDeviceFreeCapacity(string computeDeviceId)
        {
            if (DevicePortAssignmentMapping.ContainsKey(computeDeviceId))
            {
                int total = DevicePortAssignmentMapping[computeDeviceId].Count;
                int count = 0;

                foreach (var item in DevicePortAssignmentMapping[computeDeviceId])
                {
                    if (item.Value != null)
                        count++;
                }

                return count * 100 / total;
            }

            return -1;
        }

        public bool InvokePreset(Preset preset)
        {
            string computeDeviceId = preset.GetComputeDeviceId();
            List<int> cameraIdList = preset.GetCameraIdList();

            // If computeDeviceId does not exists, return false
            if (!DevicePortAssignmentMapping.ContainsKey(computeDeviceId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ComputeDeviceId {0} for PresetId {1} not found", computeDeviceId, preset.PresetId);
                Console.ResetColor();

                return false;
            }

            // If the computeDeviceId is packed, return false
            int emptyPortNumer = -1;
            foreach (var port in DevicePortAssignmentMapping[computeDeviceId])
            {
                if (port.Value == null)
                {
                    emptyPortNumer = port.Key;
                    break;
                }
            }

            if (emptyPortNumer == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] ComputeDeviceId {0} for PresetId {1} not free", computeDeviceId, preset.PresetId);
                Console.ResetColor();

                return false;
            }

            // Check which cameraId are available
            // Try releasing all the cameras
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[WARNING] No camera check done for PresetId {1}, ComputeDeviceId {0}", computeDeviceId, preset.PresetId);
            Console.ResetColor();

            // Assign to device with port
            DevicePortAssignmentMapping[computeDeviceId][emptyPortNumer] = new AssignmentConfiguration()
            {
                AlgorithmsId = preset.GetAlgorithmId(),
                CameraIdList = preset.GetCameraIdList(),
                PresetId = preset.PresetId
            };

            // Call to the device server
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[WARNING] No device call implementation for PresetId {1}, ComputeDeviceId {0}", computeDeviceId, preset.PresetId);
            Console.ResetColor();

            return true;
        }

        public List<string> GetAssignedTasks()
        {
            List<string> report = new List<string>();

            foreach (var device in DevicePortAssignmentMapping)
            {
                string line = "";
                string result = device.Key + ": ";

                foreach (var port in device.Value)
                {
                    if (port.Value != null)
                    {
                        line += "[" + port + ": {";

                        foreach (var cameraId in port.Value.CameraIdList)
                        {
                            line += "`" + cameraId + "`";
                        }

                        line += "}, " + port.Value.AlgorithmsId + "}]";
                    }
                }

                if (line.Length > 0)
                    report.Add(result + line);
            }

            return report;
        }
    }
}