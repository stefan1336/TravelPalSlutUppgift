using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift.Managers
{
    public class User : IUser
    {
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
        public Countries Locations { get ; set ; }

        // Lägg till travel
        List<Travel> travel = new();
    }
}
