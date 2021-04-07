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
using System.Windows.Navigation;
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
        Uri locationPage = new Uri("LocationPage.xaml", UriKind.Relative);
        String type;
        String size;
        List<int> sideIds = new List<int>();
        List<int> drinkIds = new List<int>();
        String location;
        GyroDB context;

        //DrinkPage drinkPage = new DrinkPage();
        //SidePage sidePage = new SidePage();
        //SizePage sizePage = new SizePage();
        //TypePage typePage = new TypePage();


        public Dashboard()
        {
            InitializeComponent();
            if (context == null)
                context = new GyroDB();
            for(int i=0;i<9;i++)
            {
                Grid g = new Grid();
                g.MouseLeftButtonDown += (sender, e) => displayInfo(i);
                g.Width = 84;
                g.Height = 102;
                g.Background = Brushes.YellowGreen;
                g.Margin = new Thickness(10, 0, 0, 0);


                Image im = new Image();
                im.Source = new BitmapImage(new Uri("/Resources/images/gyro.png", UriKind.Relative));
               // im.Width = 40;
               // im.Height = 60;
                im.Margin = new Thickness(4, 30, 30, 29);
                


                //Button b = new Button();
                //b.Margin = new Thickness(28,77,29,4);
                //b.Height = 15;
                //b.Width = 28;
                //b.Background = Brushes.Green;
                //b.BorderBrush = Brushes.Green;

                //<Label Name="orderId" Margin="34,30,17,38" FontSize="15"></Label>

                Label l = new Label();
                l.Margin = new Thickness(42, 36, 17, 38);
                l.FontSize = 18;
                l.Content = ":"+i;


                g.Children.Add(im);
               // g.Children.Add(b);
                g.Children.Add(l);



                myStackPanel.Children.Add(g);
                
            }
            mainFrame.Source = typePage;

           
           
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
                        type = c.Name.Substring(0, c.Name.Length - 6);
                        break;
                    }

                }
                mainFrame.Source = sizePage;
                mainFrame.Navigated += goToSize;

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
                        size = c.Name.Substring(0, c.Name.Length - 6);
                    }
                }
                mainFrame.Source = sidePage;
                mainFrame.Navigated += goToSide;
            }



            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sidePage.ToString()))
            {
                SidePage sp = mainFrame.Content as SidePage;
                var grid = sp.Content as Grid;
                var ch = grid.Children;
                sideIds.Clear();
                foreach (var can in ch)
                {
                    Canvas c = can as Canvas;
                    if (c.Background == Brushes.LightGreen)
                    {
                        sideIds.Add(Int32.Parse(c.Uid));
                    }
                }

              
               

                mainFrame.Source = drinkPage;
                mainFrame.Navigated += goToDrink;
                
            }
            else if(mainFrame.Source.ToString().Split('/')[2].Equals(drinkPage.ToString()))
            {
                DrinkPage dp = mainFrame.Content as DrinkPage;
                var grid = dp.Content as Grid;
                var ch = grid.Children;
                drinkIds.Clear();
                foreach (var can in ch)
                {
                    Canvas c = can as Canvas;
                    if (c.Background == Brushes.LightGreen)
                        drinkIds.Add(Int32.Parse(c.Uid));
                }

                mainFrame.Source = locationPage;
                mainFrame.Navigated += goToLocation;
                nextButton.Content = Application.Current.FindResource("Finish") as string;


            }

            else if(nextButton.Content.Equals(Application.Current.FindResource("Finish").ToString()))
            {
                LocationPage lp = mainFrame.Content as LocationPage;
                var grid = lp.Content as Grid;
                var ch = grid.Children;
                foreach (var can in ch)
                {
                    Canvas c = can as Canvas;
                    if (c.Background == Brushes.LightGreen)
                    {
                        location = c.Name.Substring(0, c.Name.Length - 6);
                        break;
                    }

                }


                OrderModel om = new OrderModel()
                {
                    drinkIds = new List<int>(drinkIds),
                    location=location,
                    sideIds = new List<int>(sideIds),
                    size = size,
                    type = type,
                    staffId = 2
                };

                new Thread(() => addOrder(om)).Start();

                nextButton.Content = Application.Current.FindResource("Next") as string;
                mainFrame.Source = typePage;
                size = null;
                type = null;
                location = null;
                drinkIds.Clear();
                sideIds.Clear();
                myStackPanel.Children.Add(new Button());
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {



            if (mainFrame.Source.ToString().Split('/')[2].Equals(sizePage.ToString()))
            {


                mainFrame.Source = typePage;
                mainFrame.Navigated += backToType;


            }

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(sidePage.ToString()))
            {
                SidePage sp = mainFrame.Content as SidePage;
                Grid grid = sp.Content as Grid;
                var ch = grid.Children;
                sideIds.Clear();
                foreach (var c in ch)
                {
                    Canvas can = c as Canvas;
                    if (can.Background == Brushes.LightGreen)
                        sideIds.Add(Int32.Parse(can.Uid));

                }
                
                mainFrame.Source = sizePage;
                mainFrame.Navigated += backToSize;
            }

            else if (mainFrame.Source.ToString().Split('/')[2].Equals(drinkPage.ToString()))
            {
                DrinkPage dp = mainFrame.Content as DrinkPage;
                var grid = dp.Content as Grid;
                var ch = grid.Children;
                drinkIds.Clear();
                foreach (var can in ch)
                {
                    Canvas c = can as Canvas;
                    if (c.Background == Brushes.LightGreen)
                        drinkIds.Add(Int32.Parse(c.Uid));
                }

                mainFrame.Source = sidePage;
                mainFrame.Navigated += backToSides;
            }

            else if(mainFrame.Source.ToString().Split('/')[2].Equals(locationPage.ToString()))
            {
                LocationPage lp = mainFrame.Content as LocationPage;
                var grid = lp.Content as Grid;
                var ch = grid.Children;
                foreach(var can in ch)
                {
                    Canvas c = can as Canvas;
                    if(c.Background==Brushes.LightGreen)
                        location = c.Name.Substring(0, c.Name.Length - 6);
                }
                mainFrame.Source = drinkPage;
                mainFrame.Navigated += backToDrinks;
            }


        }

        private void addOrder(OrderModel om)
        {
            order o = context.orders.Create();
            o.size = om.size;
            o.type = om.type;
            o.staffId = om.staffId;
            o.location = om.location;
            foreach (var id in om.drinkIds)
                o.drinks.Add(context.drinks.Find(id));
            foreach (var id in om.sideIds)
                o.sides.Add(context.sides.Find(id));
            var or = context.orders.Add(o);
            context.SaveChanges();
        }

        private void backToType(object sender, NavigationEventArgs e)
        {
            TypePage tp = mainFrame.Content as TypePage;
            Grid grid = tp.Content as Grid;
            var ch = grid.Children;
            string pageName = type + "Canvas";
            foreach (var c in ch)
            {
                Canvas can = c as Canvas;
                if (can.Name.Equals(pageName))
                {
                    can.Background = Brushes.LightGreen;
                    break;

                }

            }
            
            mainFrame.Navigated -= backToType;
        }

        private void backToSize(object sender, NavigationEventArgs e)
        {
            SizePage sp = mainFrame.Content as SizePage;
            Grid grid = sp.Content as Grid;
            var ch = grid.Children;
            string pageName = size + "Canvas";
            foreach(var c in ch)
            {
                Canvas can = c as Canvas;
                if(can.Name.Equals(pageName))
                {
                    can.Background = Brushes.LightGreen;
                    break;
                }

            }
            mainFrame.Navigated -= backToSize;
        }

        private void backToSides(object sender, NavigationEventArgs e)
        {
            SidePage sp = mainFrame.Content as SidePage;
            Grid grid = sp.Content as Grid;
            var ch = grid.Children;
            foreach(var id in sideIds)
            {
                foreach(var c in ch)
                {
                    Canvas can = c as Canvas;
                    if (Int32.Parse(can.Uid) == id)
                        can.Background = Brushes.LightGreen;

                }
            }
            



            //nextButton.Content = Application.Current.FindResource("Next") as string;
            mainFrame.Navigated -= backToSides;
            
        }

        private void backToDrinks(object sender, NavigationEventArgs e)
        {
            DrinkPage sp = mainFrame.Content as DrinkPage;
            Grid grid = sp.Content as Grid;
            var ch = grid.Children;
            foreach (var id in drinkIds)
            {
                foreach (var c in ch)
                {
                    Canvas can = c as Canvas;
                    if (Int32.Parse(can.Uid) == id)
                        can.Background = Brushes.LightGreen;

                }
            }


            nextButton.Content = Application.Current.FindResource("Next") as string;
            mainFrame.Navigated -= backToDrinks;
        }




        private void goToSize(object sender, NavigationEventArgs e)
        {
            string canvasName = size + "Canvas";
            if(size!=null)
            {
                SizePage sp = mainFrame.Content as SizePage;
                Grid grid = sp.Content as Grid;
                var ch = grid.Children;
                foreach(var canvas in ch)
                {
                    Canvas c = canvas as Canvas;
                    if(c.Name.Equals(canvasName))
                    {
                        c.Background = Brushes.LightGreen;
                        break;
                    }
                }
            }
            mainFrame.Navigated -= goToSize;
        }

        private void goToSide(object sender, NavigationEventArgs e)
        {
            if(sideIds.Count>0)
            {
                SidePage sp = mainFrame.Content as SidePage;
                Grid grid = sp.Content as Grid;
                var ch = grid.Children;
                foreach(var id in sideIds)
                {
                    foreach(var can in ch)
                    {
                        Canvas c = can as Canvas;
                        if (Int32.Parse(c.Uid) == id)
                            c.Background = Brushes.LightGreen;
                    }
                }
            }
            mainFrame.Navigated -= goToSide;
        }


        private void goToDrink(object sender, NavigationEventArgs e)
        {
            if (drinkIds.Count > 0)
            {
                DrinkPage dp = mainFrame.Content as DrinkPage;
                Grid grid = dp.Content as Grid;
                var ch = grid.Children;
                foreach (var id in drinkIds)
                {
                    foreach (var can in ch)
                    {
                        Canvas c = can as Canvas;
                        if (Int32.Parse(c.Uid) == id)
                            c.Background = Brushes.LightGreen;
                    }
                }
            }
            mainFrame.Navigated -= goToDrink;
        }

        private void goToLocation(object sender, NavigationEventArgs e)
        {
            string canvasName = location + "Canvas";
            if (location != null)
            {
                LocationPage lp = mainFrame.Content as LocationPage;
                Grid grid = lp.Content as Grid;
                var ch = grid.Children;
                foreach (var canvas in ch)
                {
                    Canvas c = canvas as Canvas;
                    if (c.Name.Equals(canvasName))
                    {
                        c.Background = Brushes.LightGreen;
                        break;
                    }
                }
            }
            mainFrame.Navigated -= goToLocation;
        }


        private void displayInfo(int i)
        {
            new Thread(() =>
            {

            }).Start();
        }
    }
}
