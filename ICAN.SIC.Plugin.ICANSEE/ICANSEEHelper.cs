using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEHelper
    {
        ICANSEEUtility utility = new ICANSEEUtility();

        public FBPGraph GenerateFBPGraphFromDrwFile(Stream drwFileStream, ReplacementConfiguration configuration)
        {
            XPathDocument xmlPathDoc = new XPathDocument(drwFileStream);
            XPathNavigator navigator = xmlPathDoc.CreateNavigator();

            XPathNodeIterator blockIterator = navigator.SelectDescendants("block", "", false);
            XPathNodeIterator connectionIterator = navigator.SelectDescendants("connection", "", false);

            int count = connectionIterator.Count;

            List<DrwBlock> blocks = new List<DrwBlock>();
            List<DrwConnection> connections = new List<DrwConnection>();

            while (blockIterator.MoveNext())
            {
                XPathNavigator nav = blockIterator.Current.Clone();

                DrwBlock block = utility.ExtractDrwBlockFromNav(nav, configuration);

                if (block != null)
                    blocks.Add(block);
            }

            while (connectionIterator.MoveNext())
            {
                XPathNavigator nav = connectionIterator.Current.Clone();

                DrwConnection connection = utility.ExtractDrwConnectionFromNav(nav);

                if (connection != null)
                    connections.Add(connection);
            }

            FBPGraph graph = new FBPGraph(blocks, connections);

            return graph;
        }

        public List<ICANSEEAPICall> GetApiCalls(FBPGraph graph)
        {
            List<ICANSEEAPICall> result = new List<ICANSEEAPICall>();

            throw new NotImplementedException();

            return result;
        }
    }
}
