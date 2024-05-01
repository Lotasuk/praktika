using praktika.BD;
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

namespace praktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var admin = new Entity().StaffLogins.Where(x => x.Login == Loginbox.Text && x.Password == Passwordbox.Text).FirstOrDefault();
            if (admin == null)
            {
                MessageBox.Show("Данные введены неверно");
                return;
            }
            new EditUser().Show();
            this.Close();
        }
    }
}
