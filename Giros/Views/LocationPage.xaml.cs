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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Giros.Views
{
    /// <summary>
    /// Interaction logic for LocationPage.xaml
    /// </summary>
    public partial class LocationPage : Page
    {
        public LocationPage()
        {
            InitializeComponent();
        }

        private void selectDineInCanvas(object sender, MouseButtonEventArgs e)
        {
            DineInCanvas.Background = Brushes.LightGreen;
            if (TakeawayCanvas.Background == Brushes.LightGreen)
                TakeawayCanvas.Background = Brushes.Transparent;
            
        }

        private void selectTakeawayCanvas(object sender, MouseButtonEventArgs e)
        {
            TakeawayCanvas.Background = Brushes.LightGreen;
            if (DineInCanvas.Background == Brushes.LightGreen)
                DineInCanvas.Background = Brushes.Transparent;
        }
    }
}
