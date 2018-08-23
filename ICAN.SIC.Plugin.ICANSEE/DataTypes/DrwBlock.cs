using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE.DataTypes
{
    public class DrwBlock
    {
        public int id;
        public string description;

        public DrwBlock(int id, string description)
        {
            this.id = id;
            this.description = description;
        }
    }
}
