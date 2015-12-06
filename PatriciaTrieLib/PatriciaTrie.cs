using System.Collections.Generic;
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

        /*public bool Find(string key)
        {
            if (!Regex.IsMatch(key, @"^[abcde]+$"))
                throw new ArgumentException("Key contains not allowed symbols");

            var node = Root;

            foreach (var e in key)
            {
                if (node.Childs[e - _startSymbolCode] != null)
                    node = node.Childs[e - _startSymbolCode];
                else
                    return false;
            }

            return node.Childs[_lastSymbolCode - _startSymbolCode + 1] != null;
        }*/

        public void Insert(string key, int value)
        {
            if (Root.Childs.Count == 0)
                Root.Childs.Add(key[0], new PatriciaTrieNode(key, value));
            else
                Root.Add(key, value);
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

            result.Append($"['{node.Key}' (");
            foreach (var child in node.Childs.Select(x => x.Key))
                result.Append(child);
            result.Append(")");
            if (node.Value.HasValue)
                result.Append($" {node.Value}");
            result.Append("] ");

            foreach (var child in node.Childs)
            {
                result.Append(Walk(child.Value));
            }
            return result.ToString();
        }
    }
}
