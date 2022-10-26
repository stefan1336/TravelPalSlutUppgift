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

            this.userManager = new();
        }
        
        public MainWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Registrera användare
            RegisterWindow registerWindow = new(userManager);

            registerWindow.Show();

            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Logga in användare
            List<IUser> users = userManager.GetAllUsers();

            string username = txtUserName.Text;
            string password = pswPassword.Password;

            if(userManager.signInUser(username, password))
            {
                TravelsWindow travelsWindow = new(userManager);

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
