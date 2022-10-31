﻿using System;
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
using TravelPalSlutUppgift.Travels;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        private UserManager usermanager;

        private User user;
        private readonly UserManager userManager;
        private readonly TravelManager travelManager;
        private Travel travel;
        AddTravelsWindow addTravelsWindow;

        

        public TravelDetailsWindow(UserManager userManager, TravelManager travelManager, Travel travel)
        {
            InitializeComponent();
            this.userManager=userManager;
            this.travelManager=travelManager;
            this.travel = travel;

            if(travel is Trip)
            {
                Trip trip = travel as Trip;

                lbTripOrVacation.Content = trip.Type;
            }
            else if (travel is Vacation)
            {
                Vacation vacation = travel as Vacation;

                if(vacation != null && vacation.AllInclusive) 
                {
                    lbSpecial.Content = "All Inclusive";

                }
                else if (vacation != null && !vacation.AllInclusive)
                {
                    lbSpecial.Content = "Standard vacation";
                }
            }

            // Vilken typ av resa är det, då printas trip eller vacation i fönstret

            // sätta en if sats för att välja vilken typ det är

            UppdateUi();
        }



        private void UppdateUi()
        {

            // Uppdatera
            lblDestination.Content = travel.Destination;

            lblCountry.Content = travel.Countrys;

            lblTravelers.Content = travel.Travelers;

            //lbTripOrVacation.Content = travel.GetTravelType(); // Visa trip

            //lbSpecial.Content = travel.GetTravelType(); // ska stå all inclusive

        }
    }
}
