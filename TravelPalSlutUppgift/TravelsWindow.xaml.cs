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

        private void UppdateUi()
        {
            // Uppdatera Ui
            
            //txtUserName.Text = this.user.UserName;
            
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

        //public void FilterTravels()
        //{
        //    List<Travel> travel = new();

        //    travel = this.userManager.GetAllUsers();

        //    foreach(Travel addtravel in travel)
        //    {
        //        if(travel is Travel)
        //        {
        //            travels.Add(addtravel as Travel);
        //        }
        //    }


        //}
        private void btnUserDetails_Click(object sender, RoutedEventArgs e)
        {
            // Öppna user window
            
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);
            userDetailsWindow.Show();
            Close();
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
                Close();


            }
            else
            {
                MessageBox.Show("You need to pick a travel");
            }

            
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lwTravelInfo.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                // Ta bort resa från listView
                
                Travel selectedTravel = selectedItem.Tag as Travel;
                //this.user.Travels.Remove(selectedTravel);

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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Öppna upp fönstret Add för att lägga till resor till listwiev
            AddTravelsWindow addTravelsWindow = new(travelManager, userManager);
            addTravelsWindow.Show();
            Close();

        }
    }
}
