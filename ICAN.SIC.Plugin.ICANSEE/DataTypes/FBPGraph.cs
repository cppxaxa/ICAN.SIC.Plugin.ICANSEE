using System.Collections;
using System.Collections.Generic;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class FBPGraph : IEnumerable<ICANSEEApiCallDescription>
    {
        List<ICANSEEApiCallDescription> callDescriptions = new List<ICANSEEApiCallDescription>();

        public IEnumerator<ICANSEEApiCallDescription> GetEnumerator()
        {
            foreach (var item in callDescriptions)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}