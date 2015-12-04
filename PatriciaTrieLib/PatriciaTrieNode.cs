using System.Collections.Generic;

namespace PatriciaTrieLib
{
    public class PatriciaTrieNode
    {
        public PatriciaTrieNode(char key, byte alphabet, PatriciaTrieNode parent = null)
        {
            Key = key;
            Parent = parent;
            Childs = new PatriciaTrieNode[alphabet];
        }

        public char Key { get; private set; }

        public PatriciaTrieNode Parent { get; private set; }

        public PatriciaTrieNode[] Childs { get; private set; }
    }
}
