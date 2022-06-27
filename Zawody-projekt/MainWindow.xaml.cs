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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Zawody_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
        //Otwórz okno Zawodnicy
        private void Zawodnicy_Click(object sender, RoutedEventArgs e)
        {
            Zawodnicy zawodnicy = new Zawodnicy();
            zawodnicy.Show();
            Close();
        }
        //Otwórz okno Trenerzy
        private void Trenerzy_Click(object sender, RoutedEventArgs e)
        {
            Trenerzy trenerzy = new Trenerzy();
            trenerzy.Show();
            Close();
        }

        //Otwórz okno Uczestnictwo
        private void Uczestnictwo_Click(object sender, RoutedEventArgs e)
        {
            Uczestnictwo uczestnictwo = new Uczestnictwo();
            uczestnictwo.Show();
            Close();
        }
         //Otwórz okno Zawody
        private void Zawody_Click(object sender, RoutedEventArgs e)
        {
            Zawody zawody = new Zawody();
            zawody.Show();
            Close();
        }

        //Wyjście z aplikacji
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
