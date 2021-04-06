using Giros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        order o = new order();
        GyroDb context = new GyroDb();

        //DrinkPage drinkPage = new DrinkPage();
        //SidePage sidePage = new SidePage();
        //SizePage sizePage = new SizePage();
        //TypePage typePage = new TypePage();


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
            {
                TypePage tp = mainFrame.Content as TypePage;
                var grid = tp.Content as Grid;
                var ch = grid.Children;
                foreach (var can in ch)
                {
                    Canvas c = can as Canvas;
                    if (c.Background == Brushes.LightGreen)
                    {
                        o.type = c.Name.Substring(0, c.Name.Length - 6);
                        break;
                    }

                }
                mainFrame.Source = sizePage;

            }

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sizePage.ToString()))
            {
                SizePage sp = mainFrame.Content as SizePage;
                var grid = sp.Content as Grid;
                var ch = grid.Children;
                foreach(var can in ch)
                {
                    Canvas c = can as Canvas;
                    if(c.Background == Brushes.LightGreen)
                    {
                        o.size = c.Name.Substring(0, c.Name.Length - 6);
                    }
                }
                mainFrame.Source = sidePage;
            }

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sidePage.ToString()))
            {
                SidePage sp = mainFrame.Content as SidePage;
                var grid = sp.Content as Grid;
                var ch = grid.Children;
                List<int> canvasIds = new List<int>();
                foreach (var can in ch)
                {
                    Canvas c = can as Canvas;
                    if (c.Background == Brushes.LightGreen)
                    {
                        canvasIds.Add(Int32.Parse(c.Uid));
                    }
                }




                new Thread(() =>
                {
                    foreach(var a in canvasIds)
                    {
                        side s = context.sides.Find(a);
                        o.sides.Add(s);
                    }
                        

                }).Start();
               

                mainFrame.Source = drinkPage;
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {



            if (mainFrame.Source.ToString().Split('/')[2].Equals(sizePage.ToString()))
                mainFrame.Source = typePage;

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sidePage.ToString()))
                mainFrame.Source = sizePage;

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(drinkPage.ToString()))
                mainFrame.Source = sidePage;


        }
    }
}
