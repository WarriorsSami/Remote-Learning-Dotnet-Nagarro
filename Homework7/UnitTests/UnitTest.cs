using System;
using System.Collections.Generic;
using Custom_Hash_Table.HashTableAPI;
using NUnit.Framework;

namespace UnitTests
{
    public class HashTableTests
    {
        private IHashTable<StubClass, string> _hashTable;
        private static IEnumerable<Tuple<StubClass, string>> Data 
        {
            get
            {
                return new Tuple<StubClass, string>[]
                {
                    new(new StubClass("Stub 1", 1, true), "1"),
                    new(new StubClass("Stub 2", 2, false), "2"),
                    new(new StubClass("Stub 3", 3, true), "3"),
                    new(new StubClass("Stub 4", 4, false), "4"),
                };
            }
        }

        [SetUp]
        public void Setup()
        {
            _hashTable = new SmHashTable<StubClass, string>(Data);
        }
        
        [Test]
        public void TestConstructor_WhenInputListIsNotNull()
        {
            foreach (var (key, _) in Data)
            {
                Assert.IsTrue(_hashTable.ContainsKey(key));
            }
        }
        
        [Test]
        public void TestConstructor_WhenInputListIsNull()
        {
            IEnumerable<Tuple<StubClass, string>> inputList = null;

            Assert.Throws<ArgumentNullException>(
                () => _hashTable = new SmHashTable<StubClass, string>(inputList));
        }
        
        [Test]
        public void TestContainsKey_WhenKeyIsNotInHashTable()
        {
            var key = new StubClass("Stub 5", 5, true);
            Assert.IsFalse(_hashTable.ContainsKey(key));
        }
        
        [Test]
        public void TestContainsKey_WhenKeyIsInHashTable()
        {
            var key = new StubClass("Stub 1", 1, true);
            Assert.IsTrue(_hashTable.ContainsKey(key));
        }
        
        [Test]
        public void TestGetValue_WhenKeyIsNotInHashTable()
        {
            var key = new StubClass("Stub 5", 5, true);
            Assert.Throws<KeyNotFoundException>(
                () => _hashTable.Get(key));
        }
        
        [Test]
        public void TestGetValue_WhenKeyIsInHashTable()
        {
            var key = new StubClass("Stub 1", 1, true);
            Assert.AreEqual("1", _hashTable.Get(key));
        }
        
        [Test]
        public void TestPut_WhenKeyIsNotInHashTable()
        {
            var key = new StubClass("Stub 5", 5, true);
            var value = "5";
            Assert.IsTrue(_hashTable.Put(key, value));
            Assert.AreEqual(value, _hashTable.Get(key));
        }
        
        [Test]
        public void TestPut_WhenKeyIsInHashTable()
        {
            var key = new StubClass("Stub 1", 1, true);
            var value = "1";
            Assert.IsFalse(_hashTable.Put(key, value));
            Assert.AreEqual(value, _hashTable.Get(key));
        }
        
        [Test]
        public void TestRemove_WhenKeyIsNotInHashTable()
        {
            var key = new StubClass("Stub 5", 5, true);
            Assert.IsFalse(_hashTable.Remove(key));
        }
        
        [Test]
        public void TestRemove_WhenKeyIsInHashTable()
        {
            var key = new StubClass("Stub 1", 1, true);
            Assert.IsTrue(_hashTable.Remove(key));
            Assert.IsFalse(_hashTable.ContainsKey(key));
        }
        
        [Test]
        public void TestCount_WhenHashTableIsEmpty()
        {
            var hashTable = new SmHashTable<StubClass, string>();
            Assert.AreEqual(0, hashTable.Count());
        }
        
        [Test]
        public void TestCount_WhenHashTableIsNotEmpty()
        {
            Assert.AreEqual(
                new List<Tuple<StubClass, string>>(Data).Count, 
                _hashTable.Count());
        }
    }
}