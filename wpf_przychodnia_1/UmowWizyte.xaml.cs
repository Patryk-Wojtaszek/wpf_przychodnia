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
using System.Collections.ObjectModel;

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
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            var pe = from x in przychodniaEntities.Rejestracja
                     select new { x.ID_rejestracji, x.Pacjenci_ID, x.Termin };
            Grid_wizyta.ItemsSource = pe.ToList();

            var grid2 = from x in przychodniaEntities.Pacjenci
                        select new { x.ID_pacjenta, x.Imie, x.Nazwisko };
            grid_list_pacjent.ItemsSource = grid2.ToList();
            //Grid_wizyta.ItemsSource = przychodniaEntities.Rejestracja.ToList();


        }



        public List<int> deletedIDS = new List<int>();

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

        private void Grid_wizyta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();

            try
            {
                int counter = 0;
                try
                {

                    if (deletedIDS.ElementAt(0) <= przychodniaEntities.Rejestracja.Count())
                    {
                        counter = deletedIDS.ElementAt(0);
                        deletedIDS.RemoveAt(0);
                    }
                    else
                    {
                        counter = przychodniaEntities.Rejestracja.Count() + 1;
                        deletedIDS.Clear();
                    }
                }
                catch (Exception)
                {
                    counter = przychodniaEntities.Rejestracja.Count() + 1;
                }


                Rejestracja rejestracja = new Rejestracja()
                {
                    ID_rejestracji = counter,
                    Pacjenci_ID = int.Parse(txt_Add.Text),
                    Termin = txt_data.SelectedDate
                };
                przychodniaEntities.Rejestracja.Add(rejestracja);
                przychodniaEntities.SaveChanges();
                var pe = from x in przychodniaEntities.Rejestracja
                         select new { x.ID_rejestracji, x.Pacjenci_ID, x.Termin };
                Grid_wizyta.ItemsSource = pe.ToList();
                txt_Add.Clear();

            }
            catch (Exception)
            {
                Error2 error = new Error2();
                error.Show();
            }
        }

        private void txt_id_pacjent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
                int id = int.Parse(txt_id_2.Text);
                var removee = przychodniaEntities.Rejestracja.FirstOrDefault(x => x.ID_rejestracji == id);
                przychodniaEntities.Rejestracja.Remove(removee);
                deletedIDS.Add(id);
                deletedIDS.Sort();
                przychodniaEntities.SaveChanges();
                var pe = from x in przychodniaEntities.Rejestracja
                         select new { x.ID_rejestracji, x.Pacjenci_ID, x.Termin };
                Grid_wizyta.ItemsSource = pe.ToList();
                txt_id_2.Clear();
            }
            catch (Exception)
            {
                Error error = new Error();
                error.Show();
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            PrzychodniaEntities przychodniaEntities = new PrzychodniaEntities();
            int id = int.Parse(txt_id_3.Text);
            var modife = przychodniaEntities.Rejestracja.FirstOrDefault(x => x.ID_rejestracji == id);
            if (modife != null)
            {
                modife.Pacjenci_ID = int.Parse(txt_pacjen_mod.Text);
                modife.Termin = txt_data_2.SelectedDate;
            }
            przychodniaEntities.SaveChanges();
            txt_id_3.Clear();
            txt_pacjen_mod.Clear();
            var pe = from x in przychodniaEntities.Rejestracja
                     select new { x.ID_rejestracji, x.Pacjenci_ID, x.Termin };
            Grid_wizyta.ItemsSource = pe.ToList();

        }
    }
}
