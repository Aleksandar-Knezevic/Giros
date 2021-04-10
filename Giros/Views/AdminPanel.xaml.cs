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
using System.Windows.Controls.DataVisualization;
using LiveCharts;
using LiveCharts.Wpf;
using Giros.Model;
using LiveCharts.Defaults;

namespace Giros.Views
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    /// 

    

   

    public partial class AdminPanel : Window
    {
        staff currUser;
        GyroDB context;
        public SeriesCollection TypeCollection { get; set; }
        public SeriesCollection SizeCollection { get; set; }
        public SeriesCollection SideCollection { get; set; }
        public string[] SideLabels { get; set; }
        public SeriesCollection DrinkCollection { get; set; }
        public string[] DrinkLabels { get; set; }

        public AdminPanel()
        {
            if (context == null)
                context = new GyroDB();

            
            

            


            InitializeComponent();
            initializeType();
            initialiseSize();
            initialiseSides();
            initialiseDrinks();
            initialiseStaff();

            DataContext = this;

            

        }



        private void initializeType()
        {
            int chickenCount = context.orders.Where(e => e.type.Equals("Chicken")).Count();
            int porkCount = context.orders.Where(e => e.type.Equals("Pork")).Count();
            int mixedCount = context.orders.Where(e => e.type.Equals("Mixed")).Count();
            TypeCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = Application.Current.FindResource("Pork") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(porkCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = Application.Current.FindResource("Chicken") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(chickenCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = Application.Current.FindResource("Mixed") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(mixedCount) },
                    DataLabels = true
                }
            };


        }


        private void initialiseSize()
        {
            int smallCount = context.orders.Where(e => e.size.Equals("Small")).Count();
            int mediumCount = context.orders.Where(e => e.size.Equals("Medium")).Count();
            int larkeCount = context.orders.Where(e => e.size.Equals("Large")).Count();
            SizeCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = Application.Current.FindResource("Small") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(smallCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = Application.Current.FindResource("Medium") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(mediumCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = Application.Current.FindResource("Large") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(larkeCount) },
                    DataLabels = true
                }
            };
        }



        private void initialiseSides()
        {
            SideCollection = new SeriesCollection();
            var sides = context.sides.ToList();
            var values = new ChartValues<int>();
            foreach (var side in sides)
                values.Add(side.orders.Count);
            SideCollection.Add(
                    new ColumnSeries
                    {
                        Title = Application.Current.FindResource("Sides") as string,
                        Values = values,
                        DataLabels=true
                    }
                    );
            List<string> sideNames = new List<string>();
            foreach (var side in sides)
                sideNames.Add(Application.Current.FindResource(side.name) as string);
            SideLabels = sideNames.ToArray();
            
        }




        private void initialiseDrinks()
        {
            DrinkCollection = new SeriesCollection();
            var drinks = context.drinks.ToList();
            var values = new ChartValues<int>();
            foreach (var drink in drinks)
                values.Add(drink.orders.Count);
            DrinkCollection.Add(
                    new ColumnSeries
                    {
                        Title = Application.Current.FindResource("Drinks") as string,
                        Values = values,
                        DataLabels = true,
                        Fill=Brushes.Red
                    }
                    );

            List<String> drinkNames = new List<string>();
            foreach (var drink in drinks)
                drinkNames.Add(Application.Current.FindResource(drink.name) as string);
            DrinkLabels = drinkNames.ToArray();
        }


























        private void LogOut(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
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


            else if (languagesComboBox.SelectionBoxItem.ToString().Equals(Application.Current.FindResource("English") as string))
            {
                resources.Source = new Uri("/Resources/StringResources.Srb.xaml", UriKind.Relative);
            }




            Application.Current.Resources.MergedDictionaries.Add(resources);
            //if (TypeCollection != null)
            //    TypeCollection.Clear();
            //if (SizeCollection != null)
            //    SizeCollection.Clear();
            //if (SideCollection != null)
            //    SideCollection.Clear();
            //if (DrinkCollection != null)
            //    DrinkCollection.Clear();
            //if (SideLabels != null)
            //    SideLabels = null;
            //if (DrinkLabels != null)
            //    DrinkLabels = null;


            DataContext = this;
            initializeType();
            initialiseSize();
            initialiseSides();
            initialiseDrinks();
            
            if (currUser!=null)
                displayInfo(currUser.username);
        }



        private void initialiseStaff()
        {
            var staff = context.staffs.ToList();
            foreach (var s in staff)
            {
                Grid g = createGrid(s.username);
                myStackPanel.Children.Add(g);
            }
        }


        private Grid createGrid(string username)
        {
            Grid g = new Grid();
            g.MouseLeftButtonDown += (sender, e) => displayInfo(username);
            g.Width = 90;
            g.Height = 110;
            //g.Background = Brushes.Gray;
            g.Margin = new Thickness(20, 0 , 0, 0);
            





            Label l = new Label();
           // l.Margin = new Thickness(42, 40, 8, 38);
            l.FontSize = 15;
            l.Content =username;
            


            Image im = new Image();
            im.Source = new BitmapImage(new Uri("/Resources/images/staff.png", UriKind.Relative));
            im.Width = 60;
            im.Height = 80;
            im.Margin = new Thickness(0, 15, 0, 0);


            Border b = new Border();
            b.BorderThickness = new Thickness(1);
            b.BorderBrush = Brushes.Black;
            


            g.Children.Add(im);
            // g.Children.Add(b);
            g.Children.Add(l);
            g.Children.Add(b);
            l.VerticalAlignment = VerticalAlignment.Bottom;
            l.HorizontalAlignment = HorizontalAlignment.Center;
            im.VerticalAlignment = VerticalAlignment.Top;
            im.HorizontalAlignment = HorizontalAlignment.Center;

            return g;



        }


        private void displayInfo(string username)
        {
            var staff =  context.staffs.Where(e => e.username.Equals(username)).First();
            currUser = staff;
           
            String name = (Application.Current.FindResource("Name") as string) + "\t" + staff.ime + "\n";
            String surname = (Application.Current.FindResource("Surname") as string) + "\t" + staff.prezime + "\n";
            String workSince = (Application.Current.FindResource("Works Since") as string) + "\t" + staff.zaposlenOd.Date.ToShortDateString() + "\n";
            string phone = (Application.Current.FindResource("Phone") as string) + "\t" + staff.brojTelefona + "\n";
            string paycheck = (Application.Current.FindResource("Paycheck") as string) + "\t" + staff.plata + "KM\n";
            string total = (Application.Current.FindResource("Total Orders") as string) + "\t" + staff.orders.Count + "\n";




            string racunString = name + surname + workSince + phone + paycheck + total;
            Application.Current.Dispatcher.Invoke(() =>
            {
                staffInfoLabel.Content = racunString;
            });

        }
    }

   
}
