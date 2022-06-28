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

namespace Zawody_projekt
{
    /// <summary>
    /// Interaction logic for Trenerzy.xaml
    /// </summary>
    public partial class Trenerzy : Window
    {
        public Trenerzy()
        {
            InitializeComponent();

            TurniejeEntities db = new TurniejeEntities();
            var trenerzy = from d in db.trenerzies
                           select new
                           {
                               TrenerID = d.id_trenera,
                               ImięTrenera = d.imie_t,
                               NazwiskoTrenera = d.nazwisko_t,
                               DataUrodzenia = d.data_ur_t
                           };

            

            foreach (var item in trenerzy)
            {
                DateTime data = item.DataUrodzenia;
                Console.WriteLine(item.TrenerID);
                Console.WriteLine(item.ImięTrenera);
                Console.WriteLine(item.NazwiskoTrenera);
                Console.WriteLine(data.ToString("dd/MM/yyyy"));
            }

            this.gridTrenerzy.ItemsSource = trenerzy.ToList();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        //cofnij do MainWindow
        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //Wyjście z aplikacji
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
