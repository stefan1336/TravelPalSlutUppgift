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
            // sträng
            return $"{base.Countrys} ";
        }

        public override string GetTravelType()
        {
            return "Trip";
        }
    }
}
