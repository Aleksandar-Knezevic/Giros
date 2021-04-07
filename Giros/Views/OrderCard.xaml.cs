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
    /// Interaction logic for OrderCard.xaml
    /// </summary>
    public partial class OrderCard : Page
    {
        string idString=":";
        public OrderCard()
        {
            InitializeComponent();
        }

        public OrderCard(int id)
        {
            idString += id;
            InitializeComponent();
            orderId.Content = idString;
        }
    }
}
