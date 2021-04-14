using Giros.Model;
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
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    /// 
    
    public partial class AddStaff : Window
    {
        GyroDB context;
        public AddStaff()
        {
            InitializeComponent();
            if (context == null)
                context = new GyroDB();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var staff = context.staffs.Create();
            staff.username = usernameTextBox.Text.Trim();
            staff.password = passwordTextBox.Password.Trim();
            staff.isAdmin = false;
            staff.ime = nameTextBox.Text.Trim();
            staff.prezime = surnameTextBox.Text.Trim();
            staff.zaposlenOd = DateTime.Now;
            staff.brojTelefona = phoneTextBox.Text.Trim();
            staff.plata = Decimal.Parse(paycheckTextBox.Text.Trim());
            staff.isActive = 1;
            staff.isAdmin = false;
            var result = context.staffs.Where(a => a.username.Equals(staff.username));
            if (result.Count()>0)
            {
                takenLabel.Visibility = Visibility.Visible;
            }
            else
            {
                context.staffs.Add(staff);
                context.SaveChanges();
                this.Close();
            }

        }
    }
}
