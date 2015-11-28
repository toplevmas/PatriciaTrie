using System.Collections.Generic;

namespace PatriciaTrieLib
{
    public class PatriciaTrieNode
    {
        public PatriciaTrieNode(char key, PatriciaTrieNode parent = null)
        {
            Key = key;
            Parent = parent;
            Childs = new List<PatriciaTrieNode>();
        }

        public PatriciaTrieNode(char key, PatriciaTrieNode parent, int value)
            : this('$', parent)
        {
            Value = value;
        }

        public char Key { get; private set; }

        public int? Value { get; private set; }

        public PatriciaTrieNode Parent { get; private set; }

        public List<PatriciaTrieNode> Childs { get; private set; }
    }
}
