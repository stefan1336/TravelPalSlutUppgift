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
        private User user;
        
        public RegisterWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
           
            string[] getAllCountries = Enum.GetNames(typeof(Countries));

            cbCountry.ItemsSource=getAllCountries;

            this.userManager = userManager;
            this.travelManager = travelManager;
        }

        // En knapp för att registrera användaren
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = pswPassWord.Password;

                string confirmPassword = pswConfirmPassword.Password;

                if (this.userManager.UpdateUsername(user, username) && this.userManager.ConfirmPassword(password, confirmPassword))
                {                   
                    string country = cbCountry.SelectedItem as string;
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                    if (this.userManager.AddUser(username, password, selectedCountry))
                    {
                        MainWindow mainwindow = new(userManager, travelManager);
                        mainwindow.Show();
                        Close();
                    }
                }

            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("You need to make a full registration");
            }



        }
    }
}
