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
using TravelPalSlutUppgift.Managers;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;
        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Registrera användare
            string username = txtUserName.Text;
            string password = pswPassWord.Password;
            // Få confirm password att funka?
            string confirmPassword = pswConfirmPassword.Password;

            this.userManager.AddUser(username, password);
        }
    }
}
