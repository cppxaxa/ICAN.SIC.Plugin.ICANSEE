using ICAN.SIC.Plugin.ICANSEE.DataTypes;
using System.Collections;
using System.Collections.Generic;

namespace ICAN.SIC.Plugin.ICANSEE
{
    public class FBPGraph
    {
        public List<DrwBlock> blocks = new List<DrwBlock>();
        public List<DrwConnection> connections = new List<DrwConnection>();

        public Dictionary<int, DrwBlock> GetBlockFromId = new Dictionary<int, DrwBlock>();

        public Dictionary<int, List<DrwBlock>> GetFromBlocks = new Dictionary<int, List<DrwBlock>>();
        public Dictionary<int, List<DrwBlock>> GetToBlocks = new Dictionary<int, List<DrwBlock>>();

        public FBPGraph(List<DrwBlock> blocks, List<DrwConnection> connections)
        {
            this.blocks = blocks;
            this.connections = connections;

            // Build block from id
            foreach (var block in blocks)
            {
                GetBlockFromId[block.id] = block;
            }

            // Build GetFromBlock and GetToBlock
            foreach (var connection in connections)
            {
                if (!GetFromBlocks.ContainsKey(connection.toId))
                    GetFromBlocks[connection.toId] = new List<DrwBlock>();

                GetFromBlocks[connection.toId].Add(GetBlockFromId[connection.fromId]);

                if (!GetToBlocks.ContainsKey(connection.fromId))
                    GetToBlocks[connection.fromId] = new List<DrwBlock>();

                GetToBlocks[connection.fromId].Add(GetBlockFromId[connection.toId]);
            }
        }
    }
}