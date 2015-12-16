﻿using System.Collections.Generic;

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

            if (child.Childs.Count > 0)
                child.Value = null;
            else
                Childs.Remove(key[0]);

            return true;
        }
    }
}
