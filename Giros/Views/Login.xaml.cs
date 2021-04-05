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
        public Login()
        {
            //SfSkinManager.ApplyStylesOnApplication = true;
            //SfSkinManager.SetTheme(this, new Theme("FluentDark"));
            InitializeComponent();

        }

        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri("Resources/StringResources.Srb.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(dict);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Dashboard d = new Dashboard();
            d.Show();
            this.Close();

        }


    }
}
