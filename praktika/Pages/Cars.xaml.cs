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
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class Cars : Window
    {
        private void DownloadData() => TableData.ItemsSource = new Entity().Cars.ToList();
        public Cars()
        {
            InitializeComponent();
            DownloadData();
        }

        private void TableData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
