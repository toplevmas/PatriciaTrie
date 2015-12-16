using System.Linq;
using System.Text;

namespace PatriciaTrieLib
{
    public class PatriciaTrie
    {
        public PatriciaTrie()
        {
            Root = new PatriciaTrieNode("");
        }

        public PatriciaTrieNode Root { get; }

        public bool Lookup(string key)
        {
            return Root.Find(key);
        }

        public void Insert(string key, int value)
        {
            if (Root.Childs.Count == 0)
                Root.Childs.Add(key[0], new PatriciaTrieNode(key, value));
            else
                Root.Add(key, value);
        }

        public bool Delete(string key)
        {
            return Root.Delete(key);
        }

        public override string ToString()
        {
            return Walk(Root);
        }

        public static string Walk(PatriciaTrieNode node)
        {
            if (node == null)
                return string.Empty;

            var result = new StringBuilder();

            result.Append($"['{node.Key}' ({string.Join(" ", node.Childs.Select(x => x.Key))})");
            if (node.Value.HasValue)
                result.Append($" {node.Value}");
            result.Append("] ");

            foreach (var child in node.Childs)
                result.Append(Walk(child.Value));

            return result.ToString();
        }
    }
}
