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
            // TODO: skapa antingen trip eller vacation, inte ren travel
            travels.Add(travel);

            return travel;
        }

        public Travel CreateTravel(string destination, Countries countries, int travelers, TripTypes tripType)
        {
            Trip trip = new(destination, countries, travelers, tripType);
            return AddTravel(trip);
        }

        public Travel CreateTravel(string destination, Countries countries, int travelers, bool allInclusive)
        {
            Vacation vacation = new(destination, countries, travelers, allInclusive);
            return AddTravel(vacation);
        }

              
        
        public void AddToList(Travel travel)
        {
            // lägga till resor
            travels.Add(travel);
            
        }

        // Ta bort en resa
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
