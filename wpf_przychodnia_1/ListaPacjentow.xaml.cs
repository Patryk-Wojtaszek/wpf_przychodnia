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
    /// Logika interakcji dla klasy ListaPacjentow.xaml
    /// </summary>
    public partial class ListaPacjentow : Window
    {
        public ListaPacjentow()
        {
            InitializeComponent();
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            var pE = from x in przychodniaEntities.Pacjenci
                     select x;
            Grid_Pacjenci.ItemsSource = pE.ToList();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
