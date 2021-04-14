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






            SideCollection = new SeriesCollection();
            TypeCollection = new SeriesCollection();
            SizeCollection = new SeriesCollection();
            DrinkCollection = new SeriesCollection();
           

            InitializeComponent();
            initializeType();
            initialiseSize();
            initialiseSides();
            initialiseDrinks();
            initialiseStaff();

           // DataContext = this;

            

        }

        public AdminPanel(int language, int theme): this()
        {
            languagesComboBox.SelectedIndex = language;
            themeComboBox.SelectedIndex = theme;
        }



        private void initializeType()
        {
            int chickenCount = context.orders.Where(e => e.type.Equals("Chicken")).Count();
            int porkCount = context.orders.Where(e => e.type.Equals("Pork")).Count();
            int mixedCount = context.orders.Where(e => e.type.Equals("Mixed")).Count();
            TypeCollection.Clear();
            TypeCollection.Add(new PieSeries
            {
                Title = Application.Current.FindResource("Pork") as string,
                Values = new ChartValues<ObservableValue> { new ObservableValue(porkCount) },
                DataLabels = true
            });
            TypeCollection.Add(new PieSeries
            {
                Title = Application.Current.FindResource("Chicken") as string,
                Values = new ChartValues<ObservableValue> { new ObservableValue(chickenCount) },
                DataLabels = true
            });

            TypeCollection.Add(
                new PieSeries
                {
                    Title = Application.Current.FindResource("Mixed") as string,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(mixedCount) },
                    DataLabels = true
                });
               
            


        }


        private void initialiseSize()
        {
            int smallCount = context.orders.Where(e => e.size.Equals("Small")).Count();
            int mediumCount = context.orders.Where(e => e.size.Equals("Medium")).Count();
            int larkeCount = context.orders.Where(e => e.size.Equals("Large")).Count();
            SizeCollection.Clear();
            SizeCollection.Add(new PieSeries
            {
                Title = Application.Current.FindResource("Small") as string,
                Values = new ChartValues<ObservableValue> { new ObservableValue(smallCount) },
                DataLabels = true
            });
            SizeCollection.Add(new PieSeries
            {
                Title = Application.Current.FindResource("Medium") as string,
                Values = new ChartValues<ObservableValue> { new ObservableValue(mediumCount) },
                DataLabels = true
            });
            SizeCollection.Add(new PieSeries
            {
                Title = Application.Current.FindResource("Large") as string,
                Values = new ChartValues<ObservableValue> { new ObservableValue(larkeCount) },
                DataLabels = true
            });

               
               
               


        }



        private void initialiseSides()
        {
            //SideCollection = new SeriesCollection();
            SideCollection.Clear();
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
            SideLabels = null;
            SideLabels = sideNames.ToArray();
            DataContext = SideLabels;
            DataContext = this;
            
        }




        private void initialiseDrinks()
        {
            // DrinkCollection = new SeriesCollection();
            DrinkCollection.Clear();
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
            DrinkLabels = null;
            DrinkLabels = drinkNames.ToArray();
            DataContext = SideLabels;
            DataContext = this;
        }


























        private void LogOut(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login(languagesComboBox.SelectedIndex, themeComboBox.SelectedIndex);
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



            initializeType();
            initialiseSize();
            initialiseSides();
            initialiseDrinks();
            initialiseStaff();
            DataContext = this;
            
            if (currUser!=null)
                displayInfo(currUser.username);
        }



        private void initialiseStaff()
        {
            if (myStackPanel != null)
            {
                context = new GyroDB();
                var staff = context.staffs.Where(e => e.isActive == 1).ToList(); ;
                myStackPanel.Children.Clear();
                myStackPanel.Children.Add(createPlus());
                foreach (var s in staff)
                {
                    Grid g = createGrid(s.username);
                    myStackPanel.Children.Add(g);
                }
            }
        }

        private void openAddUser()
        {
            AddStaff add = new AddStaff();
            add.Closed += (sender, e) => initialiseStaff();
            add.ShowDialog();
            
        }

        private Grid createPlus()
        {
            Grid g = new Grid();
            g.MouseLeftButtonDown += (sender, e) => openAddUser();
            g.Width = 90;
            g.Height = 110;
            g.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Application.Current.FindResource("PrimaryHueDarkBrush").ToString()));
            g.Margin = new Thickness(20, 0, 0, 0);






            Label l = new Label();
            // l.Margin = new Thickness(42, 40, 8, 38);
            l.FontSize = 10;
            l.Content = Application.Current.FindResource("Add");



            Image im = new Image();
            im.Source = new BitmapImage(new Uri("/Resources/images/plus.png", UriKind.Relative));
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


        private Grid createGrid(string username)
        {
            Grid g = new Grid();
            g.MouseLeftButtonDown += (sender, e) => displayInfo(username);
            g.Width = 90;
            g.Height = 110;
            g.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Application.Current.FindResource("PrimaryHueDarkBrush").ToString()));
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
            String workSince = (Application.Current.FindResource("Works Since") as string) + " " + staff.zaposlenOd.Date.ToShortDateString() + "\n";
            string phone = (Application.Current.FindResource("Phone") as string) + "\t" + staff.brojTelefona + "\n";
            string paycheck = (Application.Current.FindResource("Paycheck") as string) + "\t" + staff.plata + "KM\n";
            string total = (Application.Current.FindResource("Total Orders") as string) + "\t" + staff.orders.Count + "\n";




            string racunString = name + surname + workSince + phone + paycheck + total;
            Application.Current.Dispatcher.Invoke(() =>
            {
                staffInfoLabel.Content = racunString;
            });

            editButton.Visibility = Visibility.Visible;
            deleteButton.Visibility = Visibility.Visible;

        }

        private void BrushClicked(object sender, MouseButtonEventArgs e)
        {
            themeComboBox.IsDropDownOpen = true;
        }

        private void ChangeTheme(object sender, SelectionChangedEventArgs e)
        {
            string selected = (e.AddedItems[0] as ComboBoxItem).Content as string;
            if (selected != null)
            {
                if (selected.Equals(Application.Current.FindResource("Light")))
                {
                    var resource = new ResourceDictionary();
                    resource.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml");
                    var resource2 = new ResourceDictionary();
                    resource2.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Lime.xaml");
                    var resource3 = new ResourceDictionary();
                    resource3.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Green.xaml");

                    Application.Current.Resources.MergedDictionaries.Add(resource);
                    Application.Current.Resources.MergedDictionaries.Add(resource2);
                    Application.Current.Resources.MergedDictionaries.Add(resource3);

                }
                if (selected.Equals(Application.Current.FindResource("Dark")))
                {
                    var resource = new ResourceDictionary();
                    resource.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
                    var resource2 = new ResourceDictionary();
                    resource2.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Lime.xaml");
                    var resource3 = new ResourceDictionary();
                    resource3.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Green.xaml");
                    Application.Current.Resources.MergedDictionaries.Add(resource);
                    Application.Current.Resources.MergedDictionaries.Add(resource2);
                    Application.Current.Resources.MergedDictionaries.Add(resource3);
                }
                if (selected.Equals(Application.Current.FindResource("DarkRed")))
                {

                    var resource = new ResourceDictionary();
                    resource.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
                    var resource2 = new ResourceDictionary();
                    resource2.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Red.xaml");
                    var resource3 = new ResourceDictionary();
                    resource3.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Orange.xaml");




                    Application.Current.Resources.MergedDictionaries.Add(resource);
                    Application.Current.Resources.MergedDictionaries.Add(resource2);
                    Application.Current.Resources.MergedDictionaries.Add(resource3);
                }

                myStackPanel.Children.Clear();
                initialiseStaff();
            }
        }

        private void Edit_Staff(object sender, RoutedEventArgs e)
        {
            EditStaff es = new EditStaff(currUser);
            es.Closed += (a, b) =>
            {
                initialiseStaff();
                staffInfoLabel.Content = "";
                deleteButton.Visibility = Visibility.Hidden;
                editButton.Visibility = Visibility.Hidden;
            };
            es.ShowDialog();
        }

        private void Delete_Staff(object sender, RoutedEventArgs e)
        {
            var curr = context.staffs.Find(currUser.id);
            curr.isActive = 0;
            context.SaveChanges();
            currUser = null;
            initialiseStaff();
            staffInfoLabel.Content = "";
            deleteButton.Visibility = Visibility.Hidden;
            editButton.Visibility = Visibility.Hidden;
        }
    }

   
}
