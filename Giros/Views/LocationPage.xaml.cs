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
            dineInCanvas.Background = Brushes.LightGreen;
            if (takeawayCanvas.Background == Brushes.LightGreen)
                takeawayCanvas.Background = Brushes.Transparent;
            
        }

        private void selectTakeawayCanvas(object sender, MouseButtonEventArgs e)
        {
            takeawayCanvas.Background = Brushes.LightGreen;
            if (dineInCanvas.Background == Brushes.LightGreen)
                dineInCanvas.Background = Brushes.Transparent;
        }
    }
}
