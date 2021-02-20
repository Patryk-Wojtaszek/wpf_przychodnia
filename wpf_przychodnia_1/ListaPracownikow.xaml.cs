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
    /// Logika interakcji dla klasy ListaPracownikow.xaml
    /// </summary>
    public partial class ListaPracownikow : Window
    {
        public ListaPracownikow()
        {
            InitializeComponent();

            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            var pE = from x in przychodniaEntities.Pracownicy
                     select x;
            Grid_Pracownicy.ItemsSource = pE.ToList();

        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

 

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            Pracownicy nowyPracownik = new Pracownicy()
            {
                ID_pracownika = ((przychodniaEntities.Pracownicy.Count() + 1)),
                Imie = txt_imie.Text,
                Nazwisko = txt_nazwisko.Text,
                Specjalizacja = txt_specjalizacja.Text,
                 Data_urodzenia = txt_data.SelectedDate,
                 Email = txt_email.Text
            };
            przychodniaEntities.Pracownicy.Add(nowyPracownik);
            przychodniaEntities.SaveChanges();

            txt_imie.Clear();
            txt_nazwisko.Clear();
            txt_email.Clear();
            txt_specjalizacja.Clear();
            
            this.Grid_Pracownicy.ItemsSource = przychodniaEntities.Pracownicy.ToList();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            int a = int.Parse(txt_id.Text);
            var data = przychodniaEntities.Pracownicy.FirstOrDefault(x => x.ID_pracownika == a);
            if (data != null)
            {
                data.Imie = txt_imie_2.Text;
                data.Nazwisko = txt_nazwisko_2.Text;
                data.Email = txt_email_2.Text;
                data.Specjalizacja = txt_specjalizacja_2.Text;
                data.Data_urodzenia = txt_data_2.SelectedDate;
            }
            przychodniaEntities.SaveChanges();
            txt_id.Clear();
            txt_imie_2.Clear();
            txt_nazwisko_2.Clear();
            txt_email_2.Clear();
            txt_specjalizacja_2.Clear();
            this.Grid_Pracownicy.ItemsSource = przychodniaEntities.Pracownicy.ToList();


        }

        private void txt_id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(txt_id_3.Text);
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            var data = przychodniaEntities.Pracownicy.FirstOrDefault(x => x.ID_pracownika == a);
            przychodniaEntities.Pracownicy.Remove(data);
            przychodniaEntities.SaveChanges();
            txt_id_3.Clear();
            this.Grid_Pracownicy.ItemsSource = przychodniaEntities.Pracownicy.ToList();
        }
    }
}
