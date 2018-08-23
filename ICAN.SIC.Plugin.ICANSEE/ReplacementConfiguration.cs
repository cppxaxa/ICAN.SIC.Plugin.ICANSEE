using System.Collections.Generic;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ReplacementConfiguration
    {
        public Dictionary<string, string> ReplacementStrings;

        public ReplacementConfiguration(Dictionary<string, string> replacementStrings)
        {
            ReplacementStrings = replacementStrings;
        }
    }
}