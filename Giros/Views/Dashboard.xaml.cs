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

namespace Giros.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {

        Uri drinkPage = new Uri("DrinkPage.xaml", UriKind.Relative);
        Uri sidePage = new Uri("SidePage.xaml", UriKind.Relative);
        Uri sizePage = new Uri("SizePage.xaml", UriKind.Relative);
        Uri typePage = new Uri("TypePage.xaml", UriKind.Relative);


        public Dashboard()
        {
            InitializeComponent();
            mainFrame.Source = typePage;
            for(int i=0;i<20;i++)
            {
                Button b = new Button();
                b.Content = "Button" + i;
                b.Margin = new Thickness(0,0,10,0);
                myStackPanel.Children.Add(b);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (mainFrame.Source.ToString().Split('/')[2].Equals(typePage.ToString()))
                mainFrame.Source = sizePage;

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sizePage.ToString()))
                mainFrame.Source = sidePage;

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sidePage.ToString()))
                mainFrame.Source = drinkPage;
        }
    }
}
