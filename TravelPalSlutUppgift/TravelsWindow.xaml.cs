using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        // skicka med användaren till resefönstret

        List<Travel> travels = new();
        private UserManager userManager;

        TravelManager travelManager;

        private User user;
        private Admin admin;

        public TravelsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.travelManager = new();
            this.userManager = userManager;

            InitializeUserSettings();

            UppdateUi();

         
        }

        public TravelsWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            this.travelManager = travelManager;
            this.userManager = userManager;

            InitializeUserSettings();

            UppdateUi();
        }

        private void InitializeUserSettings()
        {
            if (this.userManager.SignedInUser is User)
            {
                this.user = userManager.SignedInUser as User;

            }
            else if (this.userManager.SignedInUser is Admin)
            {
                this.admin = userManager.SignedInUser as Admin;
            }
        }

        private void UppdateUi()
        {
            // Uppdatera Ui
            lbUserName.Content = this.user.UserName;
            //txtUserName.Text = this.user.UserName;

            //foreach (Travel travel in travels)
            //{
            //    ListViewItem listViewItem = new();

            //    listViewItem.Content = travel.GetInfo();
            //    listViewItem.Tag = travel;

            //    lwTravelInfo.Items.Add(listViewItem);
            //}

            if (this.userManager.SignedInUser is User)
            {
                User signedInUser = this.userManager.SignedInUser as User;  

                if(signedInUser.Travels.Count > 0)
                {
                    foreach (var travel in signedInUser.Travels)
                    {
                        ListViewItem item = new();
                        item.Content = travel.GetInfo();
                        item.Tag = travel;

                        lwTravelInfo.Items.Add(item);
                    }
                }
            }
        }

        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            // Öppna user window
            
            UserDetailsWindow userDetailsWindow = new(userManager);
            userDetailsWindow.Show();
            //Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            // Poppa upp en liten ruta med info om företaget
            MessageBox.Show("This is a company started by Albin Karlsson for his students to show their skills in oop");
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // Logga ut, återgå till mainwindow
            MainWindow mainwindow = new(userManager, travelManager);
            mainwindow.Show();
            Close();

        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            // öppna fönstret travel details om en specifik resa i listviewn
            // Om inget är markerat i listview ska ett varningsmedelande visas

            ListViewItem selectedItem = lwTravelInfo.SelectedItem as ListViewItem;
            


            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager, selectedTravel);
                travelDetailsWindow.Show();
                
                 
            }
            else
            {
                MessageBox.Show("You need to pick a travel");

            }

            //Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedListViewItem = lwTravelInfo.SelectedItem as ListViewItem;

            if(selectedListViewItem != null)
            {
                // Ta bort 
            }
            else
            {
                MessageBox.Show("You need to pick a travel");
            }
            // Ta bort en markerad resa från listviewn
            // Om inget är markerat i listview ska ett varningsmedelande visas
            
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Öppna upp fönstret Add för att lägga till resor till listwiev
            AddTravelsWindow addTravelsWindow = new(travelManager, userManager);
            addTravelsWindow.Show();
            Close();

        }
    }
}
