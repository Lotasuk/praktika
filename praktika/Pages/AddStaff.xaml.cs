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
    /// Логика взаимодействия для AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new Entity();
            var staff = new Staff
            {
                Id = int.Parse(IDBox.Text),
                Name = Name.Text,
                Surname = Surname.Text,
                Patronymic = Patronymic.Text,
                Number = Number.Text,
                RoleId = int.Parse(RoleId.Text),
            };

            ctx.Staff.Add(staff);
            ctx.SaveChanges();
            ctx.Dispose();
            this.Close();
        }
    }
}
