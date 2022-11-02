using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPalSlutUppgift.Enums;
using TravelPalSlutUppgift.Travels;

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

            Vacation vacation1 = new("Varberg", Enums.Countries.Algeria, 2, true);
            user.Travels.Add(vacation1);
            Trip vacation2 = new("Leksand", Enums.Countries.Qatar, 1, Enums.TripTypes.Leisure);
            user.Travels.Add(vacation2);

            Admin admin = new("admin", "password", Enums.Countries.Sweden);

            users.Add(user);
            users.Add(admin);
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

        public bool UpdatePassword(IUser user, string password, string confirmPassword)
        {
            if (password.Length < 5)
            {
                MessageBox.Show("Your password is to short");
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("You need to enter a password");
                return false;
            }
            else if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("You forgot to confirm your password");
                return false;
            }

            else if(ConfirmPassword(password, confirmPassword)== false)
            {
                return false;
            }

            return true;
        }
        public bool ConfirmPassword(string password, string confirmPassword)
        {

                if (password == confirmPassword)
                {
                    return true;
                }
                else if (password == null )
                {
                    MessageBox.Show("You need to enter a password");
                    return false;
                }
                else if(confirmPassword == null)
                {
                    MessageBox.Show("You need to confirm your password");
                }
                return false;
                
      
        }

        private bool ValidateUsername(string username)
        {
            // Kolla om usernamet är upptaget eller inte
            foreach(IUser user in users)
            {
                if(user.UserName == username)
                {
                    MessageBox.Show("Username is already taken");
                    return false;
                    
                }
               
            }
            return true;
            // Om inte upptaget - returnera true
            // Om upptaget - returnera false
        }
     
        public bool UpdateUsername(IUser user, string username)
        {

            // uppdatera användarinformation
            // är användarnamnet för kort får man ett varningsmedelande
           
            if(username.Length <3)
            {
                MessageBox.Show("Your username is to short ");
                return false;
            }
            else if(username == null)
            {
                MessageBox.Show("You need to enter a new username");
                return false;
            }
            else if(ValidateUsername(username)== false)
            {
                // om användarnamnet redan finns
                return false;
            }

            return true;
            
        }

        public bool SignInUser(string username, string password)
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
