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

namespace TravelPalSlutUppgift
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow()
        {
            InitializeComponent();
            // Vilken typ av resa är det, då printas trip eller vacation i fönstret
            lbTripOrVacation.Content = "Trip";

            // sätta en if sats för att välja vilken typ det är
            lbSpecial.Content = "All inclusive:";
        }
    }
}
