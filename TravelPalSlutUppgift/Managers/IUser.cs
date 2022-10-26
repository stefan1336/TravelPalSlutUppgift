using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Managers
{
    public interface IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Countries Locations { get; set; }


        public IUser(string username, string password, Countries location)
        {

            this.UserName = username;
            this.Password = password;
            this.Locations = location;
        }

    }   

}
