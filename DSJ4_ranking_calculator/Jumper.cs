using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSJ4_ranking_calculator
{
    class Jumper
    {
        public string Name { get; }
        public string Surname { get; }
        public string Country { get; }

        public int WorldCup { get; set; }
        public double FourHills { get; set; }
        public double RawAir { get; set; }
        public double Willingen5 { get; set; }
        public double Planica7 { get; set; }
        public int FlyingCup { get; set; }
        public int NormalCup { get; set; }
        public double LongestDistance { get; set; }

        public Jumper(string name, string surname, string country)
        {
            Name = name;
            Surname = surname;
            Country = country;
            WorldCup = 0;
            FourHills = .0;
            RawAir = .0;
            Willingen5 = .0;
            Planica7 = .0;
            FlyingCup = 0;
            NormalCup = 0;
            LongestDistance = .0;
        }

        public override string ToString()
        {
            return Name + " " + Surname + " " + Country + " " + WorldCup;
        }
    }
}
