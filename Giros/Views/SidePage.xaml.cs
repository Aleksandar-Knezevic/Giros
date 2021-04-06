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
    /// Interaction logic for SidePage.xaml
    /// </summary>
    public partial class SidePage : Page
    {
        public SidePage()
        {
            InitializeComponent();
        }

        private void tomatoBackground(object sender, MouseButtonEventArgs e)
        {
            if (tomatoCanvas.Background == Brushes.LightGreen)
                tomatoCanvas.Background = Brushes.Transparent;
            else if (tomatoCanvas.Background == Brushes.Transparent)
                tomatoCanvas.Background = Brushes.LightGreen;
         
        }

        private void cabbageBackground(object sender, MouseButtonEventArgs e)
        {
            if (cabbageCanvas.Background == Brushes.LightGreen)
                cabbageCanvas.Background = Brushes.Transparent;
            else if (cabbageCanvas.Background == Brushes.Transparent)
                cabbageCanvas.Background = Brushes.LightGreen;
        }

        private void cucumberBackground(object sender, MouseButtonEventArgs e)
        {
            if (cucumberCanvas.Background == Brushes.LightGreen)
                cucumberCanvas.Background = Brushes.Transparent;
            else if (cucumberCanvas.Background == Brushes.Transparent)
                cucumberCanvas.Background = Brushes.LightGreen;
        }

        private void friesBackground(object sender, MouseButtonEventArgs e)
        {
            if (friesCanvas.Background == Brushes.LightGreen)
                friesCanvas.Background = Brushes.Transparent;
            else if (friesCanvas.Background == Brushes.Transparent)
                friesCanvas.Background = Brushes.LightGreen;
        }

        private void hotSauceBackground(object sender, MouseButtonEventArgs e)
        {
            if (hotSauceCanvas.Background == Brushes.LightGreen)
                hotSauceCanvas.Background = Brushes.Transparent;
            else if (hotSauceCanvas.Background == Brushes.Transparent)
                hotSauceCanvas.Background = Brushes.LightGreen;
        }

        private void ketchupBackground(object sender, MouseButtonEventArgs e)
        {
            if (ketchupCanvas.Background == Brushes.LightGreen)
                ketchupCanvas.Background = Brushes.Transparent;
            else if (ketchupCanvas.Background == Brushes.Transparent)
                ketchupCanvas.Background = Brushes.LightGreen;
        }

        private void lettuceBackground(object sender, MouseButtonEventArgs e)
        {
            if (lettuceCanvas.Background == Brushes.LightGreen)
                lettuceCanvas.Background = Brushes.Transparent;
            else if (lettuceCanvas.Background == Brushes.Transparent)
                lettuceCanvas.Background = Brushes.LightGreen;
        }

        private void mayoBackground(object sender, MouseButtonEventArgs e)
        {
            if (mayoCanvas.Background == Brushes.LightGreen)
                mayoCanvas.Background = Brushes.Transparent;
            else if (mayoCanvas.Background == Brushes.Transparent)
                mayoCanvas.Background = Brushes.LightGreen;
        }

        private void mustardBackground(object sender, MouseButtonEventArgs e)
        {
            if (mustardCanvas.Background == Brushes.LightGreen)
                mustardCanvas.Background = Brushes.Transparent;
            else if (mustardCanvas.Background == Brushes.Transparent)
                mustardCanvas.Background = Brushes.LightGreen;
        }

        private void onionBackground(object sender, MouseButtonEventArgs e)
        {
            if (onionCanvas.Background == Brushes.LightGreen)
                onionCanvas.Background = Brushes.Transparent;
            else if (onionCanvas.Background == Brushes.Transparent)
                onionCanvas.Background = Brushes.LightGreen;
        }

        private void pepperBackground(object sender, MouseButtonEventArgs e)
        {
            if (pepperCanvas.Background == Brushes.LightGreen)
                pepperCanvas.Background = Brushes.Transparent;
            else if (pepperCanvas.Background == Brushes.Transparent)
                pepperCanvas.Background = Brushes.LightGreen;
        }

        private void whiteSauceBackground(object sender, MouseButtonEventArgs e)
        {
            if (whiteSauceCanvas.Background == Brushes.LightGreen)
                whiteSauceCanvas.Background = Brushes.Transparent;
            else if (whiteSauceCanvas.Background == Brushes.Transparent)
                whiteSauceCanvas.Background = Brushes.LightGreen;
        }
    }
}
