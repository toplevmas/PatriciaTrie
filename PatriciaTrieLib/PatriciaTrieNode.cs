using System.Collections.Generic;

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

        public void Add(string key, int value)
        {
            InsertKey(key, value);
            /*PatriciaTrieNode child;
            if (Childs.TryGetValue(key[0], out child))
            {
                InsertKey(key, value);
            }
            else
            {
                Childs.Add(key[0], new PatriciaTrieNode(key, value));
            }*/
        }

        private void InsertKey(string key, int value)
        {
            var i = 0;
            while (i < key.Length && i < Key.Length && Key[i] == key[i])
                i++;

            if (i < Key.Length)
            {
                if (key.Length < Key.Length)
                {
                    var oldChilds = new Dictionary<char, PatriciaTrieNode>(Childs);

                    Childs.Clear();
                    Childs.Add(Key[i], new PatriciaTrieNode(Key.Substring(i), childs: oldChilds));
                    Key = key.Substring(0, i);
                }
                else
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
            else
            {
                if (i == key.Length)
                {
                    Value = value;
                }
                else
                {
                    PatriciaTrieNode child;
                    if (Childs.TryGetValue(key[i], out child))
                    {
                        child.Add(key.Substring(i), value);
                    }
                    else
                    {
                        Childs.Add(key[i], new PatriciaTrieNode(key.Substring(i), value));
                    }
                }
            }
        }
    }
}
