using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Custom_Hash_Table.HashTableAPI
{
    internal interface IHashTable<in TKey, TValue>
    {
        TValue? Get(TKey key);
        bool Put(TKey key, TValue value);
        bool Remove(TKey key);
        bool ContainsKey(TKey key);
        int Count();
    }
}