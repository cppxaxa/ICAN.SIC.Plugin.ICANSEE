using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class CameraConfiguration
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Url { get; set; }
        public string Label { get; set; }

        public CameraConfiguration()
        {

        }

        public CameraConfiguration(int index, string url, string label)
        {
            this.SetValues(index, url, label);
        }

        public void SetValues(int index, string url, string label)
        {
            this.Index = index;
            this.Url = url;
            this.Label = label;
        }
    }
}
