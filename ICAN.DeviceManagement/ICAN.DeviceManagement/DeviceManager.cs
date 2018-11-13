using ICAN.SIC.Plugin.ICANSEE;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.DeviceManagement.Manager
{
    public class AssignmentConfiguration
    {
        public string PresetId;
        public string AlgorithmsId;
        public List<int> CameraIdList;
    }

    public class DeviceManager
    {
        Dictionary<string, Preset> PresetMap = new Dictionary<string, Preset>();
        Dictionary<string, ComputeDeviceInfo> ComputeDeviceInfoMap = new Dictionary<string, ComputeDeviceInfo>();
        Dictionary<string, Dictionary<int, AssignmentConfiguration>> DevicePortAssignmentMapping = new Dictionary<string, Dictionary<int, AssignmentConfiguration>>();
        DeviceManagerHelper helper;

        public DeviceManager()
        {
            helper = new DeviceManagerHelper(DevicePortAssignmentMapping);
        }

        public void AddComputeDevice(ComputeDeviceInfo computeDevice)
        {
            ComputeDeviceInfoMap[computeDevice.ComputeDeviceId] = computeDevice;
            helper.AddComputeDevice(computeDevice);
        }

        public int CheckDeviceFreeCapacity(ComputeDeviceInfo computeDevice)
        {
            return helper.CheckDeviceFreeCapacity(computeDevice.ComputeDeviceId);
        }
        public int CheckDeviceFreeCapacity(string computeDeviceId)
        {
            return helper.CheckDeviceFreeCapacity(computeDeviceId);
        }

        public void UnloadDevice(ComputeDeviceInfo computeDevice, List<int> portList = null)
        {
            helper.UnloadDevice(computeDevice.ComputeDeviceId, portList);
        }

        public void UnloadDevice(string computeDeviceId, List<int> portList = null)
        {
            helper.UnloadDevice(computeDeviceId, portList);
        }

        public void ReleaseCamera(List<int> CameraIdList)
        {
            helper.ReleaseCamera(CameraIdList);
        }

        public bool InvokePreset(Preset preset)
        {
            PresetMap[preset.PresetId] = preset;
            return helper.InvokePreset(preset);
        }

        public List<string> GetAssignedTasks()
        {
            return helper.GetAssignedTasks();
        }
    }
}
