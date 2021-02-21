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
        // inicjacja gridu zawierającego liste wszystkicj pacjentów
        public ListaPacjentow()
        {
            InitializeComponent();
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            var pE = from x in przychodniaEntities.Pacjenci
                     select x;
            Grid_Pacjenci.ItemsSource = pE.ToList();
        }
        // napotkałem się na problem w sytuacji gdy np.  mam 8 pacjentów, usuwam pacjenta o id 6 i 7 , a następnie próbuje dodać nowych
        // ta lista i zmiany w Add_Click i Modify_Click wydaję mi się , że rozwiązały problem, aczkolwiek pewnie był o wiele łatwiejszy sposób by to osiągnąć
        public List<int> deletedIds = new List<int>();

        // powrót do głównej strony
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        // usunięcie pacjenta o podanym nr id
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            try
            {
                int id = int.Parse(txt_id_2.Text);
                var data = przychodniaEntities.Pacjenci.FirstOrDefault(x => x.ID_pacjenta == id);
                przychodniaEntities.Pacjenci.Remove(data);
                 // info nad list deleted ids
                deletedIds.Add(id);
                deletedIds.Sort();
              

            }
            catch (Exception)
            {
                Error error = new Error();
                error.Show();
            }

            przychodniaEntities.SaveChanges();
            txt_id_2.Clear();


            this.Grid_Pacjenci.ItemsSource = przychodniaEntities.Pacjenci.ToList();
        }

        //dodanie nowego pacjenta
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();

            int counter = 0;
            try
            {
                if (deletedIds.ElementAt(0) <= przychodniaEntities.Pacjenci.Count())
                {
                    counter = deletedIds.ElementAt(0);
                    deletedIds.RemoveAt(0);
                }
                else
                {
                    counter = (przychodniaEntities.Pacjenci.Count() + 1);
                    deletedIds.Clear();
                }
            }catch (Exception)
            {
                counter = (przychodniaEntities.Pacjenci.Count() + 1);
            }// info nad list deleted ids


            Pacjenci nowyPacjent = new Pacjenci()
            {
                ID_pacjenta =counter ,
                Imie = txt_imie.Text,
                Nazwisko = txt_nazwisko.Text,
                Pesel = txt_pesel.Text,
                Data_urodzenia = txt_data.SelectedDate
                
                
                
            };

            przychodniaEntities.Pacjenci.Add(nowyPacjent);
            przychodniaEntities.SaveChanges();
            txt_imie.Clear();
            txt_nazwisko.Clear();
            txt_pesel.Clear();

            this.Grid_Pacjenci.ItemsSource = przychodniaEntities.Pacjenci.ToList();
        }
        

        // edycja pacjenta
        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txt_id.Text);
                PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
                var data = przychodniaEntities.Pacjenci.FirstOrDefault(x => x.ID_pacjenta == id);
                if (data != null)
                {
                    data.Imie = txt_imie_2.Text;
                    data.Nazwisko = txt_nazwisko_2.Text;
                    data.Pesel = txt_pesel_2.Text;
                    data.Data_urodzenia = txt_data_2.SelectedDate;
                }
                przychodniaEntities.SaveChanges();
                txt_id.Clear();
                txt_imie_2.Clear();
                txt_nazwisko_2.Clear();
                txt_pesel_2.Clear();

                this.Grid_Pacjenci.ItemsSource = przychodniaEntities.Pacjenci.ToList();
            } catch (Exception)
            {
                Error error = new Error();
                error.Show();
            }
        }

        // wyłączenie aplikacji
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        // pola pesel i id przyjmują tylko argumenty cyfrowe
        private void txt_pesel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
          
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            
        }

        private void txt_id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        
    }
}
