using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPalSlutUppgift.Enums;
using TravelPalSlutUppgift.Managers;
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        
        public RegisterWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            // Lägga till mina enum i comboboxen i register
            string[] getAllCountries = Enum.GetNames(typeof(Countries));

            cbCountry.ItemsSource=getAllCountries;

            this.userManager = userManager;
            this.travelManager = travelManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            // Registrera användare
            string username = txtUserName.Text;
            string password = pswPassWord.Password;
            string country = cbCountry.SelectedItem as string;
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);
            // Få confirm password att funka?
            string confirmPassword = pswConfirmPassword.Password;

            

            // skapa en if sats om användarnamet redan finns
            

            if(this.userManager.ConfirmPassword(password, confirmPassword))
            {
                // Lyckats adda en user
                if (this.userManager.AddUser(username, password, selectedCountry))
                {
                    
                    // Återgå till mainwindow

                    MainWindow mainwindow = new(userManager, travelManager);
                    mainwindow.Show();
                    Close();

                }
                else
                {
                    MessageBox.Show("Username is invalid or upptaget", "Warning!");
                }
            }
            else
            {
                MessageBox.Show("Passwords don't match!", "Warning!");
            }
           
        }
    }
}
