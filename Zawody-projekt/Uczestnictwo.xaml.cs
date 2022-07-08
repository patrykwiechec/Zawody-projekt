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

    public partial class Uczestnictwo : Window
    {
        public Uczestnictwo()
 {
            InitializeComponent();

            TurniejEntities db = new TurniejEntities();
            //Wyświetlanie tabeli
            var uczestnictwo = from d in db.uczestnictwoes
                               join id1 in db.zawodnicies on d.id_zawodnika equals id1.id_zawodnika 
                               join id2 in db.zawodies on d.id_zawodow equals id2.id_zawodow
                               select new

                               {
                                   ID_Uczestnictwa = d.id_uczestnictwa,
                                   Zawodnik = id1.nazwisko,
                                   Zawody = id2.nazwa
                               };

                             
            this.gridTrenerzy.ItemsSource = uczestnictwo.ToList();
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
                if (Text_IDZ.Text != "" && Text_IDZa.Text != "")
                {
                    
                    uczestnictwo uczes = new uczestnictwo()
                    {
                        id_zawodnika = Int32.Parse(Text_IDZ.Text),
                        id_zawodow = Int32.Parse(Text_IDZa.Text),
                    };

                    db.uczestnictwoes.Add(uczes);
                    db.SaveChanges();

                    var uczestnictwo = from d in db.uczestnictwoes
                                       join id1 in db.zawodnicies on d.id_zawodnika equals id1.id_zawodnika
                                       join id2 in db.zawodies on d.id_zawodow equals id2.id_zawodow
                                       select new

                                       {
                                           ID_Uczestnictwa = d.id_uczestnictwa,
                                           Zawodnik = id1.nazwisko,
                                           Zawody = id2.nazwa
                                       };

                    //Czyszczenie pól
                    Text_IDZ.Clear();
                    Text_IDZa.Clear();
                    ID_T.Clear();
                    //Aktualizacja tabeli
                    this.gridTrenerzy.ItemsSource = uczestnictwo.ToList();
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Nie ma takiego zawodnika lub zawodów!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                TurniejEntities db = new TurniejEntities();

                int x = Int32.Parse(ID_T.Text);

                var r = from d in db.uczestnictwoes
                        where d.id_uczestnictwa == x
                        select d;
                uczestnictwo obj = r.SingleOrDefault();


                if (x != obj.id_uczestnictwa)
                {
                    return;
                }


                if (obj != null)
                {
                    db.uczestnictwoes.Remove(obj);
                    db.SaveChanges();
                }
                //Czyszczenie pól
                Text_IDZ.Clear();
                Text_IDZa.Clear();
                ID_T.Clear();

                //Aktualizacja tabeli
                var uczestnictwo = from d in db.uczestnictwoes
                                   join id1 in db.zawodnicies on d.id_zawodnika equals id1.id_zawodnika
                                   join id2 in db.zawodies on d.id_zawodow equals id2.id_zawodow
                                   select new

                                   {
                                       ID_Uczestnictwa = d.id_uczestnictwa,
                                       Zawodnik = id1.nazwisko,
                                       Zawody = id2.nazwa
                                   };

                this.gridTrenerzy.ItemsSource = uczestnictwo.ToList();

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

                var r = from d in db.uczestnictwoes
                        where d.id_uczestnictwa == x
                        select d;

                uczestnictwo obj = r.SingleOrDefault();

                if (x != obj.id_uczestnictwa)
                {
                    return;
                }

                if (obj != null)
                {
                    if (this.Text_IDZ.Text != "") obj.id_zawodow = Int32.Parse(this.Text_IDZ.Text);
                    if (this.Text_IDZa.Text != "") obj.id_zawodnika = Int32.Parse(this.Text_IDZa.Text);
                }

                //Czyszczenie textbox
                Text_IDZ.Clear();
                Text_IDZa.Clear();
                ID_T.Clear();

                db.SaveChanges();

                //Aktualizacja wyświetlania tablicy
                var uczestnictwo = from d in db.uczestnictwoes
                                   join id1 in db.zawodnicies on d.id_zawodnika equals id1.id_zawodnika
                                   join id2 in db.zawodies on d.id_zawodow equals id2.id_zawodow
                                   select new

                                   {
                                       ID_Uczestnictwa = d.id_uczestnictwa,
                                       Zawodnik = id1.nazwisko,
                                       Zawody = id2.nazwa
                                   };

                this.gridTrenerzy.ItemsSource = uczestnictwo.ToList();
            }
            //Obsługa błędów
            catch (NullReferenceException)
            {
                MessageBox.Show("Nie ma takiego ID!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Błąd formatu pól ID!");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show("Nie ma takiego zawodnika lub zawodów!");
            }


        }

    }
}
