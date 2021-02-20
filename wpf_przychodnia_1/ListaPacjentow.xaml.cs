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
            txt_imie.Clear();
            txt_nazwisko.Clear();
            txt_pesel.Clear();

            this.Grid_Pacjenci.ItemsSource = przychodniaEntities.Pacjenci.ToList();
        }
        


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


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            try
            {
                int id = int.Parse(txt_id_2.Text);
                var data = przychodniaEntities.Pacjenci.FirstOrDefault(x => x.ID_pacjenta == id);
                przychodniaEntities.Pacjenci.Remove(data);
                przychodniaEntities.SaveChanges();
                txt_id_2.Clear();
            }catch(Exception)
            {
                Error error = new Error();
                error.Show();
            }
            this.Grid_Pacjenci.ItemsSource = przychodniaEntities.Pacjenci.ToList();
        }
    }
}
