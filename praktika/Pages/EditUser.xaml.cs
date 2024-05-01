using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        

        private void DownloadData() => TableData.ItemsSource = new Entity().Staff.ToList();
        public EditUser()
        {
            InitializeComponent();
 
           
            DownloadData();
        }

        private void TableData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            new AddStaff().Show();
        }

        private void RemoveData_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new Entity();
            var item = TableData.SelectedItem as Staff;
            ctx.Staff.Remove(item);
            ctx.SaveChanges();
            DownloadData();
        }

        private void UpdateData_Click(object sender, RoutedEventArgs e)
        {
            new UpdateStaff(TableData.SelectedItem as Staff).Show();
        }

        private void UpdateTable_Click(object sender, RoutedEventArgs e)
        {
            DownloadData();
        }
    }
}
