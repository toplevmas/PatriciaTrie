using System;
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
            Assert.AreEqual("['':] ['aaa':] ['bbb':1] ['cc':] ['d':2] ['e':3]", _patriciaTrie.ToString());
        }

        [TestMethod]
        public void PatriciaTrie_Insert2_Successful()
        {
            _patriciaTrie.Insert("aaa", 1);
            _patriciaTrie.Insert("aaabbb", 1);
            _patriciaTrie.Insert("aaaccd", 2);
            _patriciaTrie.Insert("aaacce", 3);
            Assert.AreEqual("['':] ['aaa':] ['bbb':1] ['cc':] ['d':2] ['e':3]", _patriciaTrie.ToString());
        }

       /* [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PatriciaTrie_Insert_ArgumentException()
        {
            _patriciaTrie.Insert("qq");            
        }

        [TestMethod]
        public void PatriciaTrie_Find_Successful()
        {
            _patriciaTrie.Insert("a");
            _patriciaTrie.Insert("ab");
            _patriciaTrie.Insert("abc");
            _patriciaTrie.Insert("abd");
            _patriciaTrie.Insert("abe");
            _patriciaTrie.Insert("abec");

            Assert.IsTrue(_patriciaTrie.Find("a"));
            Assert.IsTrue(_patriciaTrie.Find("ab"));
            Assert.IsTrue(_patriciaTrie.Find("abc"));
            Assert.IsTrue(_patriciaTrie.Find("abd"));
            Assert.IsTrue(_patriciaTrie.Find("abe"));
            Assert.IsTrue(_patriciaTrie.Find("abec"));

            Assert.IsFalse(_patriciaTrie.Find("aa"));
            Assert.IsFalse(_patriciaTrie.Find("aba"));
        }*/
    }
}
