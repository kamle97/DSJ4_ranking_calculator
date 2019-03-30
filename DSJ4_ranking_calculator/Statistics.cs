using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSJ4_ranking_calculator
{
    class Statistics
    {
        public StringBuilder WorldCup { get; set; }
        public StringBuilder FourHillsTournament { get; set; }
        public StringBuilder RawAir { get; set; }
        public StringBuilder Willingen5 { get; set; }
        public StringBuilder Planica7 { get; set; }
        public StringBuilder FlyingCup { get; set; }
        public StringBuilder NormalCup { get; set; }
        public StringBuilder TeamCup { get; set; }
        public StringBuilder LongestDistance { get; set; }

        public Statistics()
        {
            WorldCup = new StringBuilder();
            FourHillsTournament = new StringBuilder();
            RawAir = new StringBuilder();
            Willingen5 = new StringBuilder();
            Planica7 = new StringBuilder();
            FlyingCup = new StringBuilder();
            NormalCup = new StringBuilder();
            TeamCup = new StringBuilder();
            LongestDistance = new StringBuilder();
        }
    }
}
