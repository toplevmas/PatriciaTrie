using System;
using System.Linq;

namespace PatriciaTrieLib
{
    public class PatriciaTrie
    {
        public PatriciaTrie()
        {
            Root = new PatriciaTrieNode('\0');
        }

        public PatriciaTrieNode Root { get; private set; }

        public int? Find(string key)
        {
            var node = Root;

            foreach (var e in key)
            {
                var child = node.Childs.FirstOrDefault(x => x.Key.Equals(e));
                if (child == null)
                    return null;
                node = child;
            }

            node = node.Childs.FirstOrDefault(child => child.Key.Equals('$'));

            return node == null ? null : node.Value;
        }

        public void Insert(string key, int value)
        {
            if (key.Contains('$'))
                throw new ArgumentException("Key contains not allowed symbols");

            var node = Root;

            foreach (var e in key)
            {
                var child = node.Childs.FirstOrDefault(x => x.Key.Equals(e));
                if (child == null)
                {
                    child = new PatriciaTrieNode(e, node);
                    node.Childs.Add(child); 
                }
                node = child;
            }

            node.Childs.Add(new PatriciaTrieNode('$', node, value));
        }
    }
}
