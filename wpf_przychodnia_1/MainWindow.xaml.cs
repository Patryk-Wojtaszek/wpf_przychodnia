﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_przychodnia_1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_prac_Click(object sender, RoutedEventArgs e)
        {
            ListaPracownikow listaPracownikow = new ListaPracownikow();
            this.Visibility = Visibility.Hidden;
            listaPracownikow.Show();

        }

        private void btn_pac_Click(object sender, RoutedEventArgs e)
        {
            ListaPacjentow listaPacjentow = new ListaPacjentow();
            this.Visibility = Visibility.Hidden;
            listaPacjentow.Show();
        }

        private void btn_umow_Click(object sender, RoutedEventArgs e)
        {
            UmowWizyte umowWizyte = new UmowWizyte();
            this.Visibility = Visibility.Hidden;
            umowWizyte.Show();
        }
    }
}
