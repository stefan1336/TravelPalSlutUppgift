using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Travels
{
    public class TravelManager
    {
        public List<Travel> travels = new();

        public Travel AddTravel(Travel travel)
        {
            // Lägga till resa
            travels.Add(travel);

            return travel;
        }

        public Travel CreateTravel(string destination, Countries countries, int travelers, TripTypes tripType)
        {
            // en metod för att lägga till en trip
            Trip trip = new(destination, countries, travelers, tripType);
            return AddTravel(trip);
        }

        public Travel CreateTravel(string destination, Countries countries, int travelers, bool allInclusive)
        {
            // en metod för att lägga till en vacation
            Vacation vacation = new(destination, countries, travelers, allInclusive);
            return AddTravel(vacation);
        }

              
       
        // Ta bort en resa ( använder en annan travel metod)
        public void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);

            if(travel is Vacation)
            {
                Vacation vacation = travel as Vacation;
                {
                    travels.Remove(vacation);
                }
                
            }
            else if (travel is Trip)
            {
                Trip trip = travel as Trip;
                {
                    travels.Remove(trip);
                }
                
            }
            
        }
    }
}
