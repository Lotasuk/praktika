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
using praktika.BD;

namespace praktika.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdateStaff.xaml
    /// </summary>
    public partial class UpdateStaff : Window
    {
        private Staff _selectedStaff;
        public UpdateStaff(Staff staff)
        {
            InitializeComponent();
            _selectedStaff = staff;
            NameBox.Text = staff.Name;
            SurnameBox.Text = staff.Surname;
            PatronymicBox.Text = staff.Patronymic;
            NumberBox.Text = staff.Number;
            RoleIdBox.Text = staff.RoleId.ToString();
            
        }

        private void UpdEmployee_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new Entity();
            _selectedStaff.Name = NameBox.Text;
            _selectedStaff.Surname = SurnameBox.Text;
            _selectedStaff.Patronymic = PatronymicBox.Text;
            _selectedStaff.Number = NumberBox.Text;
            _selectedStaff.RoleId = int.Parse(RoleIdBox.Text);
            ctx.Staff.Update(_selectedStaff);
            ctx.SaveChanges();
        }
    }
}
