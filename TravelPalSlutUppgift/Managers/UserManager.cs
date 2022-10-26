using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPalSlutUppgift.Managers
{
    
    public class UserManager
    {
        // Gjort en user lista att lägga till användare och admin i
        private List<IUser> users = new();


        // Skapat en Admin och lagt till användarnamn och lösen för den
        public UserManager()
        {
            Admin admin = new();

            admin.UserName = "Gandalf";
            admin.Password = "password";

            users.Add(admin);
        }

        // Skapat en metod för att hämta alla användare
        public List<IUser> GetAllUsers()
        {
            return users;
        }

        // En metod för att lägga till användare
        public void AddUser(string username, string password)
        {
            User user = new();

            user.UserName = username;
            user.Password = password;
            

            users.Add((user));
        }

        public void RemoveUser()
        {
            // Metod för admin att ta bort user
        }

        public bool UpdateUsername()
        {
            // uppdatera användarnamn
        }

        private bool validateUsername()
        {
            // bekräfta användarnamn

        }

        private bool signInUser()
        {
            // Är användaren inloggad
        }

        
    }
}
