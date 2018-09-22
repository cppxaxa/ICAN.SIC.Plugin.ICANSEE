﻿using System;
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

        public string GetScalarExecuteCommand()
        {
            return ScalarExecuteCommand.Replace("\"", "\\\"").Replace("\n", "\\n");
        }

        public string GetInitCommand()
        {
            return ScalarExecuteCommand.Replace("\"", "\\\"").Replace("\n", "\\n");
        }
    }
}
