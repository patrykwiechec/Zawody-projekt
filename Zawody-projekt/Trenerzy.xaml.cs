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

            TurniejEntities db = new TurniejEntities();

            var trenerzy = from d in db.trenerzies
                           select new
                           {
                               Trener_ID = d.id_trenera,
                               Imię_Trenera = d.imie_t,
                               Nazwisko_Trenera = d.nazwisko_t,
                               Ilość_Medali = d.ile_medali_t
                           };

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


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TurniejEntities db = new TurniejEntities();

            trenerzy tren = new trenerzy()
            {
                imie_t = Text_Imie_t.Text,
                nazwisko_t = Text_Nazwisko_t.Text,
                ile_medali_t = Int32.Parse(Text_Ile_medali_t.Text)
            };

            db.trenerzies.Add(tren);
            db.SaveChanges();

            var trenerzy = from d in db.trenerzies
                           select new
                           {
                               Trener_ID = d.id_trenera,
                               Imię_Trenera = d.imie_t,
                               Nazwisko_Trenera = d.nazwisko_t,
                               Ilość_Medali = d.ile_medali_t
                           };

            this.gridTrenerzy.ItemsSource = trenerzy.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            TurniejEntities db = new TurniejEntities();

            var trenerzy = from d in db.trenerzies
                           select new
                           {
                               Trener_ID = d.id_trenera,
                               Imię_Trenera = d.imie_t,
                               Nazwisko_Trenera = d.nazwisko_t,
                               Ilość_Medali = d.ile_medali_t
                           };
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            TurniejEntities db = new TurniejEntities();

            int x = Int32.Parse(ID_T.Text);

            var r = from d in db.trenerzies
                    where d.id_trenera == x
                    select d;

            trenerzy obj = r.SingleOrDefault();

            if(obj != null)
            {
                obj.imie_t = this.Text_Imie_t.Text;
                obj.nazwisko_t = this.Text_Nazwisko_t.Text;
                obj.ile_medali_t = Int32.Parse(Text_Ile_medali_t.Text);
            }

            db.SaveChanges();

            var trenerzy = from d in db.trenerzies
                           select new
                           {
                               Trener_ID = d.id_trenera,
                               Imię_Trenera = d.imie_t,
                               Nazwisko_Trenera = d.nazwisko_t,
                               Ilość_Medali = d.ile_medali_t
                           };

            this.gridTrenerzy.ItemsSource = trenerzy.ToList();

        }


    }
}

