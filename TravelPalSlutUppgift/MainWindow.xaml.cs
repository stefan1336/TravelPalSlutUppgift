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

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Registrera användare
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Logga in användare
            List<IUser> users = userManager.GetAllUsers();

            string username = txtUserName.Text;
            string password = pswPassword.Password;

            bool isFoundUser = false;

            foreach(IUser user in users)
            {
                if(user.UserName == username && user.Password == password)
                {
                    isFoundUser = true;

                    if(user is User)
                    {
                        // Om en användare är user så skickas man till userwindow
                        TravelsWindow travelsWindow = new(userManager, user);

                        travelsWindow.Show();
                    }
                    else if(user is Admin)
                    {
                        // Koppla till travelswindow med möjlighet att ändra och ta bort saker
                    }
                }
            }

            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect");
            }
        }
    }
}
