﻿using System;
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
using TravelPalSlutUppgift.Enums;
using TravelPalSlutUppgift.Managers;
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for AddTravelsWindow.xaml
    /// </summary>
    public partial class AddTravelsWindow : Window

    {
        
        TravelManager travelManager;
       
        bool travelIsATrip = false;
        bool travelIsAVacation = false;
        
        private UserManager userManager;

        private User user;
       
        public AddTravelsWindow(TravelManager travelManager, UserManager userManager)
        {
            InitializeComponent();

            string[] getCountries = Enum.GetNames(typeof(Countries));

            cbCountry.ItemsSource = getCountries;

            string[] getTripVacation = Enum.GetNames(typeof(TripVacation));

            cbTripOrVacation.ItemsSource = getTripVacation;
            
            string[] getLeisureOrWork = Enum.GetNames(typeof(TripTypes));

            cbTriChoose.ItemsSource= getLeisureOrWork;

            this.userManager=userManager;

            this.travelManager=travelManager;
          
        }

        private bool CheckInputs()
        {
            // Se till så att allt är ifyllt för att ha möjlighet att gå vidare
            string destination = txtDestination.Text;
            string country = cbCountry.SelectedItem as string;
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);
            string travelers = txtTravelers.Text;
            string tripOrVacation = cbTripOrVacation.SelectedItem as string;
            TripVacation tripVacation = (TripVacation)Enum.Parse(typeof(TripVacation), tripOrVacation);
            // Markera ut för att köra programmet

            string[] fields = new[] {destination, country, travelers, tripOrVacation };

            foreach(string field in fields)
            {
                if (string.IsNullOrEmpty(field))
                {
                    MessageBox.Show("You need to make a full travel registration");
                    return false;
                    
                }
            }
            return true;
        }

        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {
            if(CheckInputs())
            {
                //Spara ny information om vad användaren väljer
                string destination = txtDestination.Text;

                try
                {
                    int travelers = Convert.ToInt32(txtTravelers.Text);

                    string country = cbCountry.SelectedItem as string;
                    Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), country);

                    //string tripOrVacation = cbTripOrVacation.SelectedItem as string;
                    //TripVacation tripVacation = (TripVacation)Enum.Parse(typeof(Countries), tripOrVacation);
                    //selectedTravelType == "Trip"

                    if (travelIsATrip)
                    {
                        string selectedTripType = cbTriChoose.SelectedItem as string;
                        TripTypes selectedType = (TripTypes)Enum.Parse(typeof(TripTypes), selectedTripType);

                        //Trip trip = new(destination, selectedCountry, travelers, selectedType);


                        Travel travel = this.travelManager.CreateTravel(destination, selectedCountry, travelers, selectedType);

                        User user = userManager.SignedInUser as User;

                        user.Travels.Add(travel);
                    }
                    //selectedTravelType == "Vacation"
                    else if (travelIsAVacation)
                    {

                        bool allInclusive = (bool)xbVacationChoose.IsChecked;

                        Travel travel = this.travelManager.CreateTravel(destination, selectedCountry, travelers, allInclusive);

                        User user = userManager.SignedInUser as User;

                        user.Travels.Add(travel);
                    }

                    TravelsWindow travelsWindow = new(userManager, travelManager);
                    travelsWindow.Show();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbTripOrVacation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.selectedTravelType = cbTripOrVacation.SelectedItem as string;

            //var tripOrVacation = cbTripOrVacation.SelectedItem as string;


            switch (cbTripOrVacation.SelectedItem.ToString())
            {
                case "Trip":
                    {
                        cbTriChoose.Visibility = Visibility.Visible;
                        xbVacationChoose.Visibility = Visibility.Hidden;
                        travelIsATrip = true;
                        travelIsAVacation = false;
                        break;
                    }
                case "Vacation":
                    {
                        cbTriChoose.Visibility = Visibility.Hidden;
                        xbVacationChoose.Visibility = Visibility.Visible;
                        travelIsAVacation = true;
                        travelIsATrip = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }


}



