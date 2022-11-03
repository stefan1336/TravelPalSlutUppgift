using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Travels
{
    public class Trip : Travel
    {

        // typ av resa
        public TripTypes Type { get; set; }
        public Trip(string destination, Countries countrys, int travelers, TripTypes types) : base(destination, countrys, travelers)
        {

            Type = types;
        }


        public override string GetInfo()
        {
            // overridar från travel och  skickar tillbaka valt land vilket är det enda som pritas ut i listviewn
            return $"{base.Countrys} ";
        }

        public override string GetTravelType()
        {
            // overridar från travel och  retunerar trip om man valt det när man lägger till en ny resa
            return "Trip";
        }
    }
}
