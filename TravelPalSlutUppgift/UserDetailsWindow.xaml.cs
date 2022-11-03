using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPalSlutUppgift.Enums;
using TravelPalSlutUppgift.Managers;
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;


        //private IUser iuser;
        private User user;

        private Admin admin;

        private Countries countries;
        public UserDetailsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            if (userManager.SignedInUser is User)
            {
                this.user = userManager.SignedInUser as User;

            }
            else if (userManager.SignedInUser is Admin)
            {
                this.admin = userManager.SignedInUser as Admin;
            }

            
            this.userManager = userManager;
            this.travelManager = travelManager;

            string[] getCountries = Enum.GetNames(typeof(Countries));

            cbCountry.ItemsSource = getCountries;

            UpdateUi();

           
        }

        // Spara uppdaterad användaruppgifter
        // Registrera användare
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                // Skapa nya användaruppgifter
                string newUsername = txtUserName.Text;
                string newPassword = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                // Hämtar mina metoder för att uppdatera användarnamnet och lösenordet
                if (this.userManager.UpdateUsername(user,newUsername) && this.userManager.UpdatePassword(user, newPassword, confirmPassword))
                {
                    
                    string newLocation = cbCountry.Text;
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), newLocation);
                    userManager.SignedInUser.Locations = selectedCountry;

                    userManager.SignedInUser.UserName = newUsername;
                    userManager.SignedInUser.Password = newPassword;
                    userManager.SignedInUser.ConfirmPassword = confirmPassword;

                    TravelsWindow travelsWindow = new(userManager, travelManager);
                    travelsWindow.Show();
                    Close();

                }
                
            }

            catch (ArgumentException)
            {
                MessageBox.Show("You need to make a full registration of a updated userinfo");
            }

        }

        // Återgå till tidigare fönster
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // återgå till transferwindow
            TravelsWindow travelsWindow = new(userManager, travelManager);
            travelsWindow.Show();
            Close();

        }

        // Uppdaterar ui och skriver ut användarnamn samt landet
        private void UpdateUi()
        {

            lbUserInfo.Content = $"{user.UserName} {user.Locations}";

        }
    }
}
