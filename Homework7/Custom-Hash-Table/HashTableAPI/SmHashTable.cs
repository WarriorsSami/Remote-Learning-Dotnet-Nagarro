using System;
using System.Collections;
using System.Collections.Generic;

namespace Custom_Hash_Table.HashTableAPI
{
    internal class SmHashTable<TKey, TValue>: 
        IHashTable<TKey, TValue>, IEnumerable<Tuple<int, TValue>>
    {
        private readonly List<Tuple<int, TValue>> _table = new();

        public SmHashTable(IEnumerable<Tuple<TKey, TValue>> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            
            foreach (var (key, value) in items)
            {
                Put(key, value);
            }
        }
        
        public SmHashTable()
        {
        }

        public TValue Get(TKey key)
        {
            var keyHash = key?.GetHashCode(); 
            foreach (var (currentHash, value) in _table) 
            { 
                if (currentHash == keyHash) 
                { 
                    return value;
                }
            }
            
            throw new KeyNotFoundException();
        }

        public bool Put(TKey key, TValue value)
        {
            var keyHash = key?.GetHashCode();
            foreach (var (currentHash, _) in _table)
            {
                if (currentHash == keyHash)
                {
                    return false;
                }
            }

            _table.Add(new Tuple<int, TValue>(keyHash ?? 0, value));
            return true;
        }

        public bool Remove(TKey key)
        {
            var keyHash = key?.GetHashCode();
            foreach (var (currentHash, value) in _table)
            {
                if (currentHash == keyHash)
                {
                    return _table
                        .Remove(new Tuple<int, TValue>((int) keyHash, value));
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            var keyHash = key?.GetHashCode();
            foreach (var (currentHash, _) in _table)
            {
                if (currentHash == keyHash)
                {
                    return true;
                }
            }

            return false;
        }

        public int Count()
        {
            return _table.Count;
        }

        public IEnumerator<Tuple<int, TValue>> GetEnumerator()
        {
            foreach (var item in _table)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}