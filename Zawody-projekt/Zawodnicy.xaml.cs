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
using System.Data.SqlClient;


namespace Zawody_projekt
{
    /// <summary>
    /// Interaction logic for Zawodnicy.xaml
    /// </summary>
    /// 
    public partial class Zawodnicy : Window
    {

       
        public Zawodnicy()
        {
            InitializeComponent();

            TurniejEntities db = new TurniejEntities();

            var zawodnicy = from d in db.zawodnicies
                            join t in db.trenerzies on d.id_trenera equals t.id_trenera select new
                           {
                               Zawodnik_ID = d.id_zawodnika,
                               Imię_Zawodnik = d.imie,
                               Nazwisko_Zawodnika = d.nazwisko,
                               Kraj = d.kraj,
                               Ilość_Medali = d.ile_medali_t,
                               Trener = t.nazwisko_t
                           };

            this.gridTrenerzy.ItemsSource = zawodnicy.ToList();
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
                if (Text_Imie.Text != "" && Text_Nazwisko.Text != "" && Text_Ile_medali.Text != "" && Text_Kraj.Text != "" && Text_ID_T.Text != "")
                {

                    zawodnicy zaw = new zawodnicy()
                    {
                        imie = Text_Imie.Text,
                        nazwisko = Text_Nazwisko.Text,
                        kraj = Text_Kraj.Text,
                        ile_medali_t = Int32.Parse(Text_Ile_medali.Text),
                        id_trenera = Int32.Parse(Text_ID_T.Text),
                    };

                    db.zawodnicies.Add(zaw);
                    db.SaveChanges();

                    var zawodnicy = from d in db.zawodnicies
                                    join t in db.trenerzies on d.id_trenera equals t.id_trenera
                                    select new
                                    {
                                        Zawodnik_ID = d.id_zawodnika,
                                        Imię_Zawodnik = d.imie,
                                        Nazwisko_Zawodnika = d.nazwisko,
                                        Kraj = d.kraj,
                                        Ilość_Medali = d.ile_medali_t,
                                        Trener = t.nazwisko_t
                                    };

                    //Czyszczenie pól
                    Text_Ile_medali.Clear();
                    Text_Imie.Clear();
                    Text_Nazwisko.Clear();
                    Text_Kraj.Clear();
                    Text_ID_T.Clear();
                    //Aktualizacja tabeli
                    this.gridTrenerzy.ItemsSource = zawodnicy.ToList();
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
                MessageBox.Show("Ilość medali oraz ID trenera to nie napisy!");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Nie ma takiego trenera!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                TurniejEntities db = new TurniejEntities();

                int x = Int32.Parse(ID_Z.Text);

                var r = from d in db.zawodnicies
                        where d.id_zawodnika == x
                        select d;
                zawodnicy obj = r.SingleOrDefault();


                if (x != obj.id_zawodnika)
                {
                    return;
                }


                if (obj != null)
                {
                    db.zawodnicies.Remove(obj);
                    db.SaveChanges();
                }
                //Czyszczenie pól
                Text_Ile_medali.Clear();
                Text_Imie.Clear();
                Text_Nazwisko.Clear();
                Text_Kraj.Clear();
                Text_ID_T.Clear();

                //Aktualizacja tabeli
                var zawodnicy = from d in db.zawodnicies
                                join t in db.trenerzies on d.id_trenera equals t.id_trenera
                                select new
                                {
                                    Zawodnik_ID = d.id_zawodnika,
                                    Imię_Zawodnik = d.imie,
                                    Nazwisko_Zawodnika = d.nazwisko,
                                    Kraj = d.kraj,
                                    Ilość_Medali = d.ile_medali_t,
                                    Trener = t.nazwisko_t
                                };

                this.gridTrenerzy.ItemsSource = zawodnicy.ToList();

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

                int x = Int32.Parse(ID_Z.Text);

                var r = from d in db.zawodnicies
                        where d.id_zawodnika == x
                        select d;

                zawodnicy obj = r.SingleOrDefault();

                if (x != obj.id_zawodnika)
                {
                    return;
                }

                if (obj != null)
                {
                    if (this.Text_Imie.Text != "") obj.imie = this.Text_Imie.Text;
                    if (this.Text_Nazwisko.Text != "") obj.nazwisko = this.Text_Nazwisko.Text;
                    if (this.Text_Ile_medali.Text != "") obj.ile_medali_t = Int32.Parse(Text_Ile_medali.Text);
                    if (this.Text_Kraj.Text != "") obj.kraj = this.Text_Kraj.Text;
                    if (this.Text_ID_T.Text != "") obj.id_trenera = Int32.Parse(Text_ID_T.Text);
                }

                Text_Ile_medali.Clear();
                Text_Imie.Clear();
                Text_Nazwisko.Clear();
                Text_Kraj.Clear();
                Text_ID_T.Clear();



                db.SaveChanges();

                var zawodnicy = from d in db.zawodnicies
                                join t in db.trenerzies on d.id_trenera equals t.id_trenera
                                select new
                                {
                                    Zawodnik_ID = d.id_zawodnika,
                                    Imię_Zawodnik = d.imie,
                                    Nazwisko_Zawodnika = d.nazwisko,
                                    Kraj = d.kraj,
                                    Ilość_Medali = d.ile_medali_t,
                                    Trener = t.nazwisko_t
                                };

                this.gridTrenerzy.ItemsSource = zawodnicy.ToList();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Nie ma takiego ID!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Błąd formatu pól ID lub ilości medali!");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Nie ma takiego trenera!");
            }
        }

    }
}

