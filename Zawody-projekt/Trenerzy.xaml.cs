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

        //Dodanie pola
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TurniejEntities db = new TurniejEntities();
                //Warunek czy wypełniono
                if (Text_Imie_t.Text != "" && Text_Nazwisko_t.Text != "" && Text_Ile_medali_t.Text != "")
                {

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

                    //Czyszczenie pól
                    Text_Ile_medali_t.Clear();
                    Text_Imie_t.Clear();
                    Text_Nazwisko_t.Clear();
                    //Aktualizacja tabeli
                    this.gridTrenerzy.ItemsSource = trenerzy.ToList();
                }
                //Błąd jeśli niewypełniono 
                else
                {
                    MessageBox.Show("Nie wypełniłeś wszystkich pól!");
                }
            }
            //Obsługa błędów
            catch (FormatException)
            {
                MessageBox.Show("Ilość medali nie jest napisem!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                TurniejEntities db = new TurniejEntities();

                int x = Int32.Parse(ID_T.Text);

                var r = from d in db.trenerzies
                        where d.id_trenera == x
                        select d;
                trenerzy obj = r.SingleOrDefault();


                if (x != obj.id_trenera)
                {
                    return;
                }


                if (obj != null)
                {
                    db.trenerzies.Remove(obj);
                    db.SaveChanges();
                }
                //Czyszczenie pól
                Text_Ile_medali_t.Clear();
                Text_Imie_t.Clear();
                Text_Nazwisko_t.Clear();

                //Aktualizacja tabeli
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
            //Obsługa błędów
            catch (NullReferenceException)
            {
                MessageBox.Show("Nie ma takiego ID!");
            }
            catch (FormatException)
            {
                MessageBox.Show("ID nie jest napisem!");
            }

        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TurniejEntities db = new TurniejEntities();

                int x = Int32.Parse(ID_T.Text);

                var r = from d in db.trenerzies
                        where d.id_trenera == x
                        select d;

                trenerzy obj = r.SingleOrDefault();

                if (x != obj.id_trenera)
                {
                    return;
                }

                if (obj != null)
                {
                    if (this.Text_Imie_t.Text != "") obj.imie_t = this.Text_Imie_t.Text;
                    if (this.Text_Nazwisko_t.Text != "") obj.nazwisko_t = this.Text_Nazwisko_t.Text;
                    if (this.Text_Ile_medali_t.Text != "") obj.ile_medali_t = Int32.Parse(Text_Ile_medali_t.Text);
                }

                Text_Ile_medali_t.Clear();
                Text_Imie_t.Clear();
                Text_Nazwisko_t.Clear();



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
            catch (NullReferenceException)
            {
                MessageBox.Show("Nie ma takiego ID!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Błąd formatu pola lub ID!");
            }


        }

    }
}

