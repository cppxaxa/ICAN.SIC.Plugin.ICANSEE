using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICAN.SIC.Abstractions.IMessageVariants.ICANSEE;

namespace ICAN.SIC.Plugin.ICANSEE.DataTypes
{
    public class InformationMessage : IInformationMessage
    {
        public string Json { get; set; }
        public string Text { get; set; }

        public InformationMessage()
        {

        }

        public InformationMessage(string json, string text)
        {
            this.Json = json;
            this.Text = text;
        }
    }
}
