using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Managers
{
    
    public class UserManager
    {
        // Gjort en user lista att lägga till användare och admin i
        private List<IUser> users = new();
        public IUser SignedInUser { get; set; }


        // Skapat en Admin och lagt till användarnamn och lösen för den
        public UserManager()
        {
            User user = new("Gandalf", "password", Enums.Countries.Sweden);

            users.Add(user);
        }

        // Skapat en metod för att hämta alla användare
        public List<IUser> GetAllUsers()
        {
            return users;
        }

        // En metod för att lägga till användare
        public bool AddUser(string username, string password, Countries country)
        {
            if(ValidateUsername(username))
            {
                User user = new(username, password, country);

                users.Add((user));

                return true;
            }

            return false;
        }

        public bool ConfirmPassword(string password, string confirmPassword)
        {
            if(password == confirmPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateUsername(string username)
        {
            // Kolla om usernamet är upptaget eller inte
            foreach(IUser user in users)
            {
                if(user.UserName == username)
                {
                    
                    return false;
                    
                }

                
            }
            return true;
            // Om inte upptaget - returnera true
            // Om upptaget - returnera false
        }

        public void RemoveUser()
        {
            // Metod för admin att ta bort user
        }

        public bool UpdateUsername()
        {
            // uppdatera användarnamn

            return false;
        }



        public bool signInUser(string username, string password)
        {
            // Logga in användaren

            foreach (IUser user in users)
            {
                if (user.UserName == username && user.Password == password)
                {
                    SignedInUser = user;
                    return true;             
                }
            }

            return false;
        }

        
    }
}
