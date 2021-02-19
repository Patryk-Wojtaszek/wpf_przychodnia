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

namespace wpf_przychodnia_1
{
    /// <summary>
    /// Logika interakcji dla klasy UmowWizyte.xaml
    /// </summary>
    public partial class UmowWizyte : Window
    {
        public UmowWizyte()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
