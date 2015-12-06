using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatriciaTrieLib;

namespace UnitTests
{
    [TestClass]
    public class PatriciaTrie_Tests
    {
        private PatriciaTrie _patriciaTrie;

        [TestInitialize]
        public void TestInitialize()
        {
            _patriciaTrie = new PatriciaTrie();
        }

        [TestMethod]
        public void PatriciaTrie_Insert_Successful()
        {
            _patriciaTrie.Insert("aaabbb", 1);
            _patriciaTrie.Insert("aaaccd", 2);
            _patriciaTrie.Insert("aaacce", 3);

            Assert.AreEqual("['' (a)] ['aaa' (b c)] ['bbb' () 1] ['cc' (d e)] ['d' () 2] ['e' () 3] ", _patriciaTrie.ToString());
        }

        [TestMethod]
        public void PatriciaTrie_Insert2_Successful()
        {
            _patriciaTrie.Insert("aaa", 1);
            _patriciaTrie.Insert("aaabbb", 1);
            _patriciaTrie.Insert("aaaccd", 2);
            _patriciaTrie.Insert("aaacce", 3);

            Assert.AreEqual("['' (a)] ['aaa' (b c) 1] ['bbb' () 1] ['cc' (d e)] ['d' () 2] ['e' () 3] ", _patriciaTrie.ToString());
        }
        
        [TestMethod]
        public void PatriciaTrie_Find_Successful()
        {
            _patriciaTrie.Insert("aaa", 1);
            _patriciaTrie.Insert("aaabbb", 1);
            _patriciaTrie.Insert("aaaccd", 2);
            _patriciaTrie.Insert("aaacce", 3);

            Assert.IsTrue(_patriciaTrie.Lookup("aaa"));
            Assert.IsTrue(_patriciaTrie.Lookup("aaabbb"));
            Assert.IsTrue(_patriciaTrie.Lookup("aaaccd"));
            Assert.IsTrue(_patriciaTrie.Lookup("aaacce"));

            Assert.IsFalse(_patriciaTrie.Lookup("a"));
            Assert.IsFalse(_patriciaTrie.Lookup(""));
            Assert.IsFalse(_patriciaTrie.Lookup("aaab"));
            Assert.IsFalse(_patriciaTrie.Lookup("aaaccde"));
        }
    }
}
