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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPalSlutUppgift.Managers;
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        private TravelManager travelManager;
        public MainWindow()
        {
            InitializeComponent();

            this.userManager = new();
            this.travelManager = new();

            foreach (IUser user in userManager.GetAllUsers())
            {
                if (user is User)
                {
                    User appUser = user as User;

                    travelManager.travels.AddRange(appUser.Travels);
                }
            }
        }
        
        public MainWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.userManager = userManager;
            this.travelManager = travelManager;
        }

        // En knapp för att registrera användaren
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Registrera användare
            RegisterWindow registerWindow = new(userManager, travelManager);

            registerWindow.Show();

            Close();
        }

        // En knapp för att logga in
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Logga in användare
            List<IUser> users = userManager.GetAllUsers();

            string username = txtUserName.Text;
            string password = pswPassword.Password;

            if(userManager.SignInUser(username, password))
            {
                TravelsWindow travelsWindow = new(userManager, travelManager);

                Close();
                travelsWindow.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }
        }
    }
}
