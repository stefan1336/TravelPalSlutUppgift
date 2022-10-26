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
    /// Interaction logic for AddTravelsWindow.xaml
    /// </summary>
    public partial class AddTravelsWindow : Window
    {

        public AddTravelsWindow()
        {
            InitializeComponent();


        }

        private void UppdateUi()
        {
            // uppdatera ui
        }

        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {
            // Spara ny information
        }

        private void cbTripOrVacation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Vad är selectat? Trip eller vacation?

            // Om trip -> Visa cbTripType
            // Om vacation -> Visa xbAllInclusive
        }
    }
}
