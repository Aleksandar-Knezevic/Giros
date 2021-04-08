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
            SmallCanvas.Background = Brushes.LightGreen;
            if (MediumCanvas.Background == Brushes.LightGreen)
                MediumCanvas.Background = Brushes.Transparent;
            if (LargeCanvas.Background == Brushes.LightGreen)
                LargeCanvas.Background = Brushes.Transparent;

        }

        private void selectMediumCanvas(object sender, MouseButtonEventArgs e)
        {
            MediumCanvas.Background = Brushes.LightGreen;
            if (SmallCanvas.Background == Brushes.LightGreen)
                SmallCanvas.Background = Brushes.Transparent;
            if (LargeCanvas.Background == Brushes.LightGreen)
                LargeCanvas.Background = Brushes.Transparent;

        }

        private void selectLargeCanvas(object sender, MouseButtonEventArgs e)
        {
            LargeCanvas.Background = Brushes.LightGreen;
            if (MediumCanvas.Background == Brushes.LightGreen)
                MediumCanvas.Background = Brushes.Transparent;
            if (SmallCanvas.Background == Brushes.LightGreen)
                SmallCanvas.Background = Brushes.Transparent;
        }
    }
}
