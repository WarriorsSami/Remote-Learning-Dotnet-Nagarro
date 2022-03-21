namespace UnitTests
{
    public class StubClass
    {
        public string Field1 { get; set; }
        public int Field2 { get; set; }
        public bool Field3 { get; set; }
        
        public StubClass(string field1, int field2, bool field3)
        {
            Field1 = field1;
            Field2 = field2;
            Field3 = field3;
        }

        public override int GetHashCode()
        {
            return Field1.GetHashCode() ^ Field2.GetHashCode() ^ Field3.GetHashCode();
        }
    }
}