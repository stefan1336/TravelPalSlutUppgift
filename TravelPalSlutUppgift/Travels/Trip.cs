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

        public Trip()
        {
            // Type of trip
        }

        public void GetInfo()
        {
            // Get info string
        }
    }
}
