using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PatriciaTrieLib
{
    public class PatriciaTrie
    {
        public PatriciaTrie()
        {
            _startSymbolCode = (byte) 'a';
            _lastSymbolCode = (byte) 'e';
            _alphabet = (byte) (_lastSymbolCode - _startSymbolCode + 2);
            Root = new PatriciaTrieNode('\0', _alphabet);
        }

        private readonly byte _startSymbolCode;
        private readonly byte _lastSymbolCode;
        private readonly byte _alphabet;

        public PatriciaTrieNode Root { get; }

        public bool Find(string key)
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
        }

        public void Insert(string key)
        {
            if (!Regex.IsMatch(key, @"^[abcde]+$"))
                throw new ArgumentException("Key contains not allowed symbols");

            var node = Root;

            foreach (var e in key)
            {
                if (node.Childs[e - _startSymbolCode] == null)
                    node.Childs[e - _startSymbolCode] = new PatriciaTrieNode(e, _alphabet, node);
                node = node.Childs[e - _startSymbolCode];
            }

            node.Childs[_lastSymbolCode - _startSymbolCode + 1] = new PatriciaTrieNode('$', _alphabet, node);
        }
    }
}
