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
    /// Interaction logic for TypePage.xaml
    /// </summary>
    public partial class TypePage : Page
    {
        public TypePage()
        {
            InitializeComponent();
        }

        private void selectChickenCanvas(object sender, MouseButtonEventArgs e)
        {
            ChickenCanvas.Background = Brushes.LightGreen;
            if (PorkCanvas.Background == Brushes.LightGreen)
                PorkCanvas.Background = Brushes.Transparent;
            if (MixedCanvas.Background == Brushes.LightGreen)
                MixedCanvas.Background = Brushes.Transparent;
        }

        private void selectPorkCanvas(object sender, MouseButtonEventArgs e)
        {
            PorkCanvas.Background = Brushes.LightGreen;
            if (ChickenCanvas.Background == Brushes.LightGreen)
                ChickenCanvas.Background = Brushes.Transparent;
            if (MixedCanvas.Background == Brushes.LightGreen)
                MixedCanvas.Background = Brushes.Transparent;
        }

        private void selectMixCanvas(object sender, MouseButtonEventArgs e)
        {
            MixedCanvas.Background = Brushes.LightGreen;
            if (PorkCanvas.Background == Brushes.LightGreen)
                PorkCanvas.Background = Brushes.Transparent;
            if (ChickenCanvas.Background == Brushes.LightGreen)
                ChickenCanvas.Background = Brushes.Transparent;
        }

    }
}
