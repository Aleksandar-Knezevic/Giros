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
                    Title = "Pork",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(porkCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Chicken",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(chickenCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Mixed",
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
                    Title = "Small",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(smallCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Medium",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(mediumCount) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Large",
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
                        Title = "Pilozi",
                        Values = values,
                        DataLabels=true
                    }
                    );
            SideLabels = sides.Select(e => e.name).ToArray();
            
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
                        Title = "Pica",
                        Values = values,
                        DataLabels = true,
                        Fill=Brushes.Red
                    }
                    );
            DrinkLabels = drinks.Select(e => e.name).ToArray();
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

            //initializeType();
            //initialiseSize();
            //initialiseSides();
        }
    }

   
}
