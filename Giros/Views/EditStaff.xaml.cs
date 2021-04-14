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
    /// Interaction logic for EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {

        GyroDB context;
        staff user;
        public EditStaff()
        {
            if (context == null)
                context = new GyroDB();
            InitializeComponent();
        }

        public EditStaff(staff user):this()
        {
            this.user = user;
            nameTextBox.Text = user.ime;
            surnameTextBox.Text = user.prezime;
            usernameTextBox.Text = user.username;
            passwordTextBox.Password = user.password;
            phoneTextBox.Text = user.brojTelefona;
            paycheckTextBox.Text = user.plata.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var staff = context.staffs.Find(user.id);
            staff.username = usernameTextBox.Text.Trim();
            var result = context.staffs.Where(a => a.username.Equals(staff.username));
            if (result.Count() > 0)
            {
                takenLabel.Visibility = Visibility.Visible;
                
            }
            else
            {
              
            staff.password = passwordTextBox.Password.Trim();
            staff.isAdmin = false;
            staff.ime = nameTextBox.Text.Trim();
            staff.prezime = surnameTextBox.Text.Trim();
            staff.zaposlenOd = DateTime.Now;
            staff.brojTelefona = phoneTextBox.Text.Trim();
            staff.plata = Decimal.Parse(paycheckTextBox.Text.Trim());
            context.SaveChanges();
            this.Close();
            }
        }
    }
}
