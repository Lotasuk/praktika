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
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

      


        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = new Entity().ClientsLogins.Where(x => x.Login == Loginbox.Text && x.Password == Passwordbox.Text).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Данные введены неверно");
                return;
            }
            new Cars().Show();
            this.Close();
        }
    }
}
