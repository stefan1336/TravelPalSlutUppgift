using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Managers
{
    public class Admin : IUser
    {
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
        public Countries Locations { get; set; }
        public string ConfirmPassword { get ; set ; }

        public Admin(string userName, string password, Countries locations)
        {
            UserName=userName;
            Password=password;
            Locations=locations;
        }
    }
}
