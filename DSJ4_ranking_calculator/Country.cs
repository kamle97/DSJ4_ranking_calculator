using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSJ4_ranking_calculator
{
    class Country
    {
        public string CountryName { get; }
        public string ShortName { get; }
        public int Points { get; set; }

        public Country(string countryName, string shortName)
        {
            CountryName = countryName;
            ShortName = shortName;
            Points = 0;
        }

        public override string ToString()
        {
            return CountryName + " " + ShortName + " " + Points;
        }
    }
}
