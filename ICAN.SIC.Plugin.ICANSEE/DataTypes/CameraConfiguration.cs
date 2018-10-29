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
        public string Type { get; set; }

        public CameraConfiguration()
        {

        }

        public CameraConfiguration(int index, string url, string label, int id, string type)
        {
            this.SetValues(index, url, label, id, type);
        }

        public void SetValues(int index, string url, string label, int id, string type)
        {
            this.Index = index;
            this.Url = url;
            this.Label = label;
            this.Id = id;
            this.Type = type;
        }
    }
}
