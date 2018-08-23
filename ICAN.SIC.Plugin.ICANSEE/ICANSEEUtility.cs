using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using Newtonsoft.Json;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEUtility
    {
        public ReplacementConfiguration ReadConfigurationFromFile(string path)
        {
            Dictionary<string, string> replacementStrings = new Dictionary<string, string>();

            List<DrwReplacementConfigurationUnit> replacers = JsonConvert.DeserializeObject<List<DrwReplacementConfigurationUnit>>(File.ReadAllText(path));

            foreach (var item in replacers)
            {
                replacementStrings[item.ToReplace] = item.ReplaceWith;
            }

            ReplacementConfiguration configuration = new ReplacementConfiguration(replacementStrings);
            return configuration;
        }

        public ICANSEEAPICall ConvertDescriptionToAPICall(ICANSEEApiCallDescription callDescription)
        {
            ICANSEEAPICall call = new ICANSEEAPICall(callDescription.Uri, callDescription.UriSuffix, callDescription.PostData, callDescription.Header);
            return call;
        }

        public DrwConnection ExtractDrwConnectionFromNav(XPathNavigator nav)
        {
            if (!nav.HasChildren)
                return null;

            int id = -1;
            int fromId = -1;
            int toId = -1;

            nav.MoveToFirstChild();

            do
            {
                if (nav.Name.ToLower() == "id")
                    try
                    {
                        id = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("Id not an integer in DrwFile", e); }
                else if (nav.Name.ToLower() == "fromid")
                    try
                    {
                        fromId = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("FromId not an integer in DrwFile", e); }
                else if (nav.Name.ToLower() == "toid")
                    try
                    {
                        toId = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("ToId not an integer in DrwFile", e); }
            } while (nav.MoveToNext());

            DrwConnection connection = new DrwConnection(id, fromId, toId);

            return connection;
        }

        public DrwBlock ExtractDrwBlockFromNav(XPathNavigator nav, ReplacementConfiguration config)
        {
            if (!nav.HasChildren)
                return null;

            int id = -1;
            string description = null;

            nav.MoveToFirstChild();

            do
            {
                if (nav.Name.ToLower() == "id")
                    try
                    {
                        id = int.Parse(nav.Value.Trim());
                    }
                    catch (Exception e) { throw new Exception("Id not an integer in DrwFile", e); }
                else if (nav.Name.ToLower() == "description")
                    description = ReplacementConfigurationSanitizer(nav.Value, config);
            } while (nav.MoveToNext());

            DrwBlock block = new DrwBlock(id, description);

            return block;
        }

        private string ReplacementConfigurationSanitizer(string value, ReplacementConfiguration config)
        {
            foreach (var pair in config.ReplacementStrings)
            {
                value = value.Replace(pair.Key, pair.Value);
            }
            return value;
        }

        private string RemoveSlashes(string str)
        {
            return str.Replace("\\", "");
        }

        /*
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
        */

    }
}
