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
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        // skicka med användaren till resefönstret


        private User user = new();
        private Admin admin;

        public TravelsWindow(UserManager userManager, IUser user)
        {
            InitializeComponent();

            if(user is User)
            {
                this.user = user as User;
            }
            else if (user is Admin)
            {
                this.admin = user as Admin;
            }

            UppdateUi();

        }

        private void UppdateUi()
        {
            // Uppdatera Ui
        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            // Öppna user window
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            // Poppa upp en liten ruta med info om företaget
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // Logga ut, återgå till mainwindow
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            // öppna fönstret travel details om en specifik resa i listviewn
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Ta bort en markerad resa från listviewn
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Öppna upp fönstret Add för att lägga till resor till listwiev
        }
    }
}
