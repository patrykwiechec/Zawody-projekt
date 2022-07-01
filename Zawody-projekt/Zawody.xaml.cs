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
using System.Data;

namespace Zawody_projekt
{
    /// <summary>
    /// Interaction logic for Zawody.xaml
    /// </summary>
    public partial class Zawody : Window
    {
        public Zawody()
        {
            InitializeComponent();

            TurniejEntities db = new TurniejEntities();

            var zawody = from d in db.zawodies
                           select new
                           {
                               ID_Zawodów = d.id_zawodow,
                               Nazwa = d.nazwa,
                               Lokalizacja = d.lokalizacja
                           };

            this.gridTrenerzy.ItemsSource = zawody.ToList();
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
                if (Text_Lokalizacja.Text != "" && Text_Lokalizacja.Text != "")
                {
                    
                    zawody zawod = new zawody()
                    {
                        nazwa = Text_Nazwa.Text,
                        lokalizacja = Text_Lokalizacja.Text
                    };

                    db.zawodies.Add(zawod);
                    db.SaveChanges();

                    var zawody = from d in db.zawodies
                                   select new
                                   {
                                       ID_Zawodów = d.id_zawodow,
                                       Nazwa = d.nazwa,
                                       Lokalizacja = d.lokalizacja
                                   };

                    //Czyszczenie pól
                    Text_Nazwa.Clear();
                    Text_Lokalizacja.Clear();
                    //Aktualizacja tabeli
                    this.gridTrenerzy.ItemsSource = zawody.ToList();
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

                var r = from d in db.zawodies
                        where d.id_zawodow == x
                        select d;
                zawody obj = r.SingleOrDefault();


                if (x != obj.id_zawodow)
                {
                    return;
                }


                if (obj != null)
                {
                    db.zawodies.Remove(obj);
                    db.SaveChanges();
                }
                //Czyszczenie pól
                Text_Nazwa.Clear();
                Text_Lokalizacja.Clear();

                //Aktualizacja tabeli
                var zawody = from d in db.zawodies
                               select new
                               {
                                   ID_Zawodów = d.id_zawodow,
                                   Nazwa = d.nazwa,
                                   Lokalizacja = d.lokalizacja
                               };

                this.gridTrenerzy.ItemsSource = zawody.ToList();

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

                var r = from d in db.zawodies
                        where d.id_zawodow == x
                        select d;

                zawody obj = r.SingleOrDefault();

                if (x != obj.id_zawodow)
                {
                    return;
                }

                if (obj != null)
                {
                    if (this.Text_Nazwa.Text != "") obj.nazwa = this.Text_Nazwa.Text;
                    if (this.Text_Lokalizacja.Text != "") obj.lokalizacja = this.Text_Lokalizacja.Text;
                }
                //Czyszczenie textbox
                Text_Nazwa.Clear();
                Text_Lokalizacja.Clear();



                db.SaveChanges();

                var zawody = from d in db.zawodies
                               select new
                               {
                                   ID_Zawodów = d.id_zawodow,
                                   Nazwa = d.nazwa,
                                   Lokalizacja = d.lokalizacja
                               };

                this.gridTrenerzy.ItemsSource = zawody.ToList();
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
