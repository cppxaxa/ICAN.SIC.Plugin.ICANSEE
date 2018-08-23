using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE.DataTypes
{
    public class DrwConnection
    {
        public int connectionId;

        public int fromId;
        public int toId;

        public DrwConnection(int connectionId, int fromId, int toId)
        {
            this.connectionId = connectionId;
            this.fromId = fromId;
            this.toId = toId;
        }
    }
}
