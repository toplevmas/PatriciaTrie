using System.Linq;

namespace PatriciaTrieLib
{
    public class PatriciaTrie
    {
        public PatriciaTrie()
        {
            Root = new PatriciaTrieNode('');
        }

        public PatriciaTrieNode Root { get; private set; }

        public PatriciaTrieNode Find(string key)
        {
            var node = Root;

            foreach (var e in key)
            {
                var child = node.Childs.FirstOrDefault(x => x.Key.Equals(e));
                if (child == null)
                    return null;
                node = child;
            }

            return node;
        }

        public void Insert(string key, int value)
        {
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
