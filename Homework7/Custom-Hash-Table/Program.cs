using System;
using System.Collections.Generic;
using Custom_Hash_Table.HashTableAPI;

var map = new SmHashTable<string, int>();

map.Put("a", 1);
map.Put("b", 2);
map.Put("c", 3);
map.Put(null, 4);

Console.WriteLine(map.Get("a"));
Console.WriteLine(map.Count());

map.Remove("a");

Console.WriteLine(map.ContainsKey("a"));
Console.WriteLine(map.Get("b"));
Console.WriteLine(map.Count());

var newMap = new SmHashTable<TestClass, bool>();

newMap.Put(new TestClass(1, 2), true);
newMap.Put(new TestClass(2, 3), false);

// Console.WriteLine(newMap.Get(new TestClass(1, 2)));

Console.WriteLine($"\n{new TestClass(1, 2).GetHashCode()} {new TestClass(1, 2).GetHashCode()}");

var dict = new Dictionary<int, bool>();

internal class TestClass
{
    public int Field1 { get; set; }
    public int Field2 { get; set; }
    
    public TestClass(int field1, int field2)
    {
        Field1 = field1;
        Field2 = field2;
    }
}