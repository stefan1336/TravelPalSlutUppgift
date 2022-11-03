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
            // overridar från travel och skickar tillbaka valt land vilket är det enda som pritas ut i listviewn
            return $"{base.Countrys}";
        }

        public override string GetTravelType()
        {
            // overridar från travel och  retunerar trip om man valt det när man lägger till en ny resa
            return "Vacation";
        }
    }
}
