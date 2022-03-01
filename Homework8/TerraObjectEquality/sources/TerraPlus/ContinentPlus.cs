using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.Terra;

namespace iQuest.TerraPlus
{
    public class ContinentPlus
    {
        private readonly List<Country> countries = new List<Country>();

        public ContinentPlus()
        {
        }

        public ContinentPlus(IEnumerable<Country> countries)
        {
            if (countries == null) throw new ArgumentNullException(nameof(countries));

            this.countries.AddRange(countries);
        }

        public IEnumerable<Country> EnumerateCountriesByName()
        {
            countries.Sort();
            return countries;
        }

        public IEnumerable<Country> EnumerateCountriesByCapital()
        {
            return countries.OrderBy(country => country, new CountryByCapitalComparer());
        }
    }

    public class CountryByCapitalComparer : IComparer<Country>
    {
        public int Compare(Country x, Country y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return string.Compare(x.Capital, y.Capital, StringComparison.Ordinal);
        }
    }
}