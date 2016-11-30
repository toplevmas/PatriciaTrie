using System.Collections.Generic;
using System.Linq;

namespace PatriciaTrieLib
{
    public class PatriciaTrieNode
    {
        public PatriciaTrieNode(string key, int? value = null, Dictionary<char, PatriciaTrieNode> childs = null)
        {
            Key = key;
            Value = value;
            Childs = childs ?? new Dictionary<char, PatriciaTrieNode>();
        }

        public Dictionary<char, PatriciaTrieNode> Childs { get; set; }

        public string Key { get; private set; }

        public int? Value { get; private set; }

        public bool Find(string key)
        {
            if (!key.StartsWith(Key))
                return false;

            if (key.Length == Key.Length)
                return Value.HasValue;

            PatriciaTrieNode child;
            if (Childs.TryGetValue(key[Key.Length], out child))
            {
                return child.Find(key.Substring(Key.Length));
            }
            return false;
        }

        public void Add(string key, int value)
        {
            var i = 0;
            while (i < key.Length && i < Key.Length && Key[i] == key[i])
                i++;

            if (i == key.Length && i == Key.Length)//完全相等，更新value
            {
                Value = value;
            }
            else if (i == key.Length)//Key包含key
            {
                var oldChilds = new Dictionary<char, PatriciaTrieNode>(Childs);

                Childs.Clear();
                Childs.Add(Key[i], new PatriciaTrieNode(Key.Substring(i), Value, oldChilds));
                Key = key.Substring(0, i);
                Value = value;
            }
            else if (i == Key.Length)//key被包含Key
            {
                PatriciaTrieNode child;
                if (Childs.TryGetValue(key[i], out child))//检查childs如果已经
                {
                    child.Add(key.Substring(i), value);
                }
                else
                {
                    Childs.Add(key[i], new PatriciaTrieNode(key.Substring(i), value));
                }
            }
            else//因为字符不等
            {
                PatriciaTrieNode child;
                if (Childs.TryGetValue(key[i], out child))
                {
                    child.Add(key.Substring(i), value);
                }
                else
                {
                    var oldChilds = new Dictionary<char, PatriciaTrieNode>(Childs);

                    Childs.Clear();
                    Childs.Add(Key[i], new PatriciaTrieNode(Key.Substring(i), Value, oldChilds));
                    Childs.Add(key[i], new PatriciaTrieNode(key.Substring(i), value));

                    Key = Key.Substring(0, i);
                    Value = null;
                }
            }
        }

        public bool Delete(string key)
        {
            PatriciaTrieNode child;

            if (!Childs.TryGetValue(key[Key.Length], out child))
                return false;

            key = key.Substring(Key.Length);

            if (!key.StartsWith(child.Key))
                return false;

            if (key.Length != child.Key.Length)
                return child.Delete(key);

            if (!child.Value.HasValue)
                return false;

            if (child.Childs.Count > 1)
                child.Value = null;
            else if (child.Childs.Count == 0)
                Childs.Remove(key[0]);
            else if (child.Childs.Count == 1)
            {
                var k = child.Childs.First().Key;
                child.Childs[k].Key = child.Key + child.Childs[k].Key;
                Childs.Clear();
                Childs.Add(child.Key[0], child.Childs[k]);
            }

            return true;
        }
    }
}
