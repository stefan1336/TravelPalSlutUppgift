using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Travels
{
    public class Vacation : Travel
    {


        public bool AllInclusive { get; set; }
        

        public Vacation(string destination, Countries countrys, int travelers, bool allInclusive) : base(destination, countrys, travelers)
        {
            // Lägga till allinclusive
            AllInclusive = allInclusive;
            
           
        }



        public override string GetInfo()
        {
            // sträng
            return $"{base.Countrys}";
        }

        public override string GetTravelType()
        {
            return "Vacation";
        }
    }
}
