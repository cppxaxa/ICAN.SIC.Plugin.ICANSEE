using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE.Client
{
    public class CommandType
    {
        public List<string> Fbp;
        public bool RunOnce;
        public bool InfiniteLoop;
        public int LoopLimit;
        public bool ReturnResult;

        public CommandType()
        {

        }

        public CommandType(List<string> fbp, bool runOnce, bool infiniteLoop, int loopLimit, bool returnResult)
        {
            Fbp = fbp;
            RunOnce = runOnce;
            InfiniteLoop = infiniteLoop;
            LoopLimit = loopLimit;
            ReturnResult = returnResult;
        }
    }
}
