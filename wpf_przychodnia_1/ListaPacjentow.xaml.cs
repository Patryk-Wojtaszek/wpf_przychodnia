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
using System.Text.RegularExpressions;
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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            this.Grid_Pacjenci.ItemsSource = przychodniaEntities.Pacjenci.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

      
  
            

                PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            Pacjenci nowyPacjent = new Pacjenci()
            {
                ID_pacjenta = (przychodniaEntities.Pacjenci.Count() + 1),
                Imie = txt_imie.Text,
                Nazwisko = txt_nazwisko.Text,
                Pesel = txt_pesel.Text,
                Data_urodzenia = txt_data.SelectedDate
                
                
                
            };

            przychodniaEntities.Pacjenci.Add(nowyPacjent);
            przychodniaEntities.SaveChanges();
            
   

        }

        private void Grid_Pacjenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Grid_Pacjenci.SelectedIndex >= 0)
            {
                if (this.Grid_Pacjenci.SelectedItems.Count >= 0)
                {
                    if (this.Grid_Pacjenci.SelectedItems[0].GetType() == typeof(Pacjenci))
                    {
                        Pacjenci p = (Pacjenci)this.Grid_Pacjenci.SelectedItems[0];
                        this.txt_imie_2.Text = p.Imie;
                        this.txt_nazwisko_2.Text = p.Nazwisko;
                        this.txt_pesel_2.Text = p.Pesel;
                    }
                }
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
    
        }

        private void txt_imie_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void txt_pesel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
          
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            
        }
    }
}
