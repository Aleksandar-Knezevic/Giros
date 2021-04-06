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
    /// Interaction logic for SizePage.xaml
    /// </summary>
    public partial class SizePage : Page
    {
        public SizePage()
        {
            InitializeComponent();
        }

        private void selectSmallCanvas(object sender, MouseButtonEventArgs e)
        {
            smallCanvas.Background = Brushes.LightGreen;
            if (mediumCanvas.Background == Brushes.LightGreen)
                mediumCanvas.Background = Brushes.Transparent;
            if (largeCanvas.Background == Brushes.LightGreen)
                largeCanvas.Background = Brushes.Transparent;

        }

        private void selectMediumCanvas(object sender, MouseButtonEventArgs e)
        {
            mediumCanvas.Background = Brushes.LightGreen;
            if (smallCanvas.Background == Brushes.LightGreen)
                smallCanvas.Background = Brushes.Transparent;
            if (largeCanvas.Background == Brushes.LightGreen)
                largeCanvas.Background = Brushes.Transparent;

        }

        private void selectLargeCanvas(object sender, MouseButtonEventArgs e)
        {
            largeCanvas.Background = Brushes.LightGreen;
            if (mediumCanvas.Background == Brushes.LightGreen)
                mediumCanvas.Background = Brushes.Transparent;
            if (smallCanvas.Background == Brushes.LightGreen)
                smallCanvas.Background = Brushes.Transparent;
        }
    }
}
