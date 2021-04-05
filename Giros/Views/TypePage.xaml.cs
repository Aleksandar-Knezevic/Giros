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
            chickenCanvas.Background = Brushes.LightGreen;
            if (porkCanvas.Background == Brushes.LightGreen)
                porkCanvas.Background = Brushes.Transparent;
            if (mixCanvas.Background == Brushes.LightGreen)
                mixCanvas.Background = Brushes.Transparent;
        }

        private void selectPorkCanvas(object sender, MouseButtonEventArgs e)
        {
            porkCanvas.Background = Brushes.LightGreen;
            if (chickenCanvas.Background == Brushes.LightGreen)
                chickenCanvas.Background = Brushes.Transparent;
            if (mixCanvas.Background == Brushes.LightGreen)
                mixCanvas.Background = Brushes.Transparent;
        }

        private void selectMixCanvas(object sender, MouseButtonEventArgs e)
        {
            mixCanvas.Background = Brushes.LightGreen;
            if (porkCanvas.Background == Brushes.LightGreen)
                porkCanvas.Background = Brushes.Transparent;
            if (chickenCanvas.Background == Brushes.LightGreen)
                chickenCanvas.Background = Brushes.Transparent;
        }
    }
}
