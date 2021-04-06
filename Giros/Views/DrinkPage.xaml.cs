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
    /// Interaction logic for DrinkPage.xaml
    /// </summary>
    public partial class DrinkPage : Page
    {
        public DrinkPage()
        {
            InitializeComponent();
        }

        private void appleJuiceBackground(object sender, MouseButtonEventArgs e)
        {
            if (appleJuiceCanvas.Background == Brushes.LightGreen)
                appleJuiceCanvas.Background = Brushes.Transparent;
            else if (appleJuiceCanvas.Background == Brushes.Transparent)
                appleJuiceCanvas.Background = Brushes.LightGreen;
        }

        private void beerBackground(object sender, MouseButtonEventArgs e)
        {
            if (beerCanvas.Background == Brushes.LightGreen)
                beerCanvas.Background = Brushes.Transparent;
            else if (beerCanvas.Background == Brushes.Transparent)
                beerCanvas.Background = Brushes.LightGreen;
        }

        private void cokeBackground(object sender, MouseButtonEventArgs e)
        {
            if (cokeCanvas.Background == Brushes.LightGreen)
                cokeCanvas.Background = Brushes.Transparent;
            else if (cokeCanvas.Background == Brushes.Transparent)
                cokeCanvas.Background = Brushes.LightGreen;
        }

        private void exoticKruskaBackground(object sender, MouseButtonEventArgs e)
        {
            if (exoticKruskaCanvas.Background == Brushes.LightGreen)
                exoticKruskaCanvas.Background = Brushes.Transparent;
            else if (exoticKruskaCanvas.Background == Brushes.Transparent)
                exoticKruskaCanvas.Background = Brushes.LightGreen;
        }

        private void exoticLimetaBackground(object sender, MouseButtonEventArgs e)
        {
            if (exoticLimetaCanvas.Background == Brushes.LightGreen)
                exoticLimetaCanvas.Background = Brushes.Transparent;
            else if (exoticLimetaCanvas.Background == Brushes.Transparent)
                exoticLimetaCanvas.Background = Brushes.LightGreen;
        }

        private void fantaBackground(object sender, MouseButtonEventArgs e)
        {
            if (fantaCanvas.Background == Brushes.LightGreen)
                fantaCanvas.Background = Brushes.Transparent;
            else if (fantaCanvas.Background == Brushes.Transparent)
                fantaCanvas.Background = Brushes.LightGreen;
        }

        private void mineralWaterBackground(object sender, MouseButtonEventArgs e)
        {
            if (mineralWaterCanvas.Background == Brushes.LightGreen)
                mineralWaterCanvas.Background = Brushes.Transparent;
            else if (mineralWaterCanvas.Background == Brushes.Transparent)
                mineralWaterCanvas.Background = Brushes.LightGreen;
        }

        private void pepsiBackground(object sender, MouseButtonEventArgs e)
        {
            if (pepsiCanvas.Background == Brushes.LightGreen)
                pepsiCanvas.Background = Brushes.Transparent;
            else if (pepsiCanvas.Background == Brushes.Transparent)
                pepsiCanvas.Background = Brushes.LightGreen;
        }

        private void regularWaterBackground(object sender, MouseButtonEventArgs e)
        {
            if (regularWaterCanvas.Background == Brushes.LightGreen)
                regularWaterCanvas.Background = Brushes.Transparent;
            else if (regularWaterCanvas.Background == Brushes.Transparent)
                regularWaterCanvas.Background = Brushes.LightGreen;
        }
    }
}
