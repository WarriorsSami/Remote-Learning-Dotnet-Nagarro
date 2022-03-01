using System;
using System.Collections.Generic;
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
            countries.Sort(CountryComparisonExtension.CompareByCapital);
            return countries;
        }
    }

    public static class CountryComparisonExtension
    {
        public static int CompareByCapital(this Country country1, Country country2)
        {
            if (country1 == null)
            {
                return country2 == null ? 0 : -1;
            }
            
            return country2 == null 
                ? 1 
                : string.Compare(country1.Capital, country2.Capital, StringComparison.Ordinal);
        }
    }
}