using Giros.Model;
using Giros.Views;
using Syncfusion.SfSkinManager;
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

namespace Giros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {

        GyroDB context;
        public Login()
        {
            //SfSkinManager.ApplyStylesOnApplication = true;
            //SfSkinManager.SetTheme(this, new Theme("FluentDark"));
            InitializeComponent();
            if (context == null)
                context = new GyroDB();

        }

        public Login(int language, int theme):this()
        {
            languagesComboBox.SelectedIndex = language;
            themeComboBox.SelectedIndex = theme;
        }

        //private void SetLanguageDictionary()
        //{
        //    ResourceDictionary dict = new ResourceDictionary();
        //    dict.Source = new Uri("Resources/StringResources.Srb.xaml", UriKind.Relative);
        //    this.Resources.MergedDictionaries.Add(dict);
        //}

        private void Button_Click(object sender, RoutedEventArgs ev)
        {
            String username = usernameBox.Text.Trim();
            String password = passwordBox.Password.Trim();
            var u = context.staffs.Where(e => e.username.Equals(username) && e.password.Equals(password));
            if(u.Count()>0)
            {
                if((bool)u.First().isAdmin)
                {
                    AdminPanel d = new AdminPanel(languagesComboBox.SelectedIndex, themeComboBox.SelectedIndex);
                    d.Show();
                    this.Close();
                }
                else
                {
                    Dashboard d = new Dashboard(u.First(), languagesComboBox.SelectedIndex, themeComboBox.SelectedIndex);
                    
                    d.Show();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("Wrong username/password combination", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

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
        }

        private void brushClicked(object sender, MouseButtonEventArgs e)
        {
            themeComboBox.IsDropDownOpen = true;
        }

        private void ChangeTheme(object sender, SelectionChangedEventArgs e)
        {
            string selected = (e.AddedItems[0] as ComboBoxItem).Content as string;
            if(selected!=null)
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
            }
           

        }

            //private void ChangeTheme(object sender, MouseButtonEventArgs e)
            //{
            //    var resource = new ResourceDictionary();
            //    resource.Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml");
            //    var resource2 = new ResourceDictionary();
            //    resource2.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Red.xaml");
            //    var resource3 = new ResourceDictionary();
            //    resource3.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Orange.xaml");




            //    Application.Current.Resources.MergedDictionaries.Add(resource);
            //    Application.Current.Resources.MergedDictionaries.Add(resource2);
            //    Application.Current.Resources.MergedDictionaries.Add(resource3);
            //    //LoginWindow.FontFamily = new FontFamily("Century Gothic");
            //}
        }
}
