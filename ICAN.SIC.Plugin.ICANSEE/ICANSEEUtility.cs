using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEUtility
    {
        public ICANSEEAPICall ConvertDescriptionToAPICall(ICANSEEApiCallDescription callDescription)
        {
            ICANSEEAPICall call = new ICANSEEAPICall(callDescription.Uri, callDescription.UriSuffix, callDescription.PostData, callDescription.Header);
            return call;
        }

        public string NormalizeFbpText(string line)
        {
            line = line.Trim();

            string left = string.Empty, right = string.Empty;

            // Remove suffix comma at last if present
            while (line[line.Length - 1] == ',')
                line = line.Substring(0, line.Length - 1);

            // Break at -> if present
            string[] splitAtArrow = line.Split(new string[] { "->" }, 2, StringSplitOptions.RemoveEmptyEntries);

            bool noArrow = true;
            left = splitAtArrow[0];
            if (splitAtArrow.Length > 1)
            {
                right = splitAtArrow[1];
                noArrow = false;
            }

            left = RemoveSlashes(left);
            right = RemoveSlashes(right);

            string completeText = left.Trim() + "," + right.Trim();

            string[] spaceSplit = completeText.Split(' ');

            left = spaceSplit[0];
            while (left[left.Length - 1] == ',')
                left = left.Substring(0, left.Length - 1);

            if (noArrow)
            {
                right = string.Empty;
            }
            else
            {
                right = spaceSplit[spaceSplit.Length - 1];
            }

            if (right == string.Empty)
                return left;
            else
                return left.Replace('_', ' ') + "," + right.Replace('_', ' ');
        }

        private string RemoveSlashes(string str)
        {
            return str.Replace("\\", "");
        }
    }
}
