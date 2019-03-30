using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSJ4_ranking_calculator
{
    class Hill
    {
        public City Name { get; set; }
        public int HS { get; set; }

        public Hill(string name, int size)
        {
            Name = chooseCity(name);
            HS = size;
        }

        public City chooseCity(string name)
        {
            switch (name)
            {
                case "BadMitterndorf": return City.Kulm;
                case "Bischofshofen": return City.Bischofshofen;
                case "Engelberg": return City.Engelberg;
                case "Garmisch-Partenkirchen": return City.GaPa;
                case "Harrachov": return City.Harrachov;
                case "Klingenthal": return City.Klingenthal;
                case "Kuopio": return City.Kuopio;
                case "Kuusamo": return City.Kuusamo;
                case "Lahti": return City.Lahti;
                case "Lillehammer": return City.Lillehammer;
                case "Oberstdorf": return City.Oberstdorf;
                case "ParkCity": return City.ParkCity;
                case "Planica": return City.Planica;
                case "Sapporo": return City.Sapporo;
                case "ValdiFiemme": return City.ValDiFiemme;
                case "Villach": return City.Villach;
                case "Willingen": return City.Willingen;
                case "Wisła": return City.Wisla;
                case "Zakopane": return City.Zakopane;
                default: throw new ArgumentException("Wrong hill!");
            }
        }
    }
}
