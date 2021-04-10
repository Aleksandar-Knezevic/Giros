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
        int currId;
        staff currentlyLogged;

        //DrinkPage drinkPage = new DrinkPage();
        //SidePage sidePage = new SidePage();
        //SizePage sizePage = new SizePage();
        //TypePage typePage = new TypePage();


        public Dashboard()
        {
            InitializeComponent();

          


            if (context == null)
                context = new GyroDB();
            initializeStackPanel();

            

            mainFrame.Source = typePage;

           
           
        }

        public Dashboard(staff s, int language): this()
        {
            currentlyLogged = s;
            languagesComboBox.SelectedIndex = language;
            usernameLabel.Content = s.username;
        }

        public void initializeStackPanel()
        {
            var orders = context.orders.ToList().Where(e => e.isActive==1);
            foreach (var o in orders)
            {
                Grid g =  createGrid(o.id);
                myStackPanel.Children.Add(g);
             }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
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
                        mainFrame.Source = sizePage;
                        mainFrame.Navigated += goToSize;
                        return;
                    }

                }
               

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
                        mainFrame.Source = sidePage;
                        mainFrame.Navigated += goToSide;
                        break;
                    }
                }
                
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
                        OrderModel om = new OrderModel()
                        {
                            drinkIds = new List<int>(drinkIds),
                            location = location,
                            sideIds = new List<int>(sideIds),
                            size = size,
                            type = type,
                            staffId = currentlyLogged.id,

                        };


                        //Thread t = new Thread(() => addOrder(om));
                        //t.SetApartmentState(ApartmentState.STA);
                        //t.Start();

                        nextButton.Content = Application.Current.FindResource("Next") as string;
                        mainFrame.Source = typePage;
                        size = null;
                        type = null;
                        location = null;
                        drinkIds.Clear();
                        sideIds.Clear();



                        var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                        Task<Grid> t = addOrder(om);
                        t.Start(scheduler);
                        Grid g = await t;
                        myStackPanel.Children.Add(g);
                        return;
                    }

                }


                

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

        private Task<Grid> addOrder(OrderModel om)
        {
            return new Task<Grid>(() =>
            {
                order o = context.orders.Create();
                o.size = om.size;
                o.type = om.type;
                o.staffId = om.staffId;
                o.location = om.location;
                o.isActive = 1;
                foreach (var id in om.drinkIds)
                    o.drinks.Add(context.drinks.Find(id));
                foreach (var id in om.sideIds)
                    o.sides.Add(context.sides.Find(id));
                var or = context.orders.Add(o);
                context.SaveChanges();
                Grid g = createGrid(or.id);
                return g;
           });

            



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


        private async void displayInfo(int i)
        {
            var o = await context.orders.FindAsync(i);
            currId = o.id;
            decimal cijena;
            if (o.size.Equals("Small"))
                cijena = 4M;
            if (o.size.Equals("Medium"))
                cijena = 6M;
            else
                cijena = 8M;
            String type = (Application.Current.FindResource("Type") as string) + "\t" + (Application.Current.FindResource(o.type) as string) + "\n";
            String size = (Application.Current.FindResource("Size") as string) + "\t" + (Application.Current.FindResource(o.size) as string) + "\n";
            String sides = Application.Current.FindResource("Sides") as string;
            if (o.sides.Count==0)
                sides += "\n";
            else
            {
                foreach (var side in o.sides)
                    sides += "\t" + (Application.Current.FindResource(side.name) as string) + "\n";
            }
            
            
            String drinks = Application.Current.FindResource("Drinks") as string;
            if (o.drinks.Count==0)
                drinks += "\n";
            else
            {
                foreach (var drink in o.drinks)
                {
                    drinks += "\t" + (Application.Current.FindResource(drink.name) as string) + "\n";
                    cijena += drink.price;

                }

            }
           
                
            String location = (Application.Current.FindResource("Location") as string) + "\t" + (Application.Current.FindResource(o.location) as string) +  "\n";
            string racunString = type + size + sides + drinks + location;
            Application.Current.Dispatcher.Invoke(() =>
            {
                racunLabel.Content = racunString;
                cijenaLabel.Content = "Total" + "\t" + cijena.ToString()+"KM";
            });
                
        }




        private Grid createGrid(int i)
        {
                Grid g = new Grid();
                g.MouseLeftButtonDown += (sender, e) => displayInfo(i);
                g.Width = 84;
                g.Height = 102;
                g.Background = Brushes.YellowGreen;
                g.Margin = new Thickness(10, 0, 0, 0);





                Label l = new Label();
                l.Margin = new Thickness(42, 36, 8, 38);
                l.FontSize = 15;
                l.Content = ":" + i;

                Image im = new Image();
                im.Source = new BitmapImage(new Uri("/Resources/images/gyro.png", UriKind.Relative));
                im.Margin = new Thickness(4, 30, 30, 29);


                g.Children.Add(im);
                // g.Children.Add(b);
                g.Children.Add(l);
                return g;  


            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var o = await context.orders.FindAsync(currId);
            o.isActive = 0;
            await context.SaveChangesAsync();

            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                myStackPanel.Children.Clear();
                racunLabel.Content = "";
                cijenaLabel.Content = "";
                initializeStackPanel();
            });
            currId = 0;

        }

        private void planetClicked(object sender, MouseButtonEventArgs e)
        {
            languagesComboBox.IsDropDownOpen = true;
        }

           
       

        private void ChangeLaguage(object sender, SelectionChangedEventArgs e)
        {

            var resources = new ResourceDictionary();

            if (languagesComboBox.SelectionBoxItem.ToString().Equals(Application.Current.FindResource("Serbian") as string))
            {
               
                resources.Source = new Uri("/Resources/StringResources.xaml", UriKind.Relative);
                
            }
                

            else if(languagesComboBox.SelectionBoxItem.ToString().Equals(Application.Current.FindResource("English") as string))
            {
                resources.Source = new Uri("/Resources/StringResources.Srb.xaml", UriKind.Relative);
            }
                



            Application.Current.Resources.MergedDictionaries.Add(resources);

            if (currId != 0)
                displayInfo(currId);
        }

        private void LogOut(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
    }
}
