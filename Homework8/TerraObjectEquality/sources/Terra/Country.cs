using System;

namespace iQuest.Terra
{
    public class Country: IEquatable<Country>
    {
        public string Name { get; }

        public string Capital { get; }

        public Country(string name, string capital)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Capital = capital ?? throw new ArgumentNullException(nameof(capital));
        }

        public bool Equals(Country other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Capital == other.Capital;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Country) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Capital);
        }
    }
}