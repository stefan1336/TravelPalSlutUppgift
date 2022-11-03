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

        // Uppdaterar ui beroende på om det är en user som loggat in eller en admin
        private void UppdateUi()
        {

            
            if (this.userManager.SignedInUser is User)

            {
                lbUserName.Content = this.user.UserName;
                // Inloggad som user
                User signedInUser = this.userManager.SignedInUser as User;  

                // Om antalet resor är större än 0
                if(signedInUser.Travels.Count > 0)
                {
                    lwTravelInfo.Items.Clear();
                    foreach (var travel in signedInUser.Travels)
                    {

                        ListViewItem item = new();
                        item.Content = travel.GetInfo();
                        item.Tag = travel;

                        lwTravelInfo.Items.Add(item);
                        
                    }
                }
            }
            
            else if(this.userManager.SignedInUser is Admin)

            {
                lbUserName.Content = this.admin.UserName;

                Admin signedInAdmin = this.userManager.SignedInUser as Admin;

                if(signedInAdmin is Admin)
                {

                    //lwTravelInfo.Items;
                    // Sätta en bool för admin/ user, så att admin kan ta bort och lägga till resor samt se alla resor medan en user inte kan det

                    // Om antalet resor är större än 0
                    if (travelManager.travels.Count > 0)
                    {
                        btnUserDetails.Visibility = Visibility.Hidden;
                        lwTravelInfo.Items.Clear();
                        foreach (var travel in travelManager.travels)
                        {

                            ListViewItem item = new();
                            item.Content = travel.GetInfo();
                            item.Tag = travel;

                            lwTravelInfo.Items.Add(item);

                        }
                    }
                }
            }
        }

        // En knapp för att öppna user details window
        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);
            userDetailsWindow.Show();
            Close();
        }

        // En knapp för historik om appen och funktion
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            // Poppa upp en liten ruta med info om företaget
            MessageBox.Show("This is a travelplaning app. You can add Travels to your list and if you want to remove a travel you can also do that. This is a company started by Albin Karlsson for his students to show their skills in oop");

        }

        // En knapp för att logga ut
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // Logga ut, återgå till mainwindow
            MainWindow mainwindow = new(userManager, travelManager);
            mainwindow.Show();
            Close();

        }

        // öppna fönstret travel details om en specifik resa i listviewn
        // Om inget är markerat i listview ska ett varningsmedelande visas
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

            ListViewItem selectedItem = lwTravelInfo.SelectedItem as ListViewItem;
            
            if (selectedItem != null)
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetailsWindow travelDetailsWindow = new(userManager, travelManager, selectedTravel);
                travelDetailsWindow.Show();
                Close();

            }
            else
            {
                MessageBox.Show("You need to pick a travel");
            }
           
        }

        // En knapp för att ta bort en resa 
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lwTravelInfo.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                // Ta bort resa från listView
                
                Travel selectedTravel = selectedItem.Tag as Travel;

                foreach (IUser user in userManager.GetAllUsers())
                {
                    if(user is User)
                    {
                        User appUser = user as User;
                        
                        if(appUser.Travels.Contains(selectedTravel))
                        {
                            appUser.Travels.Remove(selectedTravel);
                        }
                    }
                }

                travelManager.travels.Remove(selectedTravel);
            }
            else
            {
                MessageBox.Show("You need to pick a travel");
            }
            UppdateUi();
            // Ta bort en markerad resa från listviewn
            // Om inget är markerat i listview ska ett varningsmedelande visas

        }

        // Öppna upp fönstret Add för att lägga till resor till listwiev
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            AddTravelsWindow addTravelsWindow = new(travelManager, userManager);
            addTravelsWindow.Show();
            Close();

        }
    }
}
