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
            _patriciaTrie.Insert("barsuk", 1);
            _patriciaTrie.Insert("barin", 2);
            _patriciaTrie.Insert("bar", 3);

            Assert.AreEqual(1, _patriciaTrie.Root.Childs.Count);
            Assert.AreEqual(1, _patriciaTrie.Root.Childs[0].Childs.Count);
            Assert.AreEqual(1, _patriciaTrie.Root.Childs[0].Childs[0].Childs.Count);
            Assert.AreEqual(3, _patriciaTrie.Root.Childs[0].Childs[0].Childs[0].Childs.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PatriciaTrie_Insert_ArgumentException()
        {
            _patriciaTrie.Insert("$", 4);            
        }

        [TestMethod]
        public void PatriciaTrie_Find_Successful()
        {
            _patriciaTrie.Insert("barsuk", 1);
            _patriciaTrie.Insert("barin", 2);
            _patriciaTrie.Insert("bar", 3);

            Assert.AreEqual(1, _patriciaTrie.Find("barsuk"));
            Assert.AreEqual(2, _patriciaTrie.Find("barin"));
            Assert.AreEqual(3, _patriciaTrie.Find("bar"));
            Assert.AreEqual(null, _patriciaTrie.Find("a"));
            Assert.AreEqual(null, _patriciaTrie.Find("b"));
            Assert.AreEqual(null, _patriciaTrie.Find(""));
            Assert.AreEqual(null, _patriciaTrie.Find("$"));
        }
    }
}
