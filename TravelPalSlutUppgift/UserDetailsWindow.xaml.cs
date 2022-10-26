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
using TravelPalSlutUppgift.Enums;
using TravelPalSlutUppgift.Managers;

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private UserManager userManager;
        public UserDetailsWindow(UserManager userManager)
        {
            InitializeComponent();

            this.userManager = userManager;

            string[] getCountries = Enum.GetNames(typeof(Countries));

            cbCountry.ItemsSource = getCountries;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Spara uppdaterad användaruppgifter
            // Stänga userDetailsWindow
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // återgå till transferwindow
            TravelsWindow travelsWindow = new(userManager);
            travelsWindow.Show();
            Close();

        }
    }
}
